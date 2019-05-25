using System;
using Xunit;

namespace SunamoNTextCat.Tests
{
    public class UnitTest1
    {
        const string cs = "ahoj světe";
        const string en = "hello world";
        const string cs2 = "error: Špatné údaje o přihlášení - odhlašte se a přihlašte se znovu.";

        [Fact]
        public void IsCzechTest()
        {
            TextLang.Init();

            var t = TextLang.IsCzech(cs);
            var t2 = TextLang.IsCzech(cs2);
            var f = TextLang.IsCzech(en);

            Assert.True(t);
            Assert.True(t2);
            Assert.False(f);
        }

        [Fact]
        public void IsEnglishTest()
        {
            TextLang.Init();

            var t = TextLang.IsEnglish(en);
            var f = TextLang.IsEnglish(cs);
            var f2 = TextLang.IsEnglish(cs2);

            Assert.True(t);
            Assert.False(f);
            Assert.False(f2);
        }
    }
}
