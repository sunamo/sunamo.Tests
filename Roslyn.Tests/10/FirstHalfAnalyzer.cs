using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

partial class FirstHalfAnalyzer
{

        //[DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class Analyzer1Analyzer : DiagnosticAnalyzer, IEquatable<Analyzer1Analyzer>
        {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => throw new NotImplementedException();

        public bool Equals(Analyzer1Analyzer other)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(AnalysisContext context)
        {
            throw new NotImplementedException();
        }
        //public const string DiagnosticId = "Analyzer1";

        //// You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        //public static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        //public static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        //public static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        //public const string Category = "Naming";

        //public static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        //public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        /* ... */
    }

    
}