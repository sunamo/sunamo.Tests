using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace desktop.Tests
{
    public class SpecialFoldersHelperTests
    {
        [TestMethod]
        public void ApplicationData()
        {
            string expected = @"c:\Users\n\AppData\";
            string real = SpecialFoldersHelper.ApplicationData();
            Assert.AreEqual(expected, real);
        }
    }
}
