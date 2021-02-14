using Microsoft.VisualStudio.TestTools.UnitTesting;
using sunamo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace shared.Tests
{
    [TestClass]
    public class HttpClientHelperTests
    {
        [TestMethod]
        public void GetResponseTextTest()
        {
            var t = HttpClientHelper.GetResponseText(@"https://ws.audioscrobbler.com/2.0/?method=artist.gettoptags&artist=Soundtrack+Ledov%C3%A9+kr%C3%A1lovstv%C3%AD+II&user=sunamoDevProg&api_key=68ae15739cd690ce04679a15b5583fd4", HttpMethod.Get, null);

            int i = 0;
        }
    }
}