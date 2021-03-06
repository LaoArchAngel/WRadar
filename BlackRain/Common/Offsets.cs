﻿namespace BlackRain.Common
{
    /// <summary>
    /// A collection of offsets used for memory reading and writing.
    /// </summary>
    public class Offsets
    {
        /// <summary>
        /// Memory locations specific to the ObjectManager.
        /// </summary>
        public enum ObjectManager : uint
        {
            ClientConnection = 0x980558,
            CurrentManager = 0x463C,
            LocalGUID = 0xB8,
            FirstObject = 0xB4,
            NextObject = 0x3C,
            ObjectType = 0x14
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
        /// Memory locations specific to the WowGameObject type.
        /// </summary>
        public enum WowGameObject : uint
        {
            ObjectCache = 0x1CC,
            ObjectNameCache = 0xB4,
        }

        /// <summary>
        /// Memory locations specific to the WowObject type.
        /// </summary>
        public enum WowObject : uint
        {
            X = 0x790,
            Y = X + 4,
            Z = X + 8,
            Facing = X + 0x10,
            Pitch = X + 0x14,
            GameObjectX = 0x110,
            GameObjectY = GameObjectX + 4,
            GameObjectZ = GameObjectX + 8,
            
        }

        /// <summary>
        /// Memory locations specific to the WowPlayer type.
        /// </summary>
        public enum WowPlayer : uint
        {
            NameStore = 0x959EE0 + 0x8,
            NameMask = 0x024,
            NameBase = 0x01c,
            NameString = 0x020
        }

        /// <summary>
        /// Memory locations specific to the WowPlayerMe type.
        /// </summary>
        public enum WowPlayerMe : uint
        {
            Zone = 0xA1DD74,
            SubZone = Zone - 0x4
        }

        public enum WowUnit : uint
        {
            UnitCache = 0x91C,
            UnitCacheNamePtr = 0x64,
        }
    }
}