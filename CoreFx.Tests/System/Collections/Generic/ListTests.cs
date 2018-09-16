using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using System.Collections;
//using Microsoft.VisualStudio.TestPlatform.

namespace CoreFx.Tests.System.Collections.Generic
{
    public class ListTests
    {
        [Fact]
        public void IntersectTest()
        {
            // In begin AB+A, in end AB
            List<string> c1 = TestData.listAB1;
            List<string> c2 = TestData.listA;

            c1.Intersect(c2);

            Assert.True(c1.SequenceEqual(TestData.listAB2));
            
        }

        /// <summary>
        /// Only elements which are overall single
        /// </summary>
        [Fact]
        public void ExceptTest()
        {

            IEnumerable<string> actual1 = null;
            IEnumerable<string> actual2 = null;
            IEnumerable<string> expected = null;

            // In begin AB+C, on end C
            actual1 = TestData.listAB1;
            actual2 = TestData.listC;
            expected = TestData.listAB2;

            // Remove all actual2 from actual1
            actual1 = actual1.Except(actual2);

            Assert.True(actual1.SequenceEqual(expected));

            // 
            actual1 = TestData.listA;
            actual2 = TestData.listAB1;
            expected = TestData.listB;

            actual2 = actual2.Except(actual1);

            Assert.True(actual2.SequenceEqual(expected));
        }

        /// <summary>
        /// Remove duplicates
        /// </summary>
        [Fact]
        public void DistinctTest()
        {
            List<int> actual = TestData.list12;
            actual.AddRange(TestData.list1);
            List<int> expected = TestData.list12;

            Assert.True(actual.SequenceEqual(expected));
        }

        IEnumerable Copy(IEnumerable coll)
        {
            return CA.ToEnumerable(coll);
        }

        [Fact]
        public void RemoveAll()
        {
            List<string> actual = TestData.listABC;
            var excepted = TestData.listAC;

            var equalTo = TestData.listB;

            actual.RemoveAll(d => CA.IsEqualToAnyElement(d, equalTo));

            Assert.Equal(actual, excepted);
        }
    }
}
