using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;

namespace Biblioteka.Tests
{
    [TestClass()]
    public class ClassLibraryTests
    {
        ClassLibrary cl = new ClassLibrary();

        [TestMethod()]
        public void IsBatteryNameEqualTest()
        {
            string batteryName = @"ACPI\PNP0C0A\0_0";

            Assert.AreEqual(batteryName, cl.BatteryName);
        }

        [TestMethod()]
        public void IsTagNotEqualTest()
        {
            int tag = 0;

            Assert.AreNotEqual(tag, cl.Tag);
        }

        [TestMethod()]
        public void IsVoltageNotEqualTest()
        {
            int voltage = 0;

            Assert.AreNotEqual(voltage, cl.Voltage);
        }

        [TestMethod()]
        public void IsRemainingCapacityNotEqualTest()
        {
            int remainingCapacity = 0;

            Assert.AreNotEqual(remainingCapacity, cl.RemainingCapacity);
        }
    }
}
