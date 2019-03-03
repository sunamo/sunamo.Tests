using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.CSharp;

public partial class RoslynLearn
{
    [Fact]
public void _TestCompilation2()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
        using System;
        public class C
        {
            public static void Main()
            {
                Console.WriteLine(""Hello World!"");
                Console.ReadLine();
            }   
        }");
        
        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { mscorlib });
        
        //Emitting to file is available through an extension method in the Microsoft.CodeAnalysis namespace
        var emitResult = compilation.Emit("output.exe", "output.pdb");
        
        //If our compilation failed, we can discover exactly why.
        if(!emitResult.Success)
        {
            foreach(var diagnostic in emitResult.Diagnostics)
            {
                DebugLogger.Instance.WriteLine(diagnostic.ToString());
            }
        }

    }
}