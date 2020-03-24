using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xunit;

public class XHTests : XmlTestsBase
{
    [Fact]
    public void RemoveFirstElementTest()
    {
        var content = TF.ReadFile(pathXlf);

        var xd = XDocument.Parse(content);
        // return zero
        var descendants = xd.Descendants("trans-unit");
        foreach (var item in descendants)
        {
            item.Remove();
        }

        var outer = xd.ToString();
    }
}