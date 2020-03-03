using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class TypeTests
{
    [Fact]
    public void GetPropertyAndVariables()
    {
        var dc = new DataClass() { variable = "a" };
        dc.variable = "a";

        var d = RH.GetValueOfPropertyOrField(dc, "variable");
        var s = RH.GetValueOfPropertyOrField(dc, "Property");

        int i = 0;
    }
}