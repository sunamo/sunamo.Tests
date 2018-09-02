using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreFx.Tests.System
{
    public class ObjectTests
    {
        [Fact]
        public void GetHashCodeTests()
        {
            string a = "a";
            string b = "A".ToLower();
            string c = a;
            c = "ab";

            Assert.Equal(a, b);
            Assert.NotEqual(a, c);
        }
    }
}
