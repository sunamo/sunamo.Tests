using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class StringsTests
{
    [Fact]
    public void NormalizeTest()
    {
        var actual = "Příliš žluťoučký kůň úpěl ďábelské ódy";
        var expected = "Prilis zlutoucky kun upel dabelske ody";

        var c = actual.Normalize(NormalizationForm.FormC);
        var d = actual.Normalize(NormalizationForm.FormD);
        var kc = actual.Normalize(NormalizationForm.FormKC);
        var kd = actual.Normalize(NormalizationForm.FormKD);

        int i = 0;
    }

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
        var actual = from + betweeen + from;
        var excepted = to + betweeen + to;

        Assert.Equal(excepted, actual.Replace(from, to));
    }

    [Fact]
    public void ReplaceInverseTest()
    {
        const string betweeen = "abc";
        var actual = to + betweeen + to;
        var excepted = from + betweeen + from;

        Assert.Equal(excepted, actual.Replace(to, from));
    }
}