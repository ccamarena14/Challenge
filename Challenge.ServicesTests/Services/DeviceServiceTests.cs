using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Services.Services.Tests
{
    [TestClass()]
    public class DeviceServiceTests
    {
        [TestMethod()]
        public void GetDevicesFromStringTest()
        {
            //Data list without spaces
            List<string> dataList = new List<string>()
            {
                "10",
                "(1,5),(2,7),(3,10),(4,3)",
                "(1,5),(2,4),(3,3),(4,2)",

                "20",
                "(1,9),(2,15),(3,8)",
                "(1,11),(2,8),(3,12)",
            };

            var devices = DeviceService.GetDevicesFromString(dataList);

            Assert.IsNotNull(devices);
            Assert.IsTrue(devices.Count() > 0);
            Assert.IsTrue(devices.First().ForegroundTasks.Count > 0 && devices.First().ForegroundTasks.Count > 0);
        }
    }
}