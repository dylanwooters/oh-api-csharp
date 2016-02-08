using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OHAPICSharp;

namespace OHAPICSharp.Tests
{
    //Unit tests require that a UserId and Secret Key are present in the project's config file.

    [TestClass]
    public class OHDriveServiceTests
    {
        [TestMethod]
        public void GetAll()
        {
            var drives = new OHDriveService().GetAll().Result;
            Assert.AreEqual<int>(1, drives.Count);
        }
        [TestMethod]
        public void Get()
        {
            var testDriveName = "oh-api-test";
            var drive = new OHDriveService().Get("5e2f2e24-079d-4f9f-8a4c-287ca044d01d").Result;
            Assert.AreEqual(testDriveName, drive.Name);
        }
    }
}
