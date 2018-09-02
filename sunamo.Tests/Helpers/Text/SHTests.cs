using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Text
{
    public class SHTests
    {

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

        public void RemoveAfterFirst()
        {
            string actual = "1 - 2";
            string excepted = "1";
            actual = SH.RemoveAfterFirst(actual, excepted);
            Assert.Equal(excepted, actual);
        }
    }
}
