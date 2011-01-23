using System;
using BlackRain.Common;

namespace BlackRain.WowObjects
{
    /// <summary>
    /// Player corpses.
    /// </summary>
    public class WowCorpse : WowUnit
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowCorpse(IntPtr baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The corpse's owner.
        /// </summary>
        public ulong Owner
        {
            get { return GetStorageField<ulong>((uint) Descriptors.WowCorpseFields.CORPSE_FIELD_OWNER); }
        }

        /// <summary>
        /// The Corpses Display ID.
        /// </summary>
        public override int DisplayId
        {
            get { return GetStorageField<int>((uint) Descriptors.WowCorpseFields.CORPSE_FIELD_DISPLAY_ID); }
        }
    }
}