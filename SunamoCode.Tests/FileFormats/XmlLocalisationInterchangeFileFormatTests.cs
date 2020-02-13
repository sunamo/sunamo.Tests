using SunamoCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class XmlLocalisationInterchangeFileFormatTests
{
    [Fact]
    public void AppendTest()
    {
        var file = @"d:\_Test\sunamo\SunamoCode\ParseAndRemoveNamespacesTest\a.xlf";
        XmlLocalisationInterchangeFileFormat.Append( "Hello", "Ahoj", "HelloID", file);
    }
}

