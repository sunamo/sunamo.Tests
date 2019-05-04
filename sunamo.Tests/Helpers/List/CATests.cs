using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.List
{
    public class CATests
    {
        [Fact]
        public void WrapWithAndJoin()
        {
            List<string> input = TestData.listAB2;
            List<string> expected = new List<string>(global::CA.ToEnumerable("'a' ", "'b' "));
            var result = global::CA.WrapWithAndJoin(input, "'", AllStrings.space);

            Assert.Equal<string>(expected, result);
        }

        [Fact]
        public void RemoveWildcard()
        {

        }
    }
}
