using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BlackRain.Common;
using BlackRain.WowObjects;
using MemoryIO;

namespace BlackRain
{
    /// <summary>
    /// Manages all the BlackRain WowObjects, and maintains them.
    /// </summary>
    public static class ObjectManager
    {
        #region Fields

        private static readonly object _objPulse = new object();

        #endregion

        #region Properties

        #region Private

        private static Dictionary<ulong, WowObject> ObjectDictionary { get; set; }
        private static Process WowProcess { get; set; }

        #endregion

        #region Internal

        internal static IntPtr CurrentManager { get; private set; }

        #endregion

        #region Public

        /// <summary>
        /// Checks whether this has been initialized at least once, and so contains a process to read.
        /// </summary>
        public static bool Initialized
        {
            get { return WowProcess != null; }
        }

        /// <summary>
        /// A list of all <see cref="WowObject">WowObjects</see> currently in memory.
        /// </summary>
        public static List<WowObject> Objects { get; private set; }

        /// <summary>
        /// The local player.
        /// </summary>
        public static WowPlayerMe Me { get; set; }

        #region EasyLists

        /// <summary>
        /// A list of all Corpses.
        /// </summary>
        public static List<WowCorpse> Corpses
        {
            get { return GetObjectsOfType<WowCorpse>(false, true); }
        }

        /// <summary>
        /// A list of all Game Objects.
        /// </summary>
        public static List<WowGameObject> GameObjects
        {
            get { return GetObjectsOfType<WowGameObject>(false, false); }
        }

        /// <summary>
        /// A list of all units.
        /// </summary>
        public static List<WowUnit> Units
        {
            get { return GetObjectsOfType<WowUnit>(false, true); }
        }

        #endregion

        #endregion

        #endregion

        #region Constructors

        static ObjectManager()
        {
            Objects = new List<WowObject>();
            ObjectDictionary = new Dictionary<ulong, WowObject>();
            Me = new WowPlayerMe(IntPtr.Zero);
        }

        #endregion

        #region Events

        #region Handler Delegates

        /// <summary>
        /// Delegate for the handlers of the <see cref="Pulsed"/> event.
        /// </summary>
        /// <param name="success"><c>true</c> if the pulse completed without error.</param>
        public delegate void PulsedHandler(bool success);

        #endregion

        #region Events

        /// <summary>
        /// Event that fires after <see cref="Pulse"/> completes.
        /// </summary>
        public static event PulsedHandler Pulsed;

        #endregion

        #region Invokers

        private static void InvokePulsed(bool success)
        {
            if (Pulsed != null)
            {
                Pulsed(success);
            }
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Initialized the ObjectManager, and attaches it to the selected process ID.
        /// </summary>
        /// <param name="wowProc">The wow proc.</param>
        public static void Initialize(Process wowProc)
        {
            WowProcess = wowProc;
            Memory.OpenProcess(wowProc.Id, AccessRights.Read);

            CurrentManager =
                Memory.ReadRelative<IntPtr>(new IntPtr((uint) Offsets.ObjectManager.ClientConnection),
                                            new IntPtr((uint) Offsets.ObjectManager.CurrentManager));
        }

        /// <summary>
        /// Resets the radar with the current process.
        /// </summary>
        public static void Reset()
        {
            Reset(WowProcess);
        }

        /// <summary>
        /// Resets the radar with a new Wow Process.
        /// </summary>
        /// <param name="wowProcess">The new instance of Wow to which we want to attach the radar.</param>
        public static void Reset(Process wowProcess)
        {
            Me.BaseAddress = IntPtr.Zero;
            Initialize(wowProcess);
        }

        #region Memory Accessors

        /// <summary>
        /// Pulses the ObjectManager, refreshing any objects it holds.
        /// </summary>
        public static void Pulse()
        {
            lock (_objPulse)
            {
                if (CurrentManager == IntPtr.Zero)
                {
                    Initialize(WowProcess);
                }

                foreach (var wowObject in ObjectDictionary)
                {
                    wowObject.Value.BaseAddress = IntPtr.Zero;
                }

                ReadObjectList();

                var remove =
                    ObjectDictionary.Where(o => o.Value.BaseAddress == IntPtr.Zero).Select(o => o.Key).ToArray();

                if (Me.BaseAddress == IntPtr.Zero || remove.Length == ObjectDictionary.Count)
                {
                    InvokePulsed(false);
                    return;
                }

                foreach (var guid in remove)
                {
                    ObjectDictionary.Remove(guid);
                }

                Objects = ObjectDictionary.Values.ToList();

                InvokePulsed(true);
            }
        }

        private static void ReadObjectList()
        {
            var localPlayerGuid =
                Memory.ReadAtOffset<ulong>(CurrentManager, (uint) Offsets.ObjectManager.LocalGUID);
            var current =
                Memory.ReadAtOffset<IntPtr>(CurrentManager, (uint) Offsets.ObjectManager.FirstObject);

            if (current == IntPtr.Zero || ((uint) current & 1) == 1)
            {
                Reset(WowProcess);
                return;
            }

            while (current != IntPtr.Zero && ((uint) current & 1) != 1)
            {
                var guid = WowObject.GetStorageField<ulong>(current,
                                                            (uint) Descriptors.WowObjectFields.OBJECT_FIELD_GUID);

                if (!ObjectDictionary.ContainsKey(guid))
                {
                    var oType =
                        (Offsets.ObjectType) Memory.ReadAtOffset<uint>(current, (uint) Offsets.ObjectManager.ObjectType);

                    WowObject wowObject = null;

                    switch (oType)
                    {
                        case Offsets.ObjectType.GameObject:
                            wowObject = new WowGameObject(current);
                            break;
                        case Offsets.ObjectType.Object:
                            wowObject = new WowObject(current);
                            break;
                        case Offsets.ObjectType.Player:
                            wowObject = new WowPlayer(current);
                            break;
                        case Offsets.ObjectType.Unit:
                            wowObject = new WowUnit(current);
                            break;
                        default:
                            break;
                    }

                    if (wowObject != null)
                    {
                        ObjectDictionary.Add(guid, wowObject);
                    }
                }
                else
                {
                    ObjectDictionary[guid].BaseAddress = current;
                }

                //  Keep the local player's GUID up-to-date
                if (localPlayerGuid == guid)
                {
                    Me.BaseAddress = current;
                }

                current = Memory.ReadAtOffset<IntPtr>(current, (uint) Offsets.ObjectManager.NextObject);
            }
        }

        #endregion

        #region Search Members

        /// <summary>
        /// Returns all objects of type T, including SubTypes and the local player (if <typeparamref name="T"/> is
        /// <see cref="Type"/> <see cref="WowUnit"/> or <see cref="WowPlayer"/>).
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <returns></returns>
        public static List<T> ObjectsOfType<T>() where T : WowObject
        {
            return GetObjectsOfType<T>(true, true);
        }

        /// <summary>
        /// Gets object of the specified type. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allowInheritance">Indicates whether to also get objects that derives from the specified type (ie. WowPlayer derives from WoWUnit, so specifying WoWUnit and true would also return all players).</param>
        /// <param name="includeMeIfFound">Indicates whether to include the local player.</param>
        /// <returns></returns>
        public static List<T> GetObjectsOfType<T>(bool allowInheritance, bool includeMeIfFound)
            where T : WowObject
        {
            var upperType = typeof (T);
            var tempObjects = new List<T>();

            tempObjects.AddRange((from t1 in Objects
                                  let t = t1.GetType()
                                  where t == upperType || (allowInheritance && t.IsSubclassOf(upperType))
                                  where includeMeIfFound || t1.GUID != Me.GUID
                                  select t1).OfType<T>());

            return tempObjects;
        }

        #endregion

        #endregion
    }
}