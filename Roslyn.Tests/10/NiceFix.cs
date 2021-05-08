using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using Xunit;

public partial class RoslynLearn
{
    [Fact]
    public void _NiceFix()
    {
        var dateTime = System.DateTime.UtcNow;
        // add dateTime = because is immutable
        dateTime = dateTime.AddDays(1);

    }
}