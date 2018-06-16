using System;
using Xunit;

namespace desktop.Tests
{
    public class SpecialFoldersHelperTests
    {
        [Fact]
        public void ApplicationData()
        {
            
            string expected = @"C:\Users\n\AppData\";
            string real = SpecialFoldersHelper.ApplicationData();
            Assert.Equal(expected, real);
        }
    }
}
