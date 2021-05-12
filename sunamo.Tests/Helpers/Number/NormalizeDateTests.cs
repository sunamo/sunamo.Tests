﻿using System;
using Xunit;

public class NormalizeDateTests
{
    [Fact]
    public void NormalizeDateTest()
    {
        var dt = new DateTime(2021, 1, 1);

        short d = 0;
        DateTime s;

        for (int i = 0; i < 12; i++)
        {
            d = NormalizeDate.To(dt);
            s = NormalizeDate.From(d);

            Assert.Equal<DateTime>(dt, s);

            dt = dt.AddMonths(1);
        }

        s = NormalizeDate.From(Consts.nDtMinVal);
        d = NormalizeDate.To(s);

        Assert.Equal<short>(Consts.nDtMinVal, d);

        s = NormalizeDate.From(Consts.nDtMaxVal);
        d = NormalizeDate.To(s);

        Assert.Equal<short>(Consts.nDtMaxVal, d);
    }
}