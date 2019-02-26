using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.CSharp;

public partial class RoslynLearn
{
    public class NamedTypeVisitor : SymbolVisitor
    {
        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            DebugLogger.Instance.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetMembers())
            {
                //We must implement the visitor pattern ourselves and 
                //accept the child symbols in order to visit their children
                childSymbol.Accept(this);
            }
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            DebugLogger.Instance.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetTypeMembers())
            {
                //Once againt we must accept the children to visit 
                //all of their children
                childSymbol.Accept(this);
            }
        }
    }

    [Fact]
public void _VisitAllSymbols()
    {
        
        
        //Now we need to use our visitor
        var tree = CSharpSyntaxTree.ParseText(@"
        class MyClass
        {
            class Nested
            {
            }
            void M()
            {
            }
        }");
        
        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { mscorlib });
        
        var visitor = new NamedTypeVisitor();
        visitor.Visit(compilation.GlobalNamespace);

    }
}