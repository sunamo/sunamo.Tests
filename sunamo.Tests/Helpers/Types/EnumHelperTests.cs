using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class EnumHelperTests
{
    [Fact]
    public void ParseFromNumberTest()
    {
        var actual = EnumHelper.ParseFromNumber<Browsers, byte>(6, Browsers.Chrome);
    }
}