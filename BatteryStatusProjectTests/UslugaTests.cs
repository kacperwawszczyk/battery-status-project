using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usluga;

namespace Usluga.Tests
{
    [TestClass()]
    public class UslugaTests
    {
        [TestMethod()]
        public void IsSourceEqualTest()
        {
            string zrodlo = "Usluga";

            Assert.AreEqual(zrodlo, ConfigurationManager.AppSettings["Zrodlo"]);
        }

        [TestMethod()]
        public void IsEventLogEqualTest()
        {
            string dziennik = "Dziennik stanu baterii";

            Assert.AreEqual(dziennik, ConfigurationManager.AppSettings["Dziennik"]);
        }
    }
}
