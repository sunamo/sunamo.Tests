using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyManaged;

[TestClass]
public class TidyHtml5ManagedRepackHelperTests
{
    [TestMethod]
    public void TidyHtml5ManagedRepackHelperTest()
    {
        var content = TF.ReadFile(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1.html");
        string actual = null;
        //actual = TidyHtml5ManagedRepackHelper.FormatHtml(content);
        TF.WriteAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1_Out.html", actual);
    }

    [TestMethod]
    public void TidyHtml5ManagedRepackHelperTest2()
    {
        string dirtyHtml = "<p>Test";
        string expected = "<p>Test</p>";
        string actual = null;

        using (Document doc = Document.FromString(dirtyHtml))
        {
            doc.OutputBodyOnly = AutoBool.Yes;
            doc.Quiet = true;
            doc.CleanAndRepair();
            // Add 2x newline, therefore Trim()
            actual = doc.Save().Trim();
        }

        Assert.AreEqual(expected, actual);
    }
}