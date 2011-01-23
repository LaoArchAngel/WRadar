using System;
using BlackRain.Common;

namespace BlackRain.WowObjects
{
    /// <summary>
    /// A Dynamic Object, such as Death and Decay.
    /// </summary>
    public class WowDynamicObject : WowObject
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowDynamicObject(IntPtr baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The GUID of the DynamicObject's caster.
        /// </summary>
        public ulong Caster
        {
            get { return GetStorageField<ulong>((uint) Descriptors.WowDynamicObjectFields.DYNAMICOBJECT_CASTER); }
        }

        /// <summary>
        /// The ID of the spell of which the DynamicObject consists.
        /// </summary>
        public int SpellID
        {
            get { return GetStorageField<int>((uint) Descriptors.WowDynamicObjectFields.DYNAMICOBJECT_SPELLID); }
        }

        /// <summary>
        /// The radius of the dynamic object.
        /// </summary>
        public int Radius
        {
            get { return GetStorageField<int>((uint) Descriptors.WowDynamicObjectFields.DYNAMICOBJECT_RADIUS); }
        }
    }
}