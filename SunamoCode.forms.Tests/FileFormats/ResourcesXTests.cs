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
            ht.Add("path", @"E:\Documents\Visual Studio 2017\Projects\sunamo\sunamo\MultilingualResources\sunamo.en-US.xlf");

            ResourcesX.UpdateResourceFile(ht, @"E:\Documents\Visual Studio 2017\Projects\sunamo\Resources\ResourcesDuo.resx");
        }
    }
}