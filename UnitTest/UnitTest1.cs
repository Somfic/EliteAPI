using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EliteAPI;
using System.IO;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(new DirectoryInfo("C:\\"), true);
            EliteAPI.Start();
            EliteAPI.Stop();
        }

        [TestMethod]
        public void TestMethod2()
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(new DirectoryInfo("C:\\"), false);
            EliteAPI.Start();
            EliteAPI.Stop();
        }

        [TestMethod]
        public void TestMethod3()
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, true);
            EliteAPI.Start();
            EliteAPI.Stop();
        }

        [TestMethod]
        public void TestMethod4()
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, false);
            EliteAPI.Start();
            EliteAPI.Stop();
        }
    }
}
