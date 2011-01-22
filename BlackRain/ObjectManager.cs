using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using BlackRain.Common;
using BlackRain.WowObject;
using BlackRain.WowObjects;
using MemoryIO;
using AccessRights = MemoryIO.AccessRights;

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

		private static IntPtr CurrentManager { get; set; }
		private static Dictionary<ulong, WowObjects.WowObject> ObjectDictionary { get; set; }
		private static Process WowProcess { get; set; }

		#endregion

		#region Public

		/// <summary>
		/// A list of all <see cref="WowObject">WowObjects</see> currently in memory.
		/// </summary>
		public static List<WowObjects.WowObject> Objects { get; private set; }

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
			Objects = new List<WowObjects.WowObject>();
			ObjectDictionary = new Dictionary<ulong, WowObjects.WowObject>();
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

				if (Objects.Count > 0)
					Objects.Clear();

				try
				{
					var currentObject =
							new WowObjects.WowObject(Memory.ReadUInt(CurrentManager + (uint) Offsets.ObjectManager.FirstObject));

					if (currentObject.BaseAddress == uint.MinValue || currentObject.BaseAddress%2 != uint.MinValue)
					{
						Memory = null;
						Me = null;
						Initialize(WowProcess);
						return;
					}

					while (currentObject.BaseAddress != uint.MinValue && currentObject.BaseAddress%2 == uint.MinValue)
					{
						switch (currentObject.Type)
						{
							case (int) Offsets.ObjectType.Unit:
								Objects.Add(new WowUnit(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.Item:
								Objects.Add(new WowItem(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.Container:
								Objects.Add(new WowContainer(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.Corpse:
								Objects.Add(new WowCorpse(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.GameObject:
								Objects.Add(new WowGameObject(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.DynamicObject:
								Objects.Add(new WowDynamicObject(currentObject.BaseAddress));
								break;
							case (int) Offsets.ObjectType.Player:
								Objects.Add(new WowPlayer(currentObject.BaseAddress));
								break;
							default:
								break;
						}

						if (currentObject.GUID == PlayerGUID && Me == null)
							Me = new WowPlayerMe(currentObject.BaseAddress);

						currentObject.BaseAddress =
								Memory.ReadUInt(currentObject.BaseAddress + (uint) Offsets.ObjectManager.NextObject);
					}
				}
				catch (Exception ex)
				{
					Logging.WriteException(Color.Red, ex);
				}
			}
		}

		private static void ReadObjectList()
		{
			if (CurrentManager == IntPtr.Zero) // Can't pulse if we're not onto something!
			{
				Initialize(WowProcess);
			}

			var localPlayerGuid = Memory.Read<ulong>((IntPtr)(CurrentManager.ToInt32() + (uint)Offsets.ObjectManager.LocalGUID));
			var current = Memory.Read<IntPtr>((IntPtr) (CurrentManager.ToInt32() + (uint)Offsets.ObjectManager.FirstObject));

			while (current != IntPtr.Zero && ((uint)current.ToInt32() & 1) != 1)
			{
				var guid = WowObjects.WowObject.GetStorageField<ulong>(current, (uint) Offsets.WowObjectFields.OBJECT_FIELD_GUID);

				if(!ObjectDictionary.ContainsKey(guid))
				{
					var oType =
							(Offsets.ObjectType)
							WowObjects.WowObject.GetStorageField<uint>(current, (uint) Offsets.WowObjectFields.OBJECT_FIELD_TYPE);

					WowObjects.WowObject wowObject = null;

					switch (oType)
					{
						case Offsets.ObjectType.Object:
							wowObject = new WowObjects.WowObject(current);
							break;
							case Offsets.ObjectType.Unit:
							wowObject= new WowUnit()
					}
				}
			}
		}

		/// <summary>
		/// Reads the memory at the specified address.
		/// </summary>
		/// <typeparam name="T">The type of data to be read.</typeparam>
		/// <param name="address">The memory location.</param>
		/// <returns>(T) value</returns>
		public static T Read<T>(uint address)
		{
			object ret;
			var t = typeof (T);

			switch (Type.GetTypeCode(typeof (T)))
			{
				case TypeCode.Int16:
					ret = Memory.ReadUShort(address);
					break;
				case TypeCode.Int32:
					ret = Memory.ReadInt(address);
					break;
				case TypeCode.Int64:
					ret = Memory.ReadInt64(address);
					break;
				case TypeCode.String:
					ret = Memory.ReadASCIIString(address, 40);
					break;
				case TypeCode.UInt16:
					ret = Memory.ReadUShort(address);
					break;
				case TypeCode.UInt32:
					ret = Memory.ReadUInt(address);
					break;
				case TypeCode.UInt64:
					ret = Memory.ReadUInt64(address);
					break;
				case TypeCode.Single:
					ret = Memory.ReadShort(address);
					break;
				case TypeCode.Byte:
					ret = Memory.ReadByte(address);
					break;
				case TypeCode.Object:
					ret = Memory.ReadObject(address, t);
					break;
				case TypeCode.Double:
					ret = Memory.ReadDouble(address);
					break;
				default:
					throw new NotSupportedException(string.Format("Type {0} is not currently supported.",
					                                              typeof (T).FullName));
			}

			return (T) ret;
		}

		/// <summary>
		/// Reads the relative memory at the specified address.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="address">The address.</param>
		/// <returns></returns>
		/// 16/10/2010 16:38
		public static T ReadRelative<T>(uint address)
		{
			object ret;
			var t = typeof (T);

			switch (Type.GetTypeCode(typeof (T)))
			{
				case TypeCode.Int16:
					ret = Memory.ReadUShort(MakeAbsolute(address));
					break;
				case TypeCode.Int32:
					ret = Memory.ReadInt(MakeAbsolute(address));
					break;
				case TypeCode.Int64:
					ret = Memory.ReadInt64(MakeAbsolute(address));
					break;
				case TypeCode.String:
					ret = Memory.ReadASCIIString(MakeAbsolute(address), 40);
					break;
				case TypeCode.UInt16:
					ret = Memory.ReadUShort(MakeAbsolute(address));
					break;
				case TypeCode.UInt32:
					ret = Memory.ReadUInt(MakeAbsolute(address));
					break;
				case TypeCode.UInt64:
					ret = Memory.ReadUInt64(MakeAbsolute(address));
					break;
				case TypeCode.Single:
					ret = Memory.ReadShort(MakeAbsolute(address));
					break;
				case TypeCode.Byte:
					ret = Memory.ReadByte(MakeAbsolute(address));
					break;
				case TypeCode.Object:
					ret = Memory.ReadObject(MakeAbsolute(address), t);
					break;
				case TypeCode.Double:
					ret = Memory.ReadDouble(MakeAbsolute(address));
					break;
				default:
					throw new NotSupportedException(string.Format("Type {0} is not currently supported.",
					                                              typeof (T).FullName));
			}

			return (T) ret;
		}

		/// <summary>
		/// Writes the value of type T to the specified address.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="address">The address.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// 19/10/2010 17:44
		public static bool Write<T>(uint address, T value)
		{
			if (typeof (T) == typeof (string))
				throw new NotSupportedException("BlackRain.Write<T> currently does not support the writing of type " +
				                                typeof (T).FullName);

			try
			{
				object val = value;

				byte[] bytes;

				// Handle types that don't have a real typecode
				// and/or can be done without the ReadByte bullshit
				if (typeof (T) == typeof (IntPtr))
				{
					// Since we're already here...... we might as well do some stuffs.
					Marshal.WriteIntPtr(new IntPtr(address), (IntPtr) val);
					return true;
				}

				// Make sure we're handling passing in stuff as a byte array.
				if (typeof (T) == typeof (byte[]))
				{
					bytes = (byte[]) val;
					return Memory.WriteBytes(address, bytes);
				}
				switch (Type.GetTypeCode(typeof (T)))
				{
					case TypeCode.Boolean:
						bytes = BitConverter.GetBytes((bool) val);
						break;
					case TypeCode.Char:
						bytes = BitConverter.GetBytes((char) val);
						break;
					case TypeCode.Byte:
						bytes = new[] {(byte) val};
						break;
					case TypeCode.Int16:
						bytes = BitConverter.GetBytes((short) val);
						break;
					case TypeCode.UInt16:
						bytes = BitConverter.GetBytes((ushort) val);
						break;
					case TypeCode.Int32:
						bytes = BitConverter.GetBytes((int) val);
						break;
					case TypeCode.UInt32:
						bytes = BitConverter.GetBytes((uint) val);
						break;
					case TypeCode.Int64:
						bytes = BitConverter.GetBytes((long) val);
						break;
					case TypeCode.UInt64:
						bytes = BitConverter.GetBytes((ulong) val);
						break;
					case TypeCode.Single:
						bytes = BitConverter.GetBytes((float) val);
						break;
					case TypeCode.Double:
						bytes = BitConverter.GetBytes((double) val);
						break;
					default:
						throw new NotSupportedException(typeof (T).FullName + " is not currently supported by Write<T>");
				}
				return Memory.WriteBytes(address, bytes);
			}
			catch
			{
				return false;
			}
		}

		#endregion

		#region Search Members

		/// <summary>
		/// Returns all objects of type T.
		/// </summary>
		/// <typeparam name="T">The type of object.</typeparam>
		/// <returns></returns>
		public static List<T> ObjectsOfType<T>()
		{
			var objects = (from o in Objects.OfType<T>()
			               select o).ToList();

			return objects;
		}

		/// <summary>
		/// Gets object of the specified type. 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="allowInheritance">Indicates whether to also get objects that derives from the specified type (ie. WowPlayer derives from WoWUnit, so specifying WoWUnit and true would also return all players).</param>
		/// <param name="includeMeIfFound">Indicates whether to include the local player.</param>
		/// <returns></returns>
		public static List<T> GetObjectsOfType<T>(bool allowInheritance, bool includeMeIfFound) where T : WowObjects.WowObject
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