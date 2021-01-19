using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class WindowsOSHelperTests
{
    [TestMethod]
    public void FileInTest()
    {
        var p = PHWin.AddBrowser(Browsers.Seznam);
        Assert.Equals(p, @"C:\Users\j\AppData\Roaming\Seznam Browser\Seznam.cz.exe");
    }
}
