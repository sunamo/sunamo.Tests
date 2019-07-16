using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ConvertPascalConventionTests
{
    [Fact]
    public void IsPascalTest()
    {
        var input = @"HelloWorld";
        var input2 = @"HelloWorld";
        var input3 = @"Hello World";

        Assert.Equal(true, ConvertPascalConvention.IsPascal(input));
        Assert.Equal(false, ConvertPascalConvention.IsPascal(input2));
        Assert.Equal(false, ConvertPascalConvention.IsPascal(input3));
    }
}

