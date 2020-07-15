 using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using static CsFileFilter;

public class CsFileFilterTests
{
    string p = @"d:\_Test\SunamoCode\CsFileFilter\";

    List<FieldInfo> GetConsts()
    {
        List<FieldInfo> fi = new List<FieldInfo>();
        fi.AddRange( RH.GetConsts(typeof(FiltersNotTranslateAble), new GetMemberArgs { onlyPublic = false }));
        fi.AddRange(RH.GetConsts(typeof(Contains), new GetMemberArgs { onlyPublic = false }));
        return fi;
    }

    [Fact]
    public void GenerateFilesCsFileFilterTests()
    {
        var fi = GetConsts();
        foreach (var item in fi)
        {
            if (item.Name.EndsWith("Pp"))
            {
                var path = FS.Combine(p, "auto", "+" + item.GetValue(null));
                if (!FS.ExistsFile(path, false))
                {
                    TF.WriteAllText(path, "a");
                }
            }
        }
    }

    [Fact]
    public void GetFilesFiltered()
    {
        GenerateFilesCsFileFilterTests();

        CsFileFilter cs = new CsFileFilter();
        var fi = GetConsts();
        var fic = fi.Count;

        cs.Set(new CsFileFilter.EndArgs( false, false, false, false, false, false, false, false, false, false), new CsFileFilter.ContainsArgs(false, false, false));

        var f = cs.GetFilesFiltered(p, "*.cs", System.IO.SearchOption.TopDirectoryOnly);
        Assert.Empty(f);

        cs.Set(new CsFileFilter.EndArgs( true, true, true, true, true, true, true, true, true, true), new CsFileFilter.ContainsArgs(true, true, true));

        var f2 = cs.GetFilesFiltered(p, "*.cs", System.IO.SearchOption.TopDirectoryOnly);
        Assert.Equal(f2.Count, f2.Count);
    }
}