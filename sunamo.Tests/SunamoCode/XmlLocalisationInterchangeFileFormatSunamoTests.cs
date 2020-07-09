using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class XmlLocalisationInterchangeFileFormatSunamoTests
{
    [Fact]
    public void RemoveSessI18nIfLineContainsTest()
    {
        var input = @"abc

MSStoredProceduresI.ci.a(XlfKeys.ab);

def
klm";

        var expected = @"abc

MSStoredProceduresI.ci.a(XlfKeys.ab);

def
klm";



        var actual = XmlLocalisationInterchangeFileFormatSunamo.RemoveSessI18nIfLineContains(input);
        Assert.Equal(expected, actual);
    }
}