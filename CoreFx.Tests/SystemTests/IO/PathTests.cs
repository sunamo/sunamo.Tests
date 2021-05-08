using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

public class PathTests
{
    #region FS.GetRelativePath must working exaxtly the same as Path.GetRelativePath
    [Fact]
    public void GetRelativePathTest()
    {
        var a1 = @"e:\Documents\Visual Studio 2017\Projects\EverythingClient\";
        var a2 = @"e:\Documents\Visual Studio 2017\Projects\sunamo\sunamo\sunamo.csproj";

        var expected = @"..\sunamo\sunamo\sunamo.csproj";

        //a1 a2 ..\sunamo\sunamo\sunamo.csproj
        //a2 a1 ..\..\..\EverythingClient\ - working perfectly even if path ending with backslash
        var result = Path.GetRelativePath(a1, a2);
        Assert.Equal(expected, result);

        expected = @"..\..\..\EverythingClient\";
        result = Path.GetRelativePath(a2, a1);

        Assert.Equal(expected, result);
    }


    [Fact]
    public void GetRelativePathTest2()
    {
        var a1 = @"e:\Documents\Visual Studio 2017\Projects\EverythingClient";
        var a2 = @"e:\Documents\Visual Studio 2017\Projects\sunamo\sunamo\sunamo.csproj";

        var expected = @"..\sunamo\sunamo\sunamo.csproj";

        //a1 a2 ..\sunamo\sunamo\sunamo.csproj
        //a2 a1 ..\..\..\EverythingClient\ - working perfectly even if path ending with backslash
        var result = Path.GetRelativePath(a1, a2);
        Assert.Equal(expected, result);

        expected = @"..\..\..\EverythingClient";
        result = Path.GetRelativePath(a2, a1);

        Assert.Equal(expected, result);
    } 
    #endregion
}