using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Numbers
{
    public class NHTests
    {
        public readonly static List<int> input = CA.ToList<int>(4, 4, 4, 4, 3, 2, 2, 2, 1);
        public readonly static List<double> input2 = CA.ToList<double>(-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4);

        public class Int
        {
            //3
            [Fact]
            public void Median()
            {
                var median = NH.Median<int>(input);
                DebugLogger.Instance.WriteLine(median);
            }

            // 3
            [Fact]
            public void Median2()
            {
                var median = NH.Median2<int>(input);
                DebugLogger.Instance.WriteLine(median);
            }
        }

        public class Double
        {
            //3.4
            [Fact]
            public void Median()
            {
                var median = NH.Median<double>(input2);
                DebugLogger.Instance.WriteLine(median);
            }

            // 3.4
            [Fact]
            public void Median2()
            {
                var median = NH.Median2<double>(input2);
                DebugLogger.Instance.WriteLine(median);
            }
        }

    }
}
