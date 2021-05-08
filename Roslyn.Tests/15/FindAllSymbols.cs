using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

/*
 * Only with searching is slower than SymbolFinder
 * 
 */

public partial class RoslynLearn
{

    public class CustomSymbolFinder
    {
        public List<INamedTypeSymbol> GetAllSymbols(Compilation compilation)
        {

            var visitor = new FindAllSymbolsVisitor();
            visitor.Visit(compilation.GlobalNamespace);
            return visitor.AllTypeSymbols;
        }

        private class FindAllSymbolsVisitor : SymbolVisitor
        {
            public List<INamedTypeSymbol> AllTypeSymbols { get; } = new List<INamedTypeSymbol>();

            public override void VisitNamespace(INamespaceSymbol symbol)
            {
                Parallel.ForEach(symbol.GetMembers(), s => s.Accept(this));
            }

            public override void VisitNamedType(INamedTypeSymbol symbol)
            {
                AllTypeSymbols.Add(symbol);
                foreach (var childSymbol in symbol.GetTypeMembers())
                {
                    base.Visit(childSymbol);
                }
            }
        }
    }


}