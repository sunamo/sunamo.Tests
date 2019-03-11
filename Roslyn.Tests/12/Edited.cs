using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;

// Automatically add calling LogCondition*

public partial class RoslynLearn
{
    [Fact]
public void _Edited()
    {
        char key = Console.ReadKey().KeyChar;
        if (key == 'A')
        {
            //LogConditionWasTrue();
            DebugLogger.Instance.WriteLine("You pressed A");
        }
        else
        {
            DebugLogger.Instance.WriteLine("You didn't press A");

            //LogConditionWasFalse();
        }

    }
}