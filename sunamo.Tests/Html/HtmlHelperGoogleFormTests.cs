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
    /// Unit test for right skipping text nodes
    /// </summary>
    public class HtmlHelperGoogleFormTests 
    {
        const string testFile = @"e:\Documents\vs\Projects\sunamo.Tests\sunamo.Tests\HtmlHelperGoogleFormTestPage.html";
        HtmlNode hd;
        const string mainQuestionTitle = "ss-q-title";
        const string additionalQuestionTitle = "ss-q-help ss-secondary-text";
        const string possibleAnswerTitle = "ss-choice-label";
        const string cssClassMainQuestions = "mainQuestions";
        const string cssClassAdditionalQuestion = "additionalQuestion";

        public HtmlHelperGoogleFormTests()
        {
            GetHtmlDocumentTestFile();
        }

        void GetHtmlDocumentTestFile()
        {
            HtmlDocument hd = HtmlAgilityHelper.CreateHtmlDocument();
            hd.Load(testFile);
            this.hd = hd.DocumentNode;
        }


        
        [Fact]
        public void ReturnAllTags()
        {
            var listAllQuestions = HtmlHelper.ReturnTagsWithAttrRek(hd, "ol", "class", "ss-question-list");
            var nodes = HtmlHelper.ReturnAllTags(listAllQuestions[0], HtmlTags.div);
            Assert.Equal(17,nodes.Count);
        }

    }
}