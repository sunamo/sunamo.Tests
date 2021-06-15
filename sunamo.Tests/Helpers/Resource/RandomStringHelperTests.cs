using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class RandomStringHelperTests
{
    [Fact]
    public void RandomStringTest()
    {
        var v = RandomStringHelper.RandomString(4, 2);
        var v2 = RandomStringHelper.RandomString(4, 1);
        int i = 0;
    }
}
