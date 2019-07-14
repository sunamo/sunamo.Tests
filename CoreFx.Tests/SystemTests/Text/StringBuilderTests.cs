﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class StringBuilderTests
{
    /// <summary>
    /// \"
    /// </summary>
    const string from = "\\\"";
    /// <summary>
    /// 3x bs, qm
    /// </summary>
    const string to = "\\\\\\\"";

    [Fact]
    public void ReplaceTest()
    {
        const string betweeen = "abc";
        var actual = new StringBuilder( from + betweeen + from);
        var excepted = to + betweeen + to;

        Assert.Equal(excepted, actual.Replace(from, to).ToString());
    }

    [Fact]
    public void ReplaceInverseTest()
    {
        const string betweeen = "abc";
        var actual = new StringBuilder( to + betweeen + to);
        var excepted = from + betweeen + from;

        Assert.Equal(excepted, actual.Replace(to, from).ToString());
    }
}
