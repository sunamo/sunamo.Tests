 using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

public class CsFileFilterTests
{
    string p = @"d:\_Test\SunamoCode\CsFileFilter\";

    List<FieldInfo> GetConsts()
    {
        return RH.GetConsts(typeof(CsFileFilter), new GetMemberArgs { onlyPublic = false });
    }

    [Fact]
    public void GenerateFilesCsFileFilterTests()
    {
        var fi = GetConsts();
        foreach (var item in fi)
        {
            if (item.Name.EndsWith("Pp"))
            {
                var path = FS.Combine(p, "+" + item.GetValue(null));
                if (!FS.ExistsFile(path, false))
                {
                    TF.WriteAllText(path, "a");
                }
            }
        }
    }

    [Fact]
    public void GetFIlesFiltered()
    {
        CsFileFilter cs = new CsFileFilter();
        var fi = GetConsts();
        var fic = fi.Count;

        cs.Set(false, false, false, false, false, false, false, false, false, false);

        var f = cs.GetFilesFiltered(p, "*.cs", System.IO.SearchOption.TopDirectoryOnly);
        Assert.Empty(f);

        cs.Set(true, true, true, true, true, true, true, true, true, true);

        var f2 = cs.GetFilesFiltered(p, "*.cs", System.IO.SearchOption.TopDirectoryOnly);
        Assert.Equal(f2.Count, f2.Count);
    }
}