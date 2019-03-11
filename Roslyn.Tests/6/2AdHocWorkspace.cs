//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Collections.Generic;
//using System;using Xunit;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Collections.Generic;
//using System;using Xunit;
//using Microsoft.Build.Evaluation;

//public partial class RoslynLearn
//{
//    [Fact]
//public void _2AdHocWorkspace()
//    {
//        // api for add and remove files is different within AdhocWorkspace  and other
//        var workspace = new AdhocWorkspace();
        
//        string projName = "NewProject";
//        // Create new project
//        var projectId = Project.CreateNewId();
//        var versionStamp = VersionStamp.Create();
//        var projectInfo = ProjectInfo.Create(projectId, versionStamp, projName, projName, LanguageNames.CSharp);
        
//        // add into project
//        var newProject = workspace.AddProject(projectInfo);
        
//        var sourceText = SourceText.From("class A {}");
//        var newDocument = workspace.AddDocument(newProject.Id, "NewFile.cs", sourceText);
        
//        foreach (var project in workspace.CurrentSolution.Projects)
//        {
//        	foreach (var document in project.Documents)
//        	{
//        		DebugLogger.Instance.WriteLine(project.Name + "\t\t\t" + document.Name);
//        	}
//        }

//    }
//}