using Roslyn;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class RoslynParserTests
{
    [Fact]
    /// <summary>
    /// 
    /// </summary>
    public static void IsCSharpCodeTest()
    {
        var input1 = "abc";
        var input2 = @"using System;

using System.Collections.Generic;
";
        Assert.False(RoslynParser.IsCSharpCode(input1));
        Assert.True(RoslynParser.IsCSharpCode(input2));
    }
}

