using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class NormalizeDateTests
{
    [Fact]
    public void NormalizeDateTest()
    {
        var dt = new DateTime(2021, 1, 1);

        for (int i = 0; i < 12; i++)
        {
            
            var d = NormalizeDate.To(dt);
            var s = NormalizeDate.From(d);

            Assert.Equal<DateTime>(dt, s);

            dt = dt.AddMonths(1);
        }
    }
}
