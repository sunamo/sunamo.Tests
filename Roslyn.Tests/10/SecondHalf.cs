using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Linq;
using System.Collections.Immutable;

public partial class RoslynLearn
{

        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class Analyzer1Analyzer : DiagnosticAnalyzer
        {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => throw new NotImplementedException();

        /* ... */

        public override void Initialize(AnalysisContext context)
            {
                // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
                context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
            }
        
            private static void AnalyzeSymbol(SymbolAnalysisContext context)
            {
            DiagnosticDescriptor Rule = null;

                // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
                var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
        
                // Find just those named type symbols with names containing lowercase letters.
                if (namedTypeSymbol.Name.ToCharArray().Any(char.IsLower))
                {
                    // For all such symbols, produce a diagnostic.
                    var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
        
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }

    
}