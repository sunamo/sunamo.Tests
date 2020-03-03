using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SunamoTidy.Tests
{
    [TestClass]
    public class TidyManagedHelperTests
    {
        [TestMethod]
        public void FormatHtmlTest()
        {
            var content = TF.ReadFile(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1.html");
            string actual = null;
            //actual = TidyManagedHelper.FormatHtml(content);
            TF.WriteAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1_Out.html", actual);
        }
    }
}