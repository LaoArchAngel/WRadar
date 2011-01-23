using System.Diagnostics;
using BlackRain;
using BlackRain.Common;
using Magic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    /// <summary>
    ///This is a test class for ObjectManagerTest and is intended
    ///to contain all ObjectManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ObjectManagerTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            var process = Process.GetProcessesByName("Wow")[0];
            ObjectManager.Initialize(process);
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for Pulse
        ///</summary>
        [TestMethod]
        public void PulseTest()
        {
            ObjectManager.Pulse();
            Assert.AreNotEqual(ObjectManager.Me.BaseAddress, IntPtr.Zero);
        }
        
        [TestMethod]
        public void MeNameTest()
        {
            ObjectManager.Pulse();
            Assert.AreEqual("Lao", ObjectManager.Me.Name, true);
        }

        [TestMethod]
        public void BlackRainNameTest()
        {
            var memory = new BlackMagic(Process.GetProcessesByName("Wow")[0].Id);
            ObjectManager.Pulse();
            var guid = ObjectManager.Me.GUID;
            var nMask = ReadRelative<uint>((uint)Offsets.WowPlayer.NameStore + (uint)Offsets.WowPlayer.NameMask);
            var nBase = ReadRelative<uint>((uint)Offsets.WowPlayer.NameStore + (uint)Offsets.WowPlayer.NameBase);
            var nShortGUID = guid & 0xFFFFFFFF; // only need part of the GUID
            var nOffset = 0xC * (nMask & nShortGUID);
            var nCurrentObject = memory.ReadUInt((uint)(nBase + nOffset + 0x8));

            nOffset = memory.ReadUInt((uint)(nBase + nOffset));
            if ((nCurrentObject & 0x1) == 0x1)
                Assert.Fail();

            var nTestAgainstGUID = memory.ReadUInt((nCurrentObject));

            while (nTestAgainstGUID != nShortGUID)
            {
                nCurrentObject = memory.ReadUInt((uint)(nCurrentObject + nOffset + 0x4));
                if ((nCurrentObject & 0x1) == 0x1)
                    Assert.Fail();

                nTestAgainstGUID = memory.ReadUInt(nCurrentObject);
            }

            Assert.AreEqual("Lao", memory.ReadASCIIString(nCurrentObject + (uint)Offsets.WowPlayer.NameString, 40));
        }

        #region UtilityMethods
        
        public static uint MakeAbsolute(uint relativeAddress)
        {
            return relativeAddress + (uint)Process.GetProcessesByName("Wow")[0].MainModule.BaseAddress;
        }

        public static T ReadRelative<T>(uint address)
        {
            object ret;
            var t = typeof (T);
            var memory = new BlackMagic(Process.GetProcessesByName("Wow")[0].Id);

            switch (Type.GetTypeCode(typeof (T)))
            {

                case TypeCode.Int16:
                    ret = memory.ReadUShort(MakeAbsolute(address));
                    break;
                case TypeCode.Int32:
                    ret = memory.ReadInt(MakeAbsolute(address));
                    break;
                case TypeCode.Int64:
                    ret = memory.ReadInt64(MakeAbsolute(address));
                    break;
                case TypeCode.String:
                    ret = memory.ReadASCIIString(MakeAbsolute(address), 40);
                    break;
                case TypeCode.UInt16:
                    ret = memory.ReadUShort(MakeAbsolute(address));
                    break;
                case TypeCode.UInt32:
                    ret = memory.ReadUInt(MakeAbsolute(address));
                    break;
                case TypeCode.UInt64:
                    ret = memory.ReadUInt64(MakeAbsolute(address));
                    break;
                case TypeCode.Single:
                    ret = memory.ReadShort(MakeAbsolute(address));
                    break;
                case TypeCode.Byte:
                    ret = memory.ReadByte(MakeAbsolute(address));
                    break;
                case TypeCode.Object:
                    ret = memory.ReadObject(MakeAbsolute(address), t);
                    break;
                case TypeCode.Double:
                    ret = memory.ReadDouble(MakeAbsolute(address));
                    break;
                default:
                    throw new NotSupportedException(string.Format("Type {0} is not currently supported.",
                                                                  typeof (T).FullName));
            }

            return (T) ret;
        }

        #endregion
    }
}