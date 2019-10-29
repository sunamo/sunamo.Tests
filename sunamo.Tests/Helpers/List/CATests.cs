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
        public void ToJaggedTTest()
        {
            var input = new int[2, 2] { { 0, 1 }, { 2, 3 } };

            var actual = CA.ToJagged<int>(input);

        }

        [Fact]
        public void ToJaggedTest()
        {
            var input = new bool[2, 2] { { true, false }, { false, true} };

            var actual = CA.ToJagged(input);

        }

        [Fact]
        public void RemoveWildcard()
        {

        }
    }
}
