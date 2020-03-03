using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ConvertOnlyLowercaseTests
{
    [Fact]
    public void ToTest()
    {
        var input = "nY-aVdc_qu4";
        var expected = "n*y-a*vdc_qu4";


        var s = ConvertOnlyLowercase.To(input);
        Assert.Equal(expected, s);
    }

    [Fact]
    public void FromTest2()
    {
        var input = "n*y-a*vdc_qu4";
        var expected = "nY-aVdc_qu4";

        var s = ConvertOnlyLowercase.From(input);
        Assert.Equal(expected, s);
    }

}