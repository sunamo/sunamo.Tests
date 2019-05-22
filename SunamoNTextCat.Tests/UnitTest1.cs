using System;
using Xunit;

namespace SunamoNTextCat.Tests
{
    public class UnitTest1
    {
        const string cs = "ahoj světe";
        const string en = "hello world";

        [Fact]
        public void IsCzechTest()
        {
            var t = TextLang.IsCzech(cs);
            var f = TextLang.IsCzech(en);

            Assert.True(t);
            Assert.False(f);
        }

        [Fact]
        public void IsEnglishTest()
        {
            var t = TextLang.IsEnglish(en);
            var f = TextLang.IsEnglish(cs);

            Assert.True(t);
            Assert.False(f);
        }
    }
}
