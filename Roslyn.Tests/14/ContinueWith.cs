using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

public partial class RoslynLearn
{
    [Fact]
public void _ContinueWith()
    {
        var state = CSharpScript.RunAsync(@"int x = 5; int y = 3; int z = x + y;""").Result;
        state = state.ContinueWithAsync("x++; y = 1;").Result;
        state = state.ContinueWithAsync("x = x + y;").Result;
        
        
        ScriptVariable x = state.GetVariable("x");
        ScriptVariable y = state.GetVariable("y");
        
        DebugLogger.Instance.WriteLine($"{x.Name} : {x.Value} : {x.Type} "); // x : 7
        DebugLogger.Instance.WriteLine($"{y.Name} : {y.Value} : {y.Type} "); // y : 1

    }
}