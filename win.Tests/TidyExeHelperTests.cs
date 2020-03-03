using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class TidyExeHelperTests
{
    [TestMethod]
    public void FormatHtmlTest()
    {
        var tidy_config = TidyExeHelper.WriteTidyConfigToExecutableLocation();

        var content = TF.ReadFile(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1.html");

        var actual = TidyExeHelper.FormatHtml(content, tidy_config);
        int i = 0;
    }
}