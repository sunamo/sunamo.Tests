using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

public class DateTimeTests
{
    [Fact]
    public void ParseExactTest()
    {
        var dt = DateTime.ParseExact("10-2020", "MM-yyyy", CultureInfos.neutral);
        int i = 0;
    }
}