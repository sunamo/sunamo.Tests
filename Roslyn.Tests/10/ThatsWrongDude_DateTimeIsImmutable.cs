using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;

public partial class RoslynLearn
{
    [Fact]
public void _ThatsWrongDude_DateTimeIsImmutable()
    {
        var dateTime = System.DateTime.UtcNow;
        dateTime.AddDays(1);

    }
}