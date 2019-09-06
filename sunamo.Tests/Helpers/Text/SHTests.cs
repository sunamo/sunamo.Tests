using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Text
{
    public class SHTests
    {
        const string splitAndKeepInput = "Shared settings <%--RL:SharedSettings--%> <span> aplikace</span>";
        readonly List<string> expected = CA.ToListString("Shared settings", "aplikace");

        [Fact]
        public void SplitAndKeepTest()
        {
            var actual = SH.SplitAndKeep(splitAndKeepInput, AspxConsts.all.ToArray());
            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void SplitAndKeepDelimiters()
        {
            var input = HtmlHelper.StripAllTags(splitAndKeepInput);
            var actual = SH.SplitAndKeepDelimiters(splitAndKeepInput, CA.ToListString(AllStrings.gt, AllStrings.lt));

            CA.ChangeContent(actual, d =>
            {
                if (d.EndsWith(AllChars.gt))
                {
                    d = string.Empty;
                }
                return d.TrimEnd(AllChars.lt).Trim();
            }
                );
            CA.RemoveStringsEmpty(actual);

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void ReplaceManyFromStringTest()
        {
            string testString = @"Assert.Equal -> Assert.AreEqual
Assert.AreEqual<*> -> CollectionAssert.AreEqual
[Fact] -> [TestMethod]
using Xunit; -> using Microsoft.VisualStudio.TestTools.UnitTesting;";
            testString = "Assert.AreEqual<*> -> CollectionAssert.AreEqual";

            string file = @"D:\Documents\Visual Studio 2017\Projects\sunamo.Tests\sunamo.Tests.Data\ReplaceManyFromString\In_ReplaceManyFromString.cs";
            var s = TF.ReadFile(file);

            s = SH.ReplaceManyFromString(s, testString, "->");

            TF.SaveFile(s, file);
        }

        [Fact]
        public void GetTextBetweenTwoCharsTest()
        {
            var input = "a {b} c";
            var expected = "b";

            var actual = SH.GetTextBetweenTwoChars(input, input.IndexOf('{'), input.IndexOf('}'));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void XCharsBeforeAndAfterWholeWordsTest()
        {
            var s = "12\"45" + Environment.NewLine + "12\"45";

            var occ = SH.ReturnOccurencesOfString(s, "\"");

            StringBuilder sb = new StringBuilder();
            foreach (var item in occ)
            {
                var r = SH.XCharsBeforeAndAfterWholeWords(s, item, 2);
                sb.AppendLine( r);
            }

            ClipboardHelper.SetText(sb);
        }

        [Fact]
        public void CharsBeforeAndAfterTest()
        {
            var s = "12\"45" + Environment.NewLine + "12\"45";

            
            
            //var sb = SH.CharsBeforeAndAfter(s, '\"', 2, 2);

            //ClipboardHelper.SetLines(sb);
        }

        //

        [Fact]
        public void GetLineIndexFromCharIndexTest()
        {
            var excepted = 2;
            // length is 10
            var input = @"ab
cd
ef";
            var l = input.Length;

            var lineF = SH.GetLineIndexFromCharIndex(input, 9);
            var lineE = SH.GetLineIndexFromCharIndex(input, 8);
            var lineD = SH.GetLineIndexFromCharIndex(input, 5);

            Assert.Equal(2, lineF);
            Assert.Equal(2, lineE);
            Assert.Equal(1, lineD);
        }

        [Fact]
        public void HasTextRightFormatTest()
        {
            FromTo requiredLength = new FromTo(1,2);
            var dash = CharFormatData.Get(null, new FromTo(1,1), AllChars.dash);
            var onlyNumbers = CharFormatData.GetOnlyNumbers(requiredLength);
            TextFormatData textFormat = new TextFormatData(false, -1, onlyNumbers, dash, onlyNumbers, dash, onlyNumbers, dash, onlyNumbers);

            string actual1 = " 01-1-1-1";
            string actual2 = "1-1-1-1";
            string actual3 = "123-1-1-1";
            string actual4 = "1-1-1";
            string actual5 = "1-1-1-1-1";
            string actual6 = "12-1-1-1";

            Assert.False(SH.HasTextRightFormat(actual1, textFormat));
            Assert.True(SH.HasTextRightFormat(actual2, textFormat));
            Assert.False(SH.HasTextRightFormat(actual3, textFormat));
            Assert.False(SH.HasTextRightFormat(actual4, textFormat));
            Assert.False(SH.HasTextRightFormat(actual5, textFormat));
            Assert.True(SH.HasTextRightFormat(actual6, textFormat));
        }

        [Fact]
        public void RemoveAfterFirstTest()
        {
            string actual = "1 - 2";
            string excepted = "1";
            actual = SH.RemoveAfterFirst(actual, excepted);
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void TextWithoutDiacriticTest()
        {
            var actual = "Příliš žluťoučký kůň úpěl ďábelské ódy";
            var expected = "Prilis zlutoucky kun upel dabelske ody";

            actual = SH.TextWithoutDiacritic(actual);
            Assert.Equal(expected, actual);
        }
    }
}
