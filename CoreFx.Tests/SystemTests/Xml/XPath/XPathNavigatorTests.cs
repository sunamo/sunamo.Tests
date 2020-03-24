using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Xunit;

/// <summary>
/// All XML for testing must be in c#, here 
/// </summary>
public class XPathNavigatorTests : XmlTestsBase
{
    [Fact]
    public void SelectNodesXpathTest()
    {
        //ThisApp.Name = "sunamo";
        //ThisApp.Project = "CoreFx";
        //TestHelper.FolderForTestFiles(

        var path = @"d:\_Test\CoreFx\SystemTests\Xml\SelectNodesXpathTest\";

        string fileName = path + "1.xml";
        XPathDocument doc = new XPathDocument(fileName);
        XPathNavigator nav = doc.CreateNavigator();

        // Compile a standard XPath expression
        XPathExpression expr;
        expr = nav.Compile("/GetSKUsPriceAndStockResponse/GetSKUsPriceAndStockResult/SKUsDetails/SKUDetails");
        // Count: 0
        XPathNodeIterator iterator = nav.Select(expr);
        try
        {
            while (iterator.MoveNext())
            {

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [Fact]
    public void TextTest()
    {
        XPathNavigator nav;
        XPathDocument docNav;
        string xPath;

        var sr = new StringReader(xml1);
        var xtr = new XmlTextReader(sr);

        docNav = new XPathDocument(xtr);
        nav = docNav.CreateNavigator();
        xPath = "/Cell/CellContent/Para/ParaLine/String/text()";

        string value = nav.SelectSingleNode(xPath).Value;
        DebugLogger.DebugWriteLine(value);
    }
}