using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Text
{
    public class SHTests
    {
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
