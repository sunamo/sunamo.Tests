using HtmlAgilityPack;
using sunamo.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace sunamo.Tests.Html
{
    public  class HtmlHelperBaseTests
    {
        protected HtmlNode documentNode;
        protected HtmlNode bodyNode;
        public const string testFile = @"d:\Documents\Visual Studio 2017\Projects\sunamo.Tests\sunamo.Tests\HtmlHelperTestPage.html";

        public readonly string cssClassC = "c";
        public readonly string cssClassA = "a";
        public readonly string cssClassHello = "hello";
        public readonly string divFirstId = "first";

        public HtmlHelperBaseTests()
        {
            GetHtmlDocumentTestFile();
        }

        void GetHtmlDocumentTestFile()
        {
            HtmlDocument hd = HtmlAgilityHelper.CreateHtmlDocument();
            hd.Load(testFile);
            this.documentNode = hd.DocumentNode;
            this.bodyNode = HtmlHelper.ReturnTagRek(documentNode, HtmlTags.body);
        }
    }
}
