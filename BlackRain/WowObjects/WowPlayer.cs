using System;
using BlackRain.Common;
using MemoryIO;

namespace BlackRain.WowObjects
{
    /// <summary>
    /// Represents a player.
    /// </summary>
    public class WowPlayer : WowUnit
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowPlayer(IntPtr baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The player's experience points.
        /// </summary>
        public int Experience
        {
            get { return GetStorageField<int>((uint) Descriptors.WowPlayerFields.PLAYER_XP); }
        }

        /// <summary>
        /// The experience the player requires to advance to the next level.
        /// </summary>
        public int NextLevel
        {
            get { return GetStorageField<int>((uint) Descriptors.WowPlayerFields.PLAYER_NEXT_LEVEL_XP); }
        }

        /// <summary>
        /// The ID of the guild the player resides in.
        /// </summary>
        public int GuildId
        {
            get { return /*GetStorageField<int>((uint)Offsets.WowPlayerFields.PLAYER_GUILDID)*/ 0; }
        }

        /// <summary>
        /// The amount of experience the player has rested.
        /// <!-- You can calculate the double experience rate, and thus shorten the time to the next level when using this in a calculation. -->
        /// </summary>
        public int RestExperience
        {
            get { return GetStorageField<int>((uint) Descriptors.WowPlayerFields.PLAYER_REST_STATE_EXPERIENCE); }
        }

        /// <summary>
        /// Determines if the player is a Ghost. i.e: dead, and released from corpse.
        /// </summary>
        public bool Ghost
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true if in combat, false if not.
        /// </summary>
        public bool Combat
        {
            get { return HasUnitFlag(Flags.Unit.Combat); }
        }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public override string Name
        {
            get
            {
                try
                {
                    var nMask =
                        Memory.ReadRelative<uint>((IntPtr) ((uint) Offsets.WowPlayer.NameStore +
                                                            (uint) Offsets.WowPlayer.NameMask));
                    var nBase =
                        Memory.ReadRelative<IntPtr>((IntPtr) ((uint) Offsets.WowPlayer.NameStore +
                                                              (uint) Offsets.WowPlayer.NameBase));

                    var nShortGUID = (uint) (GUID & 0xFFFFFFFF); // only need part of the GUID
                    var nOffset = 0xC*(nMask & nShortGUID);

                    var nCurrentObject = Memory.ReadAtOffset<IntPtr>(nBase, nOffset + 0x8);
                    nOffset = Memory.ReadAtOffset<uint>(nBase, nOffset);

                    if (((uint) nCurrentObject & 0x1) == 0x1)
                        return "Unknown Player";

                    var nTestAgainstGUID = Memory.Read<uint>(nCurrentObject);

                    while (nTestAgainstGUID != nShortGUID)
                    {
                        nCurrentObject = Memory.ReadAtOffset<IntPtr>(nCurrentObject, nOffset + 0x4);

                        if (((uint) nCurrentObject & 0x1) == 0x1)
                            return "Unknown Player";

                        nTestAgainstGUID = Memory.Read<uint>(nCurrentObject);
                    }

                    return Memory.ReadAtOffset<string>(nCurrentObject, (uint) Offsets.WowPlayer.NameString);
                }
                catch (Exception x)
                {
                	Utilities.Log.Error(x);
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Returns true if the unit is mounted, false if not.
        /// </summary>
        public bool Mounted
        {
            get { return MountDisplayId > 0; }
        }
    }
}