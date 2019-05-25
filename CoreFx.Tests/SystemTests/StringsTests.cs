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
}

