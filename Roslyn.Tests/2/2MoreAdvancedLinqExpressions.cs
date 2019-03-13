using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

public partial class RoslynLearn
{
    [Fact]
public void _2MoreAdvancedLinqExpressions()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            public class MyClass
            {
                public void MyMethod()
                {
                }
                public void MyMethod(int n)
                {
                }
            }");
        
        var syntaxRoot = tree.GetRoot();
        var MyMethod = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>()
            .Where(n => n.ParameterList.Parameters.Any()).First();
        
        //Find the type that contains this method
        var containingType = MyMethod.Ancestors().OfType<TypeDeclarationSyntax>().First();
        
        DebugLogger.Instance.WriteLine(containingType.Identifier.ToString());
        // Return whole method content source
        DebugLogger.Instance.WriteLine(MyMethod.ToString());

    }
}