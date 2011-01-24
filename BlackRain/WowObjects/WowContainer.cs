using System;
using BlackRain.Common;

namespace BlackRain.WowObjects
{
    /// <summary>
    /// Contains information about WowContainers.
    /// </summary>
    public class WowContainer : WowObject
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowContainer(IntPtr baseAddress)
            : base(baseAddress) { }

        /// <summary>
        /// The amount of slots this container has.
        /// </summary>
        public int Slots
        {
            get { return GetStorageField<int>((uint)Descriptors.WowContainerFields.CONTAINER_FIELD_NUM_SLOTS); }
        }

        /// <summary>
        /// The slot this container occupies on the character.
        /// </summary>
        public int InSlot
        {
            get { return GetStorageField<int>((uint)Descriptors.WowContainerFields.CONTAINER_FIELD_SLOT_1); }
        }
    }
}
