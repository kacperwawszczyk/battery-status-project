using Microsoft.VisualStudio.TestTools.UnitTesting;
using BatteryStatusProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryStatusProject.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void IsEventLogNotNullTest()
        {
            MainWindow mw = new MainWindow();
            
            Assert.IsNotNull(mw.dziennik);
        }
    }
}