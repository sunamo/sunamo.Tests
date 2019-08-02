using System;
using System.Diagnostics;
using Xunit;

namespace SunamoNTextCat.Tests
{
    public class UnitTest1
    {
        const string cs = "ahoj světe";
        const string en = "hello world";
        const string cs2 = "error: Špatné údaje o přihlášení - odhlašte se a přihlašte se znovu.";
        const string en2 = "error: invalid data to login - please log out and sign in again";
        const string en3 = "Peruvian music informed by African, European, and Andean styles";


        [Fact]
        public void IsCzechTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            TextLang.Init();

            var t = TextLang.IsCzech(cs);
            var t2 = TextLang.IsCzech(cs2);
            var f = TextLang.IsCzech(en);
            var f2 = TextLang.IsCzech(en2);
            var f3 = TextLang.IsCzech(en3);

            /* Dont add any text to IsCzech - if is not czech it is english */

            Assert.True(t);
            Assert.True(t2);
            Assert.False(f);
            Assert.False(f2);
            Assert.False(f3);

            sw.Stop();

            DebugLogger.Instance.WriteLine("Is czech: " + sw.ElapsedMilliseconds);

        }

        [Fact]
        public void IsEnglishTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            TextLang.Init();

            var t = TextLang.IsEnglish(en);
            var t2 = TextLang.IsEnglish(en2);
            var f = TextLang.IsEnglish(cs);
            var f2 = TextLang.IsEnglish(cs2);
            var f3 = TextLang.IsEnglish(cs2);

            Assert.True(t);
            Assert.True(t2);
            Assert.False(f);
            Assert.False(f2);
            Assert.False(f3);

            sw.Stop();

            DebugLogger.Instance.WriteLine("Is english: " + sw.ElapsedMilliseconds);
        }
    }
}
