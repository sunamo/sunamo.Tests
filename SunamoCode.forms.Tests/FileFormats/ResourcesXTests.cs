using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SunamoCode.forms.Tests
{
    [TestClass]
    public class ResourcesXTests
    {
        [TestMethod]
        public void UpdateResourceFileTest()
        {
            Hashtable ht = new Hashtable();
            ht.Add("path", @"D:\Documents\Visual Studio 2017\Projects\sunamo\sunamo\MultilingualResources\sunamo.en-US.xlf");

            ResourcesX.UpdateResourceFile(ht, @"D:\Documents\Visual Studio 2017\Projects\sunamo\Resources\ResourcesDuo.resx");
        }
    }
}
