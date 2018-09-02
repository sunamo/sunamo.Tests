using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreFx.Tests.System
{
    public class UriTests
    {
        AB[] data = new AB[6];

        public UriTests()
        {
            data[0] = new AB(@"http://www.example.com/path???/file name", true); // False
            data[1] = new AB(@"c:\directoryilename", true); // False
            data[2] = new AB(@"file://c:/directory/filename", true); // False

            data[3] = new AB(@"http:\host/path/file", true); // True
            data[4] = new AB(@"www.example.com/path/file", true); // True

            data[5] = new AB(@"The example depends on the scheme of the URI.", false); // False
        }

        [Fact]
        public void IsWellFormedUriStringTest()
        {
            //IsWellFormedUriStringTestSingle(data);

            foreach (var d in data)
            {
                Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
            }
        }



        [Fact]
        private  void IsWellFormedUriStringTest0()
        {
            
            var d = data[0];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }

        [Fact]
        private void IsWellFormedUriStringTest1()
        {
            var d = data[1];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }

        [Fact]
        private void IsWellFormedUriStringTest2()
        {
            var d = data[2];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }

        [Fact]
        private void IsWellFormedUriStringTest3()
        {
            var d = data[3];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }

        [Fact]
        private void IsWellFormedUriStringTest4()
        {
            var d = data[4];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }

        [Fact]
        private void IsWellFormedUriStringTest5()
        {
            var d = data[5];
            Assert.Equal<bool>(Uri.IsWellFormedUriString(d.A, UriKind.RelativeOrAbsolute), (bool)d.B);
        }


    }
}
