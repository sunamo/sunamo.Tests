using sunamo.Helpers.Number;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class PercentCalculatorTests
{
    [Fact]
    public void a()
    {
        PercentCalculator pc = new PercentCalculator(100);
        for (int i = 0; i < 100; i++)
        {
            pc.AddOne();
        }


    }
}
