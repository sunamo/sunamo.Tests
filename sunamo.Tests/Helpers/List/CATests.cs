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
            CA.GetDuplicities

            List<string> input = TestData.listAB2;
            List<string> expected = new List<string>(global::CA.ToEnumerable("'a' ", "'b' "));
            var result = global::CA.WrapWithAndJoin(input, "'", AllStrings.space);

            Assert.Equal<string>(expected, result);
        }

        [Fact]
        public void RemoveDuplicitiesListTest()
        {
            //var d = CA.RemoveDuplicitiesList<string>(TestData.listABCCC);
            List<string> db2;
            var d2 = CA.RemoveDuplicitiesList<string>(TestData.listABCCC, out db2);
            
            int i = 0;
        }

        [Fact]
        public void CompareListSongFromInternetTest()
        {

            List<SongFromInternet> c1 = new List<SongFromInternet>();
            c1.Add(new SongFromInternet("a-b"));
            c1.Add(new SongFromInternet("c-d"));
            c1.Add(new SongFromInternet("a-b [c]"));
            //c1.Add(new SongFromInternet("a-b"));

            List<SongFromInternet> c2 = new List<SongFromInternet>();
            c2.Add(new SongFromInternet("a-b"));
            c2.Add(new SongFromInternet("c-d"));


            var both = CA.CompareList(c1, c2);
        }

        [Fact]
        public void DoubleOrMoreMultiLinesToSingleTest()
        {
            var input = @"a


b";
            var excepted = @"a

b";
            CA.DoubleOrMoreMultiLinesToSingle(ref input);
            Assert.Equal(excepted, input);

            input = @"a



b";

            CA.DoubleOrMoreMultiLinesToSingle(ref input);
            Assert.Equal(excepted, input);
        }

        [Fact]
        public void EqualRangesTest()
        {
            var input = CA.ToList<int>(5, 1, 2, 3, 4, 1, 2, 3, 6);
            var toFind = CA.ToList<int>(1, 2, 3);
            var excepted = CA.ToList<FromTo>(new FromTo(1, 3, false), new FromTo(5,7, false));

            var actual = CA.EqualRanges<int>(input, toFind);
            Assert.Equal<FromTo>(excepted, actual);

        }

        [Fact]
        public void IndexesWithValueTest()
        {
            var c = TestData.c;

            var d = TestData.listABC;
            d.Add(c);

            var actual = CA.IndexesWithValue<string>(d, c);
            var expected = CA.ToList<int>(2, 3);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnWhichContainsTest()
        {
            var input = @"a b d
a b c";
            var inputLines = SH.GetLines(input);

            // first line
            var c = CA.ReturnWhichContains(inputLines, "a d", ContainsCompareMethod.SplitToWords);
            // first line
            var c2 = CA.ReturnWhichContains(inputLines, "a !c", ContainsCompareMethod.Negations);
            // nothing
            var c3 = CA.ReturnWhichContains(inputLines, "a d", ContainsCompareMethod.WholeInput);
            // second line
            var c4 = CA.ReturnWhichContains(inputLines, "a c", ContainsCompareMethod.SplitToWords);

            int i = 0;
        }

        [Fact]
        public void JoinIEnumerableTest()
        {
            var input = "ab";
            var input2 = "cd";
            var expected = "abcd";

            var actual = CA.JoinIEnumerable<char>(input, input2);
            Assert.Equal(expected, actual);
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