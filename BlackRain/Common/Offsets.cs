﻿using System;

namespace BlackRain.Common
{
    /// <summary>
    /// A collection of offsets used for memory reading and writing.
    /// </summary>
    public class Offsets
    {
        /// <summary>
        /// Memory locations specific to the ObjectManager.
        /// </summary>
        public enum ObjectManager
        {
            Tls = 0x8B3F78,
            CurMgr = 0x462C,
            LocalGuid = 0xB8,
            FirstObject = 0xB4,
            NextObject = 0x3C,
        }

		/// <summary>
		/// Types available for a <see cref="WowObject"/>
		/// </summary>
		public enum ObjectType : uint
		{
			Object = 0,
			Item = 1,
			Container = 2,
			Unit = 3,
			Player = 4,
			GameObject = 5,
			DynamicObject = 6,
			Corpse = 7,
			AiGroup = 8,
			AreaTrigger = 9
		}

        /// <summary>
        /// Memory locations specific to the WowPlayer type.
        /// </summary>
        public enum WowPlayer: uint
        {
            NameStore = 0x88FA90 + 0x8,
            NameMask = 0x024,
            NameBase = 0x01c,
            NameString = 0x020 
        }

        /// <summary>
        /// Memory locations specific to the WowPlayerMe type.
        /// </summary>
        public enum WowPlayerMe: uint
        {
            Zone = 0x990690,
            SubZone = 0x99068C
        }

        /// <summary>
        /// Memory locations specific to the WowObject type.
        /// </summary>
        public enum WowObject : uint
        {
            X = 0x898,
            Y = 0x898 + 4,
            Z = 0x898 + 8,
            GameObjectX = 0x110,
            GameObjectY = 0x114,
            GameObjectZ = 0x118,
            Facing = 0x8A8,
        }

        /// <summary>
        /// Memory locations specific to the WowGameObject type.
        /// </summary>
        public enum WowGameObject : uint
        {
            Name1 = 0x1CC,
            Name2 = 0x94,
        }

        #region <Flags>

        [Flags]
        public enum ClassFlags : uint
        {
            None = 0,
            Warrior = 1,
            Paladin = 2,
            Hunter = 3,
            Rogue = 4,
            Priest = 5,
            DeathKnight = 6,
            Shaman = 7,
            Mage = 8,
            Warlock = 9,
            Druid = 11,
        }

        [Flags]
        public enum RaceFlags : uint
        {
            Human = 1,
            Orc,
            Dwarf,
            NightElf,
            Undead,
            Tauren,
            Gnome,
            Troll,
            Goblin,
            BloodElf,
            Draenei,
            FelOrc,
            Naga,
            Broken,
            Skeleton = 15,
        }

        [Flags]
        public enum CorpseFlags
        {
            CORPSE_FLAG_NONE = 0x00,
            CORPSE_FLAG_BONES = 0x01,
            CORPSE_FLAG_UNK1 = 0x02,
            CORPSE_FLAG_UNK2 = 0x04,
            CORPSE_FLAG_HIDE_HELM = 0x08,
            CORPSE_FLAG_HIDE_CLOAK = 0x10,
            CORPSE_FLAG_LOOTABLE = 0x20
        }

        [Flags]
        public enum UnitDynamicFlags
        {
            None = 0,
            Lootable = 0x1,
            TrackUnit = 0x2,
            TaggedByOther = 0x4,
            TaggedByMe = 0x8,
            SpecialInfo = 0x10,
            Dead = 0x20,
            ReferAFriendLinked = 0x40,
            IsTappedByAllThreatList = 0x80,
        }

        [Flags]
        public enum UnitFlags : uint
        {
            None = 0,
            Sitting = 0x1,
            //SelectableNotAttackable_1 = 0x2,
            Influenced = 0x4, // Stops movement packets
            PlayerControlled = 0x8, // 2.4.2
            Totem = 0x10,
            Preparation = 0x20, // 3.0.3
            PlusMob = 0x40, // 3.0.2
            //SelectableNotAttackable_2 = 0x80,
            NotAttackable = 0x100,
            //Flag_0x200 = 0x200,
            Looting = 0x400,
            PetInCombat = 0x800, // 3.0.2
            PvPFlagged = 0x1000,
            Silenced = 0x2000, //3.0.3
            //Flag_14_0x4000 = 0x4000,
            //Flag_15_0x8000 = 0x8000,
            //SelectableNotAttackable_3 = 0x10000,
            Pacified = 0x20000, //3.0.3
            Stunned = 0x40000,
            CanPerformActionMask1 = 0x60000,
            Combat = 0x80000, // 3.1.1
            TaxiFlight = 0x100000, // 3.1.1
            Disarmed = 0x200000, // 3.1.1
            Confused = 0x400000, //  3.0.3
            Fleeing = 0x800000,
            Possessed = 0x1000000, // 3.1.1
            NotSelectable = 0x2000000,
            Skinnable = 0x4000000,
            Mounted = 0x8000000,
            //Flag_28_0x10000000 = 0x10000000,
            Dazed = 0x20000000,
            Sheathe = 0x40000000,
            //Flag_31_0x80000000 = 0x80000000,
        }

        #endregion

        #region <Descriptors>

        public enum WowObjectFields
        {
            OBJECT_FIELD_GUID = 0x0,
            OBJECT_FIELD_TYPE = 0x2,
            OBJECT_FIELD_ENTRY = 0x3,
            OBJECT_FIELD_SCALE_X = 0x4,
            OBJECT_FIELD_DATA = 0x5,
            OBJECT_FIELD_PADDING = 0x7,
            //TOTAL_OBJECT_FIELDS = 0x6
        };

        public enum WowItemFields
        {
            ITEM_FIELD_OWNER = 0x8,
            ITEM_FIELD_CONTAINED = 0xA,
            ITEM_FIELD_CREATOR = 0xC,
            ITEM_FIELD_GIFTCREATOR = 0xE,
            ITEM_FIELD_STACK_COUNT = 0x10,
            ITEM_FIELD_DURATION = 0x11,
            ITEM_FIELD_SPELL_CHARGES = 0x12,
            ITEM_FIELD_FLAGS = 0x17,
            ITEM_FIELD_ENCHANTMENT_1_1 = 0x18,
            ITEM_FIELD_ENCHANTMENT_1_3 = 0x1A,
            ITEM_FIELD_ENCHANTMENT_2_1 = 0x1B,
            ITEM_FIELD_ENCHANTMENT_2_3 = 0x1D,
            ITEM_FIELD_ENCHANTMENT_3_1 = 0x1E,
            ITEM_FIELD_ENCHANTMENT_3_3 = 0x20,
            ITEM_FIELD_ENCHANTMENT_4_1 = 0x21,
            ITEM_FIELD_ENCHANTMENT_4_3 = 0x23,
            ITEM_FIELD_ENCHANTMENT_5_1 = 0x24,
            ITEM_FIELD_ENCHANTMENT_5_3 = 0x26,
            ITEM_FIELD_ENCHANTMENT_6_1 = 0x27,
            ITEM_FIELD_ENCHANTMENT_6_3 = 0x29,
            ITEM_FIELD_ENCHANTMENT_7_1 = 0x2A,
            ITEM_FIELD_ENCHANTMENT_7_3 = 0x2C,
            ITEM_FIELD_ENCHANTMENT_8_1 = 0x2D,
            ITEM_FIELD_ENCHANTMENT_8_3 = 0x2F,
            ITEM_FIELD_ENCHANTMENT_9_1 = 0x30,
            ITEM_FIELD_ENCHANTMENT_9_3 = 0x32,
            ITEM_FIELD_ENCHANTMENT_10_1 = 0x33,
            ITEM_FIELD_ENCHANTMENT_10_3 = 0x35,
            ITEM_FIELD_ENCHANTMENT_11_1 = 0x36,
            ITEM_FIELD_ENCHANTMENT_11_3 = 0x38,
            ITEM_FIELD_ENCHANTMENT_12_1 = 0x39,
            ITEM_FIELD_ENCHANTMENT_12_3 = 0x3B,
            ITEM_FIELD_ENCHANTMENT_13_1 = 0x3C,
            ITEM_FIELD_ENCHANTMENT_13_3 = 0x3E,
            ITEM_FIELD_ENCHANTMENT_14_1 = 0x3F,
            ITEM_FIELD_ENCHANTMENT_14_3 = 0x41,
            ITEM_FIELD_PROPERTY_SEED = 0x42,
            ITEM_FIELD_RANDOM_PROPERTIES_ID = 0x43,
            ITEM_FIELD_DURABILITY = 0x44,
            ITEM_FIELD_MAXDURABILITY = 0x45,
            ITEM_FIELD_CREATE_PLAYED_TIME = 0x46,
            ITEM_FIELD_PAD = 0x47,
            //TOTAL_ITEM_FIELDS = 0x2A
        };

        public enum WowContainerFields
        {
            CONTAINER_FIELD_NUM_SLOTS = 0x8,
            CONTAINER_ALIGN_PAD = 0x9,
            CONTAINER_FIELD_SLOT_1 = 0xA,
            //TOTAL_CONTAINER_FIELDS = 0x3  
        };

        public enum WowGameObjectFields
        {
            OBJECT_FIELD_CREATED_BY = 0x8,
            GAMEOBJECT_DISPLAYID = 0xA,
            GAMEOBJECT_FLAGS = 0xB,
            GAMEOBJECT_PARENTROTATION = 0xC,
            GAMEOBJECT_DYNAMIC = 0x10,
            GAMEOBJECT_FACTION = 0x11,
            GAMEOBJECT_LEVEL = 0x12,
            GAMEOBJECT_BYTES_1 = 0x13,
            //TOTAL_GAMEOBJECT_FIELDS = 0x8
        };

        public enum WowDynamicObjectFields
        {
            DYNAMICOBJECT_CASTER = 0x8,
            DYNAMICOBJECT_BYTES = 0xA,
            DYNAMICOBJECT_SPELLID = 0xB,
            DYNAMICOBJECT_RADIUS = 0xC,
            DYNAMICOBJECT_CASTTIME = 0xD,
            //TOTAL_DYNAMICOBJECT_FIELDS = 0x5
        }

        public enum WowCorpseFields
        {
            CORPSE_FIELD_OWNER = 0x8,
            CORPSE_FIELD_PARTY = 0xA,
            CORPSE_FIELD_DISPLAY_ID = 0xC,
            CORPSE_FIELD_ITEM = 0xD,
            CORPSE_FIELD_BYTES_1 = 0x20,
            CORPSE_FIELD_BYTES_2 = 0x21,
            CORPSE_FIELD_FLAGS = 0x22,
            CORPSE_FIELD_DYNAMIC_FLAGS = 0x23,
            //TOTAL_CORPSE_FIELDS = 0x8
        }

        public enum WowUnitFields
        {
            UNIT_FIELD_CHARM = 0x8,
            UNIT_FIELD_SUMMON = 0xA,
            UNIT_FIELD_CRITTER = 0xC,
            UNIT_FIELD_CHARMEDBY = 0xE,
            UNIT_FIELD_SUMMONEDBY = 0x10,
            UNIT_FIELD_CREATEDBY = 0x12,
            UNIT_FIELD_TARGET = 0x14,
            UNIT_FIELD_CHANNEL_OBJECT = 0x16,
            UNIT_CHANNEL_SPELL = 0x18,
            UNIT_FIELD_BYTES_0 = 0x19,
            UNIT_FIELD_HEALTH = 0x1A,
            UNIT_FIELD_POWER1 = 0x1B,
            UNIT_FIELD_POWER2 = 0x1C,
            UNIT_FIELD_POWER3 = 0x1D,
            UNIT_FIELD_POWER4 = 0x1E,
            UNIT_FIELD_POWER5 = 0x1F,
            UNIT_FIELD_POWER6 = 0x20,
            UNIT_FIELD_POWER7 = 0x21,
            UNIT_FIELD_POWER8 = 0x22,
            UNIT_FIELD_POWER9 = 0x23,
            UNIT_FIELD_POWER10 = 0x24,
            UNIT_FIELD_POWER11 = 0x25,
            UNIT_FIELD_MAXHEALTH = 0x26,
            UNIT_FIELD_MAXPOWER1 = 0x27,
            UNIT_FIELD_MAXPOWER2 = 0x28,
            UNIT_FIELD_MAXPOWER3 = 0x29,
            UNIT_FIELD_MAXPOWER4 = 0x2A,
            UNIT_FIELD_MAXPOWER5 = 0x2B,
            UNIT_FIELD_MAXPOWER6 = 0x2C,
            UNIT_FIELD_MAXPOWER7 = 0x2D,
            UNIT_FIELD_MAXPOWER8 = 0x2E,
            UNIT_FIELD_MAXPOWER9 = 0x2F,
            UNIT_FIELD_MAXPOWER10 = 0x30,
            UNIT_FIELD_MAXPOWER11 = 0x31,
            UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER = 0x32,
            UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = 0x3D,
            UNIT_FIELD_LEVEL = 0x48,
            UNIT_FIELD_FACTIONTEMPLATE = 0x49,
            UNIT_VIRTUAL_ITEM_SLOT_ID = 0x4A,
            UNIT_FIELD_FLAGS = 0x4D,
            UNIT_FIELD_FLAGS_2 = 0x4E,
            UNIT_FIELD_AURASTATE = 0x4F,
            UNIT_FIELD_BASEATTACKTIME = 0x50,
            UNIT_FIELD_RANGEDATTACKTIME = 0x52,
            UNIT_FIELD_BOUNDINGRADIUS = 0x53,
            UNIT_FIELD_COMBATREACH = 0x54,
            UNIT_FIELD_DISPLAYID = 0x55,
            UNIT_FIELD_NATIVEDISPLAYID = 0x56,
            UNIT_FIELD_MOUNTDISPLAYID = 0x57,
            UNIT_FIELD_MINDAMAGE = 0x58,
            UNIT_FIELD_MAXDAMAGE = 0x59,
            UNIT_FIELD_MINOFFHANDDAMAGE = 0x5A,
            UNIT_FIELD_MAXOFFHANDDAMAGE = 0x5B,
            UNIT_FIELD_BYTES_1 = 0x5C,
            UNIT_FIELD_PETNUMBER = 0x5D,
            UNIT_FIELD_PET_NAME_TIMESTAMP = 0x5E,
            UNIT_FIELD_PETEXPERIENCE = 0x5F,
            UNIT_FIELD_PETNEXTLEVELEXP = 0x60,
            UNIT_DYNAMIC_FLAGS = 0x61,
            UNIT_MOD_CAST_SPEED = 0x62,
            UNIT_CREATED_BY_SPELL = 0x63,
            UNIT_NPC_FLAGS = 0x64,
            UNIT_NPC_EMOTESTATE = 0x65,
            UNIT_FIELD_STAT0 = 0x66,
            UNIT_FIELD_STAT1 = 0x67,
            UNIT_FIELD_STAT2 = 0x68,
            UNIT_FIELD_STAT3 = 0x69,
            UNIT_FIELD_STAT4 = 0x6A,
            UNIT_FIELD_POSSTAT0 = 0x6B,
            UNIT_FIELD_POSSTAT1 = 0x6C,
            UNIT_FIELD_POSSTAT2 = 0x6D,
            UNIT_FIELD_POSSTAT3 = 0x6E,
            UNIT_FIELD_POSSTAT4 = 0x6F,
            UNIT_FIELD_NEGSTAT0 = 0x70,
            UNIT_FIELD_NEGSTAT1 = 0x71,
            UNIT_FIELD_NEGSTAT2 = 0x72,
            UNIT_FIELD_NEGSTAT3 = 0x73,
            UNIT_FIELD_NEGSTAT4 = 0x74,
            UNIT_FIELD_RESISTANCES = 0x75,
            UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE = 0x7C,
            UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE = 0x83,
            UNIT_FIELD_BASE_MANA = 0x8A,
            UNIT_FIELD_BASE_HEALTH = 0x8B,
            UNIT_FIELD_BYTES_2 = 0x8C,
            UNIT_FIELD_ATTACK_POWER = 0x8D,
            UNIT_FIELD_ATTACK_POWER_MOD_POS = 0x8E,
            UNIT_FIELD_ATTACK_POWER_MOD_NEG = 0x8F,
            UNIT_FIELD_ATTACK_POWER_MULTIPLIER = 0x90,
            UNIT_FIELD_RANGED_ATTACK_POWER = 0x91,
            UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS = 0x92,
            UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG = 0x93,
            UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER = 0x94,
            UNIT_FIELD_MINRANGEDDAMAGE = 0x95,
            UNIT_FIELD_MAXRANGEDDAMAGE = 0x96,
            UNIT_FIELD_POWER_COST_MODIFIER = 0x97,
            UNIT_FIELD_POWER_COST_MULTIPLIER = 0x9E,
            UNIT_FIELD_MAXHEALTHMODIFIER = 0xA5,
            UNIT_FIELD_HOVERHEIGHT = 0xA6,
            UNIT_FIELD_MAXITEMLEVEL = 0xA7,
            //TOTAL_UNIT_FIELDS = 0x63
        };

        public enum WowPlayerFields
        {
            PLAYER_DUEL_ARBITER = 0xA8,
            PLAYER_FLAGS = 0xAA,
            PLAYER_GUILDRANK = 0xAB,
            PLAYER_GUILDDELETE_DATE = 0xAC,
            PLAYER_GUILDLEVEL = 0xAD,
            PLAYER_BYTES = 0xAE,
            PLAYER_BYTES_2 = 0xAF,
            PLAYER_BYTES_3 = 0xB0,
            PLAYER_DUEL_TEAM = 0xB1,
            PLAYER_GUILD_TIMESTAMP = 0xB2,
            PLAYER_QUEST_LOG_1_1 = 0xB3,
            PLAYER_QUEST_LOG_1_2 = 0xB4,
            PLAYER_QUEST_LOG_1_3 = 0xB5,
            PLAYER_QUEST_LOG_1_4 = 0xB7,
            PLAYER_QUEST_LOG_2_1 = 0xB8,
            PLAYER_QUEST_LOG_2_2 = 0xB9,
            PLAYER_QUEST_LOG_2_3 = 0xBA,
            PLAYER_QUEST_LOG_2_5 = 0xBC,
            PLAYER_QUEST_LOG_3_1 = 0xBD,
            PLAYER_QUEST_LOG_3_2 = 0xBE,
            PLAYER_QUEST_LOG_3_3 = 0xBF,
            PLAYER_QUEST_LOG_3_5 = 0xC1,
            PLAYER_QUEST_LOG_4_1 = 0xC2,
            PLAYER_QUEST_LOG_4_2 = 0xC3,
            PLAYER_QUEST_LOG_4_3 = 0xC4,
            PLAYER_QUEST_LOG_4_5 = 0xC6,
            PLAYER_QUEST_LOG_5_1 = 0xC7,
            PLAYER_QUEST_LOG_5_2 = 0xC8,
            PLAYER_QUEST_LOG_5_3 = 0xC9,
            PLAYER_QUEST_LOG_5_5 = 0xCB,
            PLAYER_QUEST_LOG_6_1 = 0xCC,
            PLAYER_QUEST_LOG_6_2 = 0xCD,
            PLAYER_QUEST_LOG_6_3 = 0xCE,
            PLAYER_QUEST_LOG_6_5 = 0xD0,
            PLAYER_QUEST_LOG_7_1 = 0xD1,
            PLAYER_QUEST_LOG_7_2 = 0xD2,
            PLAYER_QUEST_LOG_7_3 = 0xD3,
            PLAYER_QUEST_LOG_7_5 = 0xD5,
            PLAYER_QUEST_LOG_8_1 = 0xD6,
            PLAYER_QUEST_LOG_8_2 = 0xD7,
            PLAYER_QUEST_LOG_8_3 = 0xD8,
            PLAYER_QUEST_LOG_8_5 = 0xDA,
            PLAYER_QUEST_LOG_9_1 = 0xDB,
            PLAYER_QUEST_LOG_9_2 = 0xDC,
            PLAYER_QUEST_LOG_9_3 = 0xDD,
            PLAYER_QUEST_LOG_9_5 = 0xDF,
            PLAYER_QUEST_LOG_10_1 = 0xE0,
            PLAYER_QUEST_LOG_10_2 = 0xE1,
            PLAYER_QUEST_LOG_10_3 = 0xE2,
            PLAYER_QUEST_LOG_10_5 = 0xE4,
            PLAYER_QUEST_LOG_11_1 = 0xE5,
            PLAYER_QUEST_LOG_11_2 = 0xE6,
            PLAYER_QUEST_LOG_11_3 = 0xE7,
            PLAYER_QUEST_LOG_11_5 = 0xE9,
            PLAYER_QUEST_LOG_12_1 = 0xEA,
            PLAYER_QUEST_LOG_12_2 = 0xEB,
            PLAYER_QUEST_LOG_12_3 = 0xEC,
            PLAYER_QUEST_LOG_12_5 = 0xEE,
            PLAYER_QUEST_LOG_13_1 = 0xEF,
            PLAYER_QUEST_LOG_13_2 = 0xF0,
            PLAYER_QUEST_LOG_13_3 = 0xF1,
            PLAYER_QUEST_LOG_13_5 = 0xF3,
            PLAYER_QUEST_LOG_14_1 = 0xF4,
            PLAYER_QUEST_LOG_14_2 = 0xF5,
            PLAYER_QUEST_LOG_14_3 = 0xF6,
            PLAYER_QUEST_LOG_14_5 = 0xF8,
            PLAYER_QUEST_LOG_15_1 = 0xF9,
            PLAYER_QUEST_LOG_15_2 = 0xFA,
            PLAYER_QUEST_LOG_15_3 = 0xFB,
            PLAYER_QUEST_LOG_15_5 = 0xFD,
            PLAYER_QUEST_LOG_16_1 = 0xFE,
            PLAYER_QUEST_LOG_16_2 = 0xFF,
            PLAYER_QUEST_LOG_16_3 = 0x100,
            PLAYER_QUEST_LOG_16_5 = 0x102,
            PLAYER_QUEST_LOG_17_1 = 0x103,
            PLAYER_QUEST_LOG_17_2 = 0x104,
            PLAYER_QUEST_LOG_17_3 = 0x105,
            PLAYER_QUEST_LOG_17_5 = 0x107,
            PLAYER_QUEST_LOG_18_1 = 0x108,
            PLAYER_QUEST_LOG_18_2 = 0x109,
            PLAYER_QUEST_LOG_18_3 = 0x10A,
            PLAYER_QUEST_LOG_18_5 = 0x10C,
            PLAYER_QUEST_LOG_19_1 = 0x10D,
            PLAYER_QUEST_LOG_19_2 = 0x10E,
            PLAYER_QUEST_LOG_19_3 = 0x10F,
            PLAYER_QUEST_LOG_19_5 = 0x111,
            PLAYER_QUEST_LOG_20_1 = 0x112,
            PLAYER_QUEST_LOG_20_2 = 0x113,
            PLAYER_QUEST_LOG_20_3 = 0x114,
            PLAYER_QUEST_LOG_20_5 = 0x116,
            PLAYER_QUEST_LOG_21_1 = 0x117,
            PLAYER_QUEST_LOG_21_2 = 0x118,
            PLAYER_QUEST_LOG_21_3 = 0x119,
            PLAYER_QUEST_LOG_21_5 = 0x11B,
            PLAYER_QUEST_LOG_22_1 = 0x11C,
            PLAYER_QUEST_LOG_22_2 = 0x11D,
            PLAYER_QUEST_LOG_22_3 = 0x11E,
            PLAYER_QUEST_LOG_22_5 = 0x120,
            PLAYER_QUEST_LOG_23_1 = 0x121,
            PLAYER_QUEST_LOG_23_2 = 0x122,
            PLAYER_QUEST_LOG_23_3 = 0x123,
            PLAYER_QUEST_LOG_23_5 = 0x125,
            PLAYER_QUEST_LOG_24_1 = 0x126,
            PLAYER_QUEST_LOG_24_2 = 0x127,
            PLAYER_QUEST_LOG_24_3 = 0x128,
            PLAYER_QUEST_LOG_24_5 = 0x12A,
            PLAYER_QUEST_LOG_25_1 = 0x12B,
            PLAYER_QUEST_LOG_25_2 = 0x12C,
            PLAYER_QUEST_LOG_25_3 = 0x12D,
            PLAYER_QUEST_LOG_25_5 = 0x12F,
            PLAYER_QUEST_LOG_26_1 = 0x130,
            PLAYER_QUEST_LOG_26_2 = 0x131,
            PLAYER_QUEST_LOG_26_3 = 0x132,
            PLAYER_QUEST_LOG_26_5 = 0x134,
            PLAYER_QUEST_LOG_27_1 = 0x135,
            PLAYER_QUEST_LOG_27_2 = 0x136,
            PLAYER_QUEST_LOG_27_3 = 0x137,
            PLAYER_QUEST_LOG_27_5 = 0x139,
            PLAYER_QUEST_LOG_28_1 = 0x13A,
            PLAYER_QUEST_LOG_28_2 = 0x13B,
            PLAYER_QUEST_LOG_28_3 = 0x13C,
            PLAYER_QUEST_LOG_28_5 = 0x13E,
            PLAYER_QUEST_LOG_29_1 = 0x13F,
            PLAYER_QUEST_LOG_29_2 = 0x140,
            PLAYER_QUEST_LOG_29_3 = 0x141,
            PLAYER_QUEST_LOG_29_5 = 0x143,
            PLAYER_QUEST_LOG_30_1 = 0x144,
            PLAYER_QUEST_LOG_30_2 = 0x145,
            PLAYER_QUEST_LOG_30_3 = 0x146,
            PLAYER_QUEST_LOG_30_5 = 0x148,
            PLAYER_QUEST_LOG_31_1 = 0x149,
            PLAYER_QUEST_LOG_31_2 = 0x14A,
            PLAYER_QUEST_LOG_31_3 = 0x14B,
            PLAYER_QUEST_LOG_31_5 = 0x14D,
            PLAYER_QUEST_LOG_32_1 = 0x14E,
            PLAYER_QUEST_LOG_32_2 = 0x14F,
            PLAYER_QUEST_LOG_32_3 = 0x150,
            PLAYER_QUEST_LOG_32_5 = 0x152,
            PLAYER_QUEST_LOG_33_1 = 0x153,
            PLAYER_QUEST_LOG_33_2 = 0x154,
            PLAYER_QUEST_LOG_33_3 = 0x155,
            PLAYER_QUEST_LOG_33_5 = 0x157,
            PLAYER_QUEST_LOG_34_1 = 0x158,
            PLAYER_QUEST_LOG_34_2 = 0x159,
            PLAYER_QUEST_LOG_34_3 = 0x15A,
            PLAYER_QUEST_LOG_34_5 = 0x15C,
            PLAYER_QUEST_LOG_35_1 = 0x15D,
            PLAYER_QUEST_LOG_35_2 = 0x15E,
            PLAYER_QUEST_LOG_35_3 = 0x15F,
            PLAYER_QUEST_LOG_35_5 = 0x161,
            PLAYER_QUEST_LOG_36_1 = 0x162,
            PLAYER_QUEST_LOG_36_2 = 0x163,
            PLAYER_QUEST_LOG_36_3 = 0x164,
            PLAYER_QUEST_LOG_36_5 = 0x166,
            PLAYER_QUEST_LOG_37_1 = 0x167,
            PLAYER_QUEST_LOG_37_2 = 0x168,
            PLAYER_QUEST_LOG_37_3 = 0x169,
            PLAYER_QUEST_LOG_37_5 = 0x16B,
            PLAYER_QUEST_LOG_38_1 = 0x16C,
            PLAYER_QUEST_LOG_38_2 = 0x16D,
            PLAYER_QUEST_LOG_38_3 = 0x16E,
            PLAYER_QUEST_LOG_38_5 = 0x170,
            PLAYER_QUEST_LOG_39_1 = 0x171,
            PLAYER_QUEST_LOG_39_2 = 0x172,
            PLAYER_QUEST_LOG_39_3 = 0x173,
            PLAYER_QUEST_LOG_39_5 = 0x175,
            PLAYER_QUEST_LOG_40_1 = 0x176,
            PLAYER_QUEST_LOG_40_2 = 0x177,
            PLAYER_QUEST_LOG_40_3 = 0x178,
            PLAYER_QUEST_LOG_40_5 = 0x17A,
            PLAYER_QUEST_LOG_41_1 = 0x17B,
            PLAYER_QUEST_LOG_41_2 = 0x17C,
            PLAYER_QUEST_LOG_41_3 = 0x17D,
            PLAYER_QUEST_LOG_41_5 = 0x17F,
            PLAYER_QUEST_LOG_42_1 = 0x180,
            PLAYER_QUEST_LOG_42_2 = 0x181,
            PLAYER_QUEST_LOG_42_3 = 0x182,
            PLAYER_QUEST_LOG_42_5 = 0x184,
            PLAYER_QUEST_LOG_43_1 = 0x185,
            PLAYER_QUEST_LOG_43_2 = 0x186,
            PLAYER_QUEST_LOG_43_3 = 0x187,
            PLAYER_QUEST_LOG_43_5 = 0x189,
            PLAYER_QUEST_LOG_44_1 = 0x18A,
            PLAYER_QUEST_LOG_44_2 = 0x18B,
            PLAYER_QUEST_LOG_44_3 = 0x18C,
            PLAYER_QUEST_LOG_44_5 = 0x18E,
            PLAYER_QUEST_LOG_45_1 = 0x18F,
            PLAYER_QUEST_LOG_45_2 = 0x190,
            PLAYER_QUEST_LOG_45_3 = 0x191,
            PLAYER_QUEST_LOG_45_5 = 0x193,
            PLAYER_QUEST_LOG_46_1 = 0x194,
            PLAYER_QUEST_LOG_46_2 = 0x195,
            PLAYER_QUEST_LOG_46_3 = 0x196,
            PLAYER_QUEST_LOG_46_5 = 0x198,
            PLAYER_QUEST_LOG_47_1 = 0x199,
            PLAYER_QUEST_LOG_47_2 = 0x19A,
            PLAYER_QUEST_LOG_47_3 = 0x19B,
            PLAYER_QUEST_LOG_47_5 = 0x19D,
            PLAYER_QUEST_LOG_48_1 = 0x19E,
            PLAYER_QUEST_LOG_48_2 = 0x19F,
            PLAYER_QUEST_LOG_48_3 = 0x1A0,
            PLAYER_QUEST_LOG_48_5 = 0x1A2,
            PLAYER_QUEST_LOG_49_1 = 0x1A3,
            PLAYER_QUEST_LOG_49_2 = 0x1A4,
            PLAYER_QUEST_LOG_49_3 = 0x1A5,
            PLAYER_QUEST_LOG_49_5 = 0x1A7,
            PLAYER_QUEST_LOG_50_1 = 0x1A8,
            PLAYER_QUEST_LOG_50_2 = 0x1A9,
            PLAYER_QUEST_LOG_50_3 = 0x1AA,
            PLAYER_QUEST_LOG_50_5 = 0x1AC,
            PLAYER_VISIBLE_ITEM_1_ENTRYID = 0x1AD,
            PLAYER_VISIBLE_ITEM_1_ENCHANTMENT = 0x1AE,
            PLAYER_VISIBLE_ITEM_2_ENTRYID = 0x1AF,
            PLAYER_VISIBLE_ITEM_2_ENCHANTMENT = 0x1B0,
            PLAYER_VISIBLE_ITEM_3_ENTRYID = 0x1B1,
            PLAYER_VISIBLE_ITEM_3_ENCHANTMENT = 0x1B2,
            PLAYER_VISIBLE_ITEM_4_ENTRYID = 0x1B3,
            PLAYER_VISIBLE_ITEM_4_ENCHANTMENT = 0x1B4,
            PLAYER_VISIBLE_ITEM_5_ENTRYID = 0x1B5,
            PLAYER_VISIBLE_ITEM_5_ENCHANTMENT = 0x1B6,
            PLAYER_VISIBLE_ITEM_6_ENTRYID = 0x1B7,
            PLAYER_VISIBLE_ITEM_6_ENCHANTMENT = 0x1B8,
            PLAYER_VISIBLE_ITEM_7_ENTRYID = 0x1B9,
            PLAYER_VISIBLE_ITEM_7_ENCHANTMENT = 0x1BA,
            PLAYER_VISIBLE_ITEM_8_ENTRYID = 0x1BB,
            PLAYER_VISIBLE_ITEM_8_ENCHANTMENT = 0x1BC,
            PLAYER_VISIBLE_ITEM_9_ENTRYID = 0x1BD,
            PLAYER_VISIBLE_ITEM_9_ENCHANTMENT = 0x1BE,
            PLAYER_VISIBLE_ITEM_10_ENTRYID = 0x1BF,
            PLAYER_VISIBLE_ITEM_10_ENCHANTMENT = 0x1C0,
            PLAYER_VISIBLE_ITEM_11_ENTRYID = 0x1C1,
            PLAYER_VISIBLE_ITEM_11_ENCHANTMENT = 0x1C2,
            PLAYER_VISIBLE_ITEM_12_ENTRYID = 0x1C3,
            PLAYER_VISIBLE_ITEM_12_ENCHANTMENT = 0x1C4,
            PLAYER_VISIBLE_ITEM_13_ENTRYID = 0x1C5,
            PLAYER_VISIBLE_ITEM_13_ENCHANTMENT = 0x1C6,
            PLAYER_VISIBLE_ITEM_14_ENTRYID = 0x1C7,
            PLAYER_VISIBLE_ITEM_14_ENCHANTMENT = 0x1C8,
            PLAYER_VISIBLE_ITEM_15_ENTRYID = 0x1C9,
            PLAYER_VISIBLE_ITEM_15_ENCHANTMENT = 0x1CA,
            PLAYER_VISIBLE_ITEM_16_ENTRYID = 0x1CB,
            PLAYER_VISIBLE_ITEM_16_ENCHANTMENT = 0x1CC,
            PLAYER_VISIBLE_ITEM_17_ENTRYID = 0x1CD,
            PLAYER_VISIBLE_ITEM_17_ENCHANTMENT = 0x1CE,
            PLAYER_VISIBLE_ITEM_18_ENTRYID = 0x1CF,
            PLAYER_VISIBLE_ITEM_18_ENCHANTMENT = 0x1D0,
            PLAYER_VISIBLE_ITEM_19_ENTRYID = 0x1D1,
            PLAYER_VISIBLE_ITEM_19_ENCHANTMENT = 0x1D2,
            PLAYER_CHOSEN_TITLE = 0x1D3,
            PLAYER_FAKE_INEBRIATION = 0x1D4,
            PLAYER_FIELD_PAD_0 = 0x1D5,
            PLAYER_FIELD_INV_SLOT_HEAD = 0x1D6,
            PLAYER_FIELD_PACK_SLOT_1 = 0x204,
            PLAYER_FIELD_BANK_SLOT_1 = 0x224,
            PLAYER_FIELD_BANKBAG_SLOT_1 = 0x25C,
            PLAYER_FIELD_VENDORBUYBACK_SLOT_1 = 0x26A,
            PLAYER_FIELD_KEYRING_SLOT_1 = 0x282,
            PLAYER_FARSIGHT = 0x2C2,
            PLAYER__FIELD_KNOWN_TITLES = 0x2C4,
            PLAYER__FIELD_KNOWN_TITLES1 = 0x2C6,
            PLAYER__FIELD_KNOWN_TITLES2 = 0x2C8,
            PLAYER_XP = 0x2CA,
            PLAYER_NEXT_LEVEL_XP = 0x2CB,
            PLAYER_SKILL_INFO_1_1 = 0x2CC,
            PLAYER_CHARACTER_POINTS = 0x44C,
            PLAYER_TRACK_CREATURES = 0x44D,
            PLAYER_TRACK_RESOURCES = 0x44E,
            PLAYER_BLOCK_PERCENTAGE = 0x44F,
            PLAYER_DODGE_PERCENTAGE = 0x450,
            PLAYER_PARRY_PERCENTAGE = 0x451,
            PLAYER_EXPERTISE = 0x452,
            PLAYER_OFFHAND_EXPERTISE = 0x453,
            PLAYER_CRIT_PERCENTAGE = 0x454,
            PLAYER_RANGED_CRIT_PERCENTAGE = 0x455,
            PLAYER_OFFHAND_CRIT_PERCENTAGE = 0x456,
            PLAYER_SPELL_CRIT_PERCENTAGE1 = 0x457,
            PLAYER_SHIELD_BLOCK = 0x45E,
            PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE = 0x45F,
            PLAYER_MASTERY = 0x460,
            PLAYER_EXPLORED_ZONES_1 = 0x461,
            PLAYER_REST_STATE_EXPERIENCE = 0x4F1,
            PLAYER_FIELD_COINAGE = 0x4F2,
            PLAYER_FIELD_MOD_DAMAGE_DONE_POS = 0x4F4,
            PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = 0x4FB,
            PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = 0x502,
            PLAYER_FIELD_MOD_HEALING_DONE_POS = 0x509,
            PLAYER_FIELD_MOD_HEALING_PCT = 0x50A,
            PLAYER_FIELD_MOD_HEALING_DONE_PCT = 0x50B,
            PLAYER_FIELD_MOD_SPELL_POWER_PCT = 0x50C,
            PLAYER_FIELD_MOD_TARGET_RESISTANCE = 0x50D,
            PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE = 0x50E,
            PLAYER_FIELD_BYTES = 0x50F,
            PLAYER_SELF_RES_SPELL = 0x510,
            PLAYER_FIELD_PVP_MEDALS = 0x511,
            PLAYER_FIELD_BUYBACK_PRICE_1 = 0x512,
            PLAYER_FIELD_BUYBACK_TIMESTAMP_1 = 0x51E,
            PLAYER_FIELD_KILLS = 0x52A,
            PLAYER_FIELD_LIFETIME_HONORBALE_KILLS = 0x52B,
            PLAYER_FIELD_BYTES2 = 0x52C,
            PLAYER_FIELD_WATCHED_FACTION_INDEX = 0x52D,
            PLAYER_FIELD_COMBAT_RATING_1 = 0x52E,
            PLAYER_FIELD_ARENA_TEAM_INFO_1_1 = 0x548,
            PLAYER_FIELD_BATTLEGROUND_RATING = 0x55D,
            PLAYER_FIELD_MAX_LEVEL = 0x55E,
            PLAYER_FIELD_DAILY_QUESTS_1 = 0x55F,
            PLAYER_RUNE_REGEN_1 = 0x578,
            PLAYER_NO_REAGENT_COST_1 = 0x57C,
            PLAYER_FIELD_GLYPH_SLOTS_1 = 0x57F,
            PLAYER_FIELD_GLYPHS_1 = 0x588,
            PLAYER_GLYPHS_ENABLED = 0x591,
            PLAYER_PET_SPELL_POWER = 0x592,
            PLAYER_FIELD_RESEARCHING_1 = 0x593,
            PLAYER_FIELD_RESERACH_SITE_1 = 0x59B,
            PLAYER_PROFESSION_SKILL_LINE_1 = 0x5A3,
            PLAYER_FIELD_UI_HIT_MODIFIER = 0x5A5,
            PLAYER_FIELD_UI_SPELL_HIT_MODIFIER = 0x5A6,
            PLAYER_FIELD_HOME_REALM_TIME_OFFSET = 0x5A7,
            //TOTAL_PLAYER_FIELDS = 0x13D
        };

        #endregion

    }
}
