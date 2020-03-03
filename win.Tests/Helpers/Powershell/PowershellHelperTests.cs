using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win.Helpers.Powershell;

[TestClass]
public class PowershellHelperTests
{
    [TestMethod]
    public void DetectLanguageForFileGithubLinguistTest()
    {
         string file = @"d:\_Test\sunamo\win\Helpers\Powershell\PowershellHelper\cs";
        var expected = "C#";

        var actual = PowershellHelper.DetectLanguageForFileGithubLinguist(file);
        Assert.AreEqual(expected, actual);

         file = @"d:\_Test\sunamo\win\Helpers\Powershell\PowershellHelper\plain";
         expected = "C#";

         actual = PowershellHelper.DetectLanguageForFileGithubLinguist(file);
        Assert.AreEqual(expected, actual);

    }
}