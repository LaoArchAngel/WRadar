using System;
using BlackRain.Common;
using MemoryIO;

namespace BlackRain.WowObjects
{
    /// <summary>
    /// An Object. Everything that inherits from WowObject, such as an item, is also an object.
    /// But an object is not necessarily an item.
    /// </summary>
    public class WowObject
    {
        /// <summary>
        /// The Base Address of the object.
        /// </summary>
        public IntPtr BaseAddress { get; set; }

        /// <summary>
        /// Instantiates a new WowObject.
        /// </summary>
        /// <param name="baseAddress">The Object's Base Address.</param>
        public WowObject(IntPtr baseAddress)
        {
            BaseAddress = baseAddress;
        }

        /// <summary>
        /// The object's GUID.
        /// </summary>
        public virtual ulong GUID
        {
            get
            {
                try
                {
                    return GetStorageField<ulong>((uint) Descriptors.WowObjectFields.OBJECT_FIELD_GUID);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// The object's Type.
        /// </summary>
        public int Type
        {
            get { return Memory.ReadAtOffset<int>(BaseAddress, (uint)Offsets.ObjectManager.ObjectType); }
            //get { return GetStorageField<int>((uint)Descriptors.WowObjectFields.OBJECT_FIELD_TYPE); }
        }

        /// <summary>
        /// The object's Entry.
        /// </summary>
        public uint Entry
        {
            get { return GetStorageField<uint>((uint) Descriptors.WowObjectFields.OBJECT_FIELD_ENTRY); }
        }

        /// <summary>
        /// The object's level.
        /// </summary>
        public int Level
        {
            get { return GetStorageField<int>((uint) Descriptors.WowUnitFields.UNIT_FIELD_LEVEL); }
        }

        /// <summary>
        /// Returns the object's X position.
        /// </summary>
        public virtual float X
        {
            get { return Memory.ReadAtOffset<float>(BaseAddress, (uint) Offsets.WowObject.X); }
        }

        /// <summary>
        /// Returns the object's Y position.
        /// </summary>
        public virtual float Y
        {
            get { return Memory.ReadAtOffset<float>(BaseAddress, (uint) Offsets.WowObject.Y); }
        }

        /// <summary>
        /// Returns the object's Z position.
        /// </summary>
        public virtual float Z
        {
            get { return Memory.ReadAtOffset<float>(BaseAddress, (uint) Offsets.WowObject.Z); }
        }

        /// <summary>
        /// Returns the Facing orientation.
        /// </summary>
        public virtual float Facing
        {
            get { return Memory.ReadAtOffset<float>(BaseAddress, (uint) Offsets.WowObject.Facing); }
        }

        /// <summary>
        /// Determines if the unit is our local player.
        /// </summary>
        public bool IsMe
        {
            get { return GUID == ObjectManager.Me.GUID ? true : false; }
        }

        /// <summary>
        /// OBJECT_FIELD_SCALE_X
        /// </summary>
        public int ScaleX
        {
            get { return GetStorageField<int>((uint) Descriptors.WowObjectFields.OBJECT_FIELD_SCALE_X); }
        }

        /// <summary>
        /// The objects padding.
        /// </summary>
        public int Padding
        {
            get { return GetStorageField<int>((uint) Descriptors.WowObjectFields.OBJECT_FIELD_PADDING); }
        }

        #region <Storage Field Methods>

        /// <summary>
        /// Gets the descriptor struct.
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="field">Descriptor field</param>
        /// <returns>Descriptor field</returns>
        protected T GetStorageField<T>(uint field) where T : struct
        {
            var pStorage = Memory.ReadAtOffset<IntPtr>(BaseAddress, 0x08);

            // Uses legacy reading because of errors.
            return Memory.ReadAtOffset<T>(pStorage, field*4);
        }

        /// <summary>
        /// Gets the descriptor struct.
        /// Overload for when not casting uint.
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="field">Descriptor field</param>
        /// <returns>Descriptor field</returns>
        protected T GetStorageField<T>(Descriptors.WowObjectFields field) where T : struct
        {
            return GetStorageField<T>((uint) field);
        }

        /// <summary>
        /// Gets the descriptor value of a WowObject
        /// </summary>
        /// <typeparam name="T">Descriptor struct</typeparam>
        /// <param name="wowObjectPtr">Base address of any WowObject</param>
        /// <param name="field">Descriptor field</param>
        /// <returns>Value of the descriptor field in memory.</returns>
        public static T GetStorageField<T>(IntPtr wowObjectPtr, uint field) where T : struct
        {
            var descriptors = Memory.ReadAtOffset<IntPtr>(wowObjectPtr, 0x8);

            return Memory.ReadAtOffset<T>(descriptors, field*4);
        }

        #endregion
                
        #region Equals and GetHashCode implementation
        public override bool Equals(object obj)
		{
			var other = obj as WowObject;
			if (other == null)
				return false;
			
			//	WowObjects are equal if both their GUI and type are equal.  If only one of these is equal, chances
			//	are that the GUID is being recycled.  This is HIGHLY UNLIKELY to happen, but it is not technically
			//	impossible.
			return (GUID == other.GUID) && (Type == other.Type);
		}
        
		///<summary>
		/// Checks whether two <see cref="WowObject">WowObjects</see> are equal.  They are equal only if they have the
		/// same <see cref="BaseAddress"/>.
		///</summary>
		///<param name="lhs"></param>
		///<param name="rhs"></param>
		///<returns><c>true</c> if equal</returns>
		public static bool operator ==(WowObject lhs, WowObject rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
        
		///<summary>
		/// <see cref="WowObject"/> types are not equal they have different <see cref="BaseAddress"/> values.
		///</summary>
		///<param name="lhs"></param>
		///<param name="rhs"></param>
		///<returns><c>true</c> if not equal</returns>
		public static bool operator !=(WowObject lhs, WowObject rhs)
		{
			return !(lhs == rhs);
		}
        #endregion

        ///<summary>
        /// Checks if two <see cref="WowObject">WowObjects</see> are equal.
        ///</summary>
        ///<param name="other"></param>
        ///<returns></returns>
        public bool Equals(WowObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || other.BaseAddress.Equals(BaseAddress);
        }

        public override int GetHashCode()
        {
            return BaseAddress.GetHashCode();
        }
    }
}