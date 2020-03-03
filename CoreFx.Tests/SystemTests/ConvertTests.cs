using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ConvertTests
{
    [Fact]
    public void ToInt32Test()
    {
        var f= Convert.ToInt32(false);
        var t = Convert.ToInt32(true);

        int i = 0;
    }
}