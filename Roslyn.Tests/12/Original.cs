using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using Xunit;

public partial class RoslynLearn
{
    [Fact]
    public void _Original2()
    {
        char key = Console.ReadKey().KeyChar;
        if (key == 'A')
        {
            //DebugLogger.Instance.WriteLine("You pressed A");
        }
        else
        {
            //DebugLogger.Instance.WriteLine("You didn't press A");
        }

    }
}