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
        

        Assert.True(ConvertPascalConvention.IsPascal(input));
        Assert.False(ConvertPascalConvention.IsPascal(input2));
        Assert.False(ConvertPascalConvention.IsPascal(input3));
        
    }

    [Fact]
    public void ToConventionTest()
    {
        var input = @"custom Field 2 - Value";
        var expected = "CustomField2Value";

        var tc = ConvertPascalConventionWithNumbers.ToConvention(input);

        Assert.Equal(expected, tc);
    }
}