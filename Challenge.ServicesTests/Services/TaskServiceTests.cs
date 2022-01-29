using Challenge.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Challenge.Services.Services.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {
        [TestMethod()]
        public void GetTasksTest()
        {
            string fileData = "(1,5),(2,7),(3,10),(4,3)";

            var task = TaskService.GetTasks(fileData.Split(StringCommon.Instance.arrayDelimiter, StringSplitOptions.RemoveEmptyEntries));

            Assert.IsNotNull(task);
            Assert.IsTrue(task.Count() > 0);
        }
    }
}