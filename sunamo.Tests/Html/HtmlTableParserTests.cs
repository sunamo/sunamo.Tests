using sunamo;
using sunamo.Html;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class HtmlTableParserTests
{
    [Fact]
    public void HtmlTableParserTest()
    {
        var a = @"D:\_Test\sunamo\sunamo\Html\HtmlTableParserTests\a.html";
        var hd = HtmlAgilityHelper.CreateHtmlDocument();
        hd.LoadHtml(TF.ReadFile(a));
        var table = HtmlAgilityHelper.Node(hd.DocumentNode, true, "table");
        HtmlTableParser p = new HtmlTableParser(table, false);
        var v = p.ColumnValues("1", false, false);
        int i = 0;
    }
}
