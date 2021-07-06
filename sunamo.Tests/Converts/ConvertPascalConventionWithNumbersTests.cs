using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ConvertPascalConventionWithNumbersTests
{
    [Fact]
    public void IsPascalWithNumberTest()
    {
        var input = @"HelloWorld1";
        var input2 = @"HelloWorld2";
        var input3 = @"Hello World3";

        Assert.Equal(true, ConvertPascalConvention.IsPascal(input));
        Assert.Equal(false, ConvertPascalConvention.IsPascal(input2));
        Assert.Equal(false, ConvertPascalConvention.IsPascal(input3));
    }

    [Fact]
    public void FromToPascalWithNumbersTest()
    {
        var input = "hello world";
        var to = ConvertPascalConventionWithNumbers.ToConvention(input);
        var from = ConvertPascalConventionWithNumbers.FromConvention(to);

        input = SH.FirstCharUpper(input);

        Assert.Equal(input, from);
    }


}