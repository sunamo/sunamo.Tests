using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using Xunit;
using Xunit;

public partial class RoslynLearn
{
    [Fact]
    public void _1IterateOverAllProjectsInSolution()
    {
        string solutionPath = @"d:\vs\sunamo.Tests\sunamo.Tests.sln";
        var msWorkspace = MSBuildWorkspace.Create();

        var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
        // Return 0 projects, dont know why
        foreach (var project in solution.Projects)
        {
            foreach (var document in project.Documents)
            {
                //DebugLogger.Instance.WriteLine(project.Name + "\t\t\t" + document.Name);
            }
        }

    }
}