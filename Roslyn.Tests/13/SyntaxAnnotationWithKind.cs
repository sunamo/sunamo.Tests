﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;using Xunit;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;



public partial class RoslynLearn
{
    static async void _SyntaxAnnotationWithKind()
    {
        AdhocWorkspace workspace = new AdhocWorkspace();
        Project project = workspace.AddProject("Test", LanguageNames.CSharp);
        
        string annotationKind = "SampleKind";
        // Pass name of annotation
        var syntaxAnnotation = new SyntaxAnnotation(annotationKind);
        var classDeclaration = SyntaxFactory.ClassDeclaration("MyClass")
        	.WithAdditionalAnnotations(syntaxAnnotation);
        
        var compilationUnit = SyntaxFactory.CompilationUnit().AddMembers(classDeclaration);
        
        Document document = project.AddDocument("Test.cs", compilationUnit);
        SemanticModel semanticModel = await document.GetSemanticModelAsync();
        var newAnnotation = new SyntaxAnnotation("test");
        
        //Just search for the Kind instead
        var root = await document.GetSyntaxRootAsync();
        var changedClass = root.GetAnnotatedNodes(annotationKind).Single();
        
        var symbol = semanticModel.GetDeclaredSymbol(changedClass);

    }
}