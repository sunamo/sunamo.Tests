using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

enum LinkType
{
    H,J,D
}

[TestClass]
public class JunctionPointTests
{
    string target = null;
    const string target2 = @"d:\_Test\sunamo\win\JunctionPoint\";
     string append = "Folder";

    [TestMethod]
    public void GetTargetTest()
    {
        TestHelper.Init();

        var d = SetFor(LinkType.D);
        var td = JunctionPoint.GetTarget(d);
        // target2 - also folder
        var rd = JunctionPoint.GetTarget(target2);
        var ed = FS.ExistsDirectory(d);

        var j = SetFor(LinkType.J);
        var tj = JunctionPoint.GetTarget(j);
        //var rj = JunctionPoint.GetTarget(target);
        var ej = FS.ExistsDirectory(j);

        SetFor(LinkType.H);
        var h = SetFor(LinkType.H);
        var th = JunctionPoint.GetTarget(h);
        var rh = JunctionPoint.GetTarget(target);
        var eh =FS.ExistsDirectory(h);
    }

    [TestMethod]
    public void IsJunctionPointTest()
    {
        var a = JunctionPoint.Exists(D());
        var b = JunctionPoint.Exists(J());
        var c= JunctionPoint.Exists(target);

        
        var d = JunctionPoint.IsReparsePoint(D());
        var e = JunctionPoint.IsReparsePoint(J());
        
        var f = JunctionPoint.IsReparsePoint(target);
    }

    string SetFor(LinkType lt)
    {
        if (lt == LinkType.J || lt == LinkType.D)
        {
            append = "Folder";
            target = target2 + append;
        }
        else
        {
            append = "File";
            target = target2 + append;
        }

        string result = null;
        switch (lt)
        {
            case LinkType.H:
                result = H();
                break;
            case LinkType.J:
                result = J();
                break;
            case LinkType.D:
                result = D();
                break;
        }

        return result;
    }

    string H()
    {
        return @"d:\_Test\sunamo\win\JunctionPoint\H_" + append;
    }

    string J()
    {
        return @"d:\_Test\sunamo\win\JunctionPoint\J_" + append;
    }

    string D()
    {
        return @"d:\_Test\sunamo\win\JunctionPoint\D_" + append;
    }

    [TestMethod]
    public void MklinkH()
    {
        var txt = AllExtensions.txt;
        SetFor(LinkType.H);
        JunctionPoint.MklinkH(H() +txt, target+txt);
    }

    [TestMethod]
    public void MklinkJ()
    {
        
        SetFor(LinkType.J);
        var j = J();
        JunctionPoint.Delete(j);
        JunctionPoint.MklinkJ(j, target);
    }

    [TestMethod]
    public void MklinkD()
    {
        SetFor(LinkType.D);
        JunctionPoint.MklinkD(D(), target);
    }
}