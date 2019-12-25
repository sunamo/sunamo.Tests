﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class UHTests
{
    [Fact]
    public void IsValidUriAndDomainIsTest()
    {
        var input = "naradi-pajky.cz";
        var expected = true;

        bool surelyDomain;
        var actual = UH.IsValidUriAndDomainIs(input, "*", out surelyDomain);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetUriSafeStringTest()
    {
        var input = "AttributeValueOfHtmlUC";
        var expected = "attribute-value-of-html-uc";

        var actual = UH.GetUriSafeString(input);
        Assert.Equal(expected, actual);
    }
}

