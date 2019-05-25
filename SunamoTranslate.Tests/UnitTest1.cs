using System;
using Xunit;

namespace SunamoTranslate.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TranslateTest()
        {
            var excepted = "Ahoj světe";
            var actual = TranslateHelper.Translate("Hello World.", "cs");

            Assert.Equal(excepted, actual);
        }
    }
}
