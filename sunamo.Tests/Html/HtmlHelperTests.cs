using HtmlAgilityPack;
using sunamo.Html;
using sunamo.Tests.Html;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Html
{
    /// <summary>
    /// 
    /// Stale se to strida #text, div
    /// </summary>
    public class HtmlHelperTests : HtmlHelperBaseTests
    {
        

        public HtmlHelperTests()
        {
         
        }

        [Fact]
        public void HasTagName()
        {
            // TODO: usage *
        }

        [Fact]
        public void GetTagOfAtributeTest()
        {
            var node = HtmlHelper.GetTagOfAtribute(documentNode, HtmlTags.div, HtmlAttrs.cAttr, cssClassHello);
            Assert.Null(node);

            var node2 = HtmlHelper.GetTagOfAtribute(bodyNode, HtmlTags.div, HtmlAttrs.cAttr, cssClassHello);
            Assert.NotNull(node2);
        }

        // OK
        [Fact]
        public void ReturnTagsWithAttrRekTest()
        {
            var nodes = HtmlHelper.ReturnTagsWithAttrRek(documentNode, HtmlTags.span, HtmlAttrs.cAttr, cssClassC);
            Assert.Equal(3, nodes.Count);
        }

        // OK
        [Fact]
        public void GetTagOfAtributeRekTest()
        {
            var divFirst = HtmlHelper.GetTagOfAtributeRek(documentNode, HtmlTags.div, HtmlAttrs.id, divFirstId);
            var nodes = HtmlHelper.ReturnTagsWithAttrRek(divFirst, HtmlTags.span, HtmlAttrs.cAttr, cssClassC);
            Assert.Equal(2, nodes.Count);

            var node = HtmlHelper.GetTagOfAtributeRek(documentNode, HtmlTags.div, HtmlAttrs.cAttr, cssClassHello);
            Assert.Null(node);

            var node2 = HtmlHelper.GetTagOfAtributeRek(bodyNode, HtmlTags.div, HtmlAttrs.cAttr, cssClassHello);
            Assert.NotNull(node2);
        }
    }
}
