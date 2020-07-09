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
    public void ReplaceRlDataToSessionI18nTest()
    {
        var RLDataEn = SunamoNotTranslateAble.RLDataEn;
        var SessI18n = SunamoNotTranslateAble.SessI18n;
        var RLDataCs = SunamoNotTranslateAble.RLDataCs;

        var input = "abc RLData.en[XlfKeys.a] def RLData.en[XlfKeys.abc] ghi RLDataEn[XlfKeys.a] jkl";
        var expected = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl";

        var actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18n);
        Assert.Equal(expected, actual);

        input = "jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        expected = "jkl sess.i18n(XlfKeys.AddAsRsvp) mno";

        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18n);
        Assert.Equal(expected, actual);

        
         expected = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        input = "abc RLData.en[XlfKeys.a] def RLData.en[XlfKeys.abc] ghi RLDataEn[XlfKeys.a] jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18n);
        Assert.Equal(expected, actual);


        input = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        expected = "abc RLData.cs[XlfKeys.a] def RLData.cs[XlfKeys.abc] ghi RLData.cs[XlfKeys.a] jkl RLData.cs[XlfKeys.AddAsRsvp] mno";
        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, SessI18n, RLDataCs);
        Assert.Equal(expected, actual);
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