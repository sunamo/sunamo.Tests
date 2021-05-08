using SunamoCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class XmlLocalisationInterchangeFileFormatTests : XmlTestsBase
{
    [Fact]
    public void RemoveSessI18nIfLineContainsTest()
    {



        //MSStoredProceduresI.ci.a(SunamoPageHelperSunamo.i18n(XlfKeys.SunamoPageHelperSunamo_i18n));
        /*
        MSStoredProceduresI.ci.a(XlfKeys.DotCs);

        Cs se nikde nevyužívá, proto jej nemusím ani nahrazovat
        MSStoredProceduresI.ci.a(RLData.cs[XlfKeys.DotCs]);
        */
        var input = @"abc

MSStoredProceduresI.ci.a(XlfKeys.dotEn);
MSStoredProceduresI.ci.a(XlfKeys.ab);
MSStoredProceduresI.ci.a(XlfKeys.DataEn);

def
klm";

        var expected = @"abc

MSStoredProceduresI.ci.a(XlfKeys.dotEn);
MSStoredProceduresI.ci.a(XlfKeys.ab);
MSStoredProceduresI.ci.a(XlfKeys.DataEn);


def
klm";



        var actual = XmlLocalisationInterchangeFileFormat.RemoveSessI18nIfLineContains(input);
        Assert.Equal(expected, actual);
    }

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

    /// <summary>
    /// Working perfectly
    /// </summary>
    [Fact]
    public void ReplaceRlDataToSessionI18nTest()
    {
        var RLDataEn = SunamoNotTranslateAble.RLDataEn;
        var SessI18nShort = SunamoNotTranslateAble.SessI18nShort;
        var RLDataCs = SunamoNotTranslateAble.RLDataCs;

        var input = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl";
        var expected = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl";

        var actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18nShort);
        Assert.Equal(expected, actual);

        input = "MSStoredProceduresI.ci.a(XlfKeys.dotEn)";
//        input = @"abc

//MSStoredProceduresI.ci.a(XlfKeys.dotEn);

//def
//klm";
        expected = "MSStoredProceduresI.ci.a(XlfKeys.dotEn)";

        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18nShort);
        Assert.Equal(expected, actual);

        input = "jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        expected = "jkl sess.i18n(XlfKeys.AddAsRsvp) mno";

        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18nShort);
        Assert.Equal(expected, actual);

        
         expected = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        input = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, RLDataEn, SessI18nShort);
        Assert.Equal(expected, actual);


        input = "abc sess.i18n(XlfKeys.a) def sess.i18n(XlfKeys.abc) ghi sess.i18n(XlfKeys.a) jkl sess.i18n(XlfKeys.AddAsRsvp) mno";
        expected = "abc RLData.cs[XlfKeys.a] def RLData.cs[XlfKeys.abc] ghi RLData.cs[XlfKeys.a] jkl RLData.cs[XlfKeys.AddAsRsvp] mno";
        actual = XmlLocalisationInterchangeFileFormat.ReplaceRlDataToSessionI18n(input, SessI18nShort, RLDataCs);
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