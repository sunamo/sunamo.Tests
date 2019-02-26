[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(Analyzer1CodeFixProvider)), Shared]
public class Analyzer1CodeFixProvider : CodeFixProvider
{
  private const string title = "Make uppercase";

  public sealed override ImmutableArray<string> FixableDiagnosticIds
  {
      get { return ImmutableArray.Create(Analyzer1Analyzer.DiagnosticId); }
  }

  public sealed override FixAllProvider GetFixAllProvider()
  {
      return WellKnownFixAllProviders.BatchFixer;
  }
  
  // ...
}