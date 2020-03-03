using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class FromToTests
{
    [Fact]
    public void ParseTest()
    {
        FromTo ft = new FromTo();
        ft.Parse("20");
    }
}