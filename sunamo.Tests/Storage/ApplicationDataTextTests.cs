using sunamo.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Storage
{
    public class ApplicationDataTextTests
    {
        [Fact]
        public void ParseTest()
        {
            string testFile = @"D:\_Test\ConsoleApp1\ConsoleApp1\ApplicationDataText.txt";

            var headers = CA.ToListString("Copy", "Dont copy to");
            CA.AddSuffix(headers, ":");

            var value1 = CA.ToListString("Shared");

            var dict = ApplicationDataText.Parse(testFile, headers);
            Assert.Equal<string>(value1, dict[headers[0]]);
        }
    }
}
