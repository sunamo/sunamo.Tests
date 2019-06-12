using System;
using Xunit;

namespace SunamoTranslate.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TranslateTest()
        {
            TranslateHelper translateHelper = TranslateHelper.Instance;

            var excepted = "Ahoj světe";
            var actual = translateHelper.Translate("Hello World.", "cs");

            Assert.Equal(excepted, actual);
        }
    }
}
