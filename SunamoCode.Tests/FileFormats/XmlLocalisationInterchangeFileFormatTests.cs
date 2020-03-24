using SunamoCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class XmlLocalisationInterchangeFileFormatTests : XmlTestsBase
{
    [Fact]
    public void AppendTest()
    {
        var file = @"d:\_Test\sunamo\SunamoCode\ParseAndRemoveNamespacesTest\a.xlf";
        XmlLocalisationInterchangeFileFormat.Append( "Hello", "Ahoj", "HelloID", file);
    }

    [Fact]
    public void ReplaceStringKeysWithXlfKeysWorkerTest()
    {
        string key = null;
        var content = TF.ReadFile(@"d:\_Test\sunamo\SunamoCode\FileFormats\a.cs");
        var output = XmlLocalisationInterchangeFileFormat.ReplaceStringKeysWithXlfKeysWorker(ref key, content);


    }

    [Fact]
    public void RemoveDuplicatesInXlfFileTest()
    {
        var xlfData = XmlLocalisationInterchangeFileFormat.GetTransUnits(base.pathXlf);
        //XmlLocalisationInterchangeFileFormat.RemoveDuplicatesInXlfFile(base.pathXlf);

        // Dont know how this is possible but this is working
        foreach (var item in xlfData.trans_units)
        {
            item.Remove();
        }

        var outer = xlfData.xd.ToString();
        
    }
}

