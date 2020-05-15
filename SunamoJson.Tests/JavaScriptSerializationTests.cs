using System;
using Xunit;

namespace SunamoJson.Tests
{
    public class JavaScriptSerializationTests
    {
        [Fact]
        public void SystemTextJsonTest()
        {
            JavascriptSerialization js = new JavascriptSerialization(SerializationLibrary.SystemTextJson);

            dynamic d = js.Deserialize<ExternalLoginResult>(TestData.flatJson);
            Assert.Equal(TestData.flatJsonSc, d.Sc);
            var serialized = js.Serialize(d);
            Assert.Equal(TestData.flatJson, serialized);
        }
    }
}
