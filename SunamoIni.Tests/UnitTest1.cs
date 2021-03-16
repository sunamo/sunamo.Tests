using System;
using Xunit;

namespace SunamoIni.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WriteIni()
        {
            IniFile ini = new IniFile(@"e:\Documents\Visual Studio 2017\Projects\sunamo.Tests\SunamoIni.Tests\test.ini");
            ini.IniWriteValue("Section", "Key", "Value");
            
        }
    }
}