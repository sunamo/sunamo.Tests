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
        var file = @"d:\_Test\sunamo\shared\ParseAndRemoveNamespacesTest\a.xlf";
        XmlLocalisationInterchangeFileFormat.Append(Langs.cs, "Hello", "Ahoj", "HelloID", file);
    }
}

