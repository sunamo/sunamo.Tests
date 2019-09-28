using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

public class XmlHelperTests
{
    [TestMethod]
    public void ParseAndRemoveNamespacesTest()
    {
        var file = @"D:\_Test\sunamo\SunamoCode\ParseAndRemoveNamespacesTest\a.xlf";
        var c = TF.ReadFile(file);
        XmlNamespacesHolder h = new XmlNamespacesHolder();

        
        XmlDocument x = null;

        x = h.ParseAndRemoveNamespacesXmlDocument(c, x.NameTable);
    }
}

