using Microsoft.VisualStudio.TestTools.UnitTesting;
using sunamo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class MimeHelperTests
{
    static Type type = typeof(MimeHelperTests);

    [TestMethod]
    public void GetMimeFromFileTest()
    {
        var f = @"d:\_Test\sunamo\win\Helpers\MImeHelper\GetMimeFromFile\Real";
        //application/octet-stream>
        Assert.AreEqual(string.Empty, MimeHelper.GetMimeFromFile(f + AllExtensions.webp));
        // 
        Assert.AreEqual(string.Empty, MimeHelper.GetMimeFromFile(f + AllExtensions.jpg));
    }
}
