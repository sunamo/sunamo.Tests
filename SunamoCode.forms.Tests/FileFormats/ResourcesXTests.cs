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
            ht.Add("path", @"E:\Documents\vs\Projects\sunamo\sunamo\MultilingualResources\sunamo.en-US.xlf");

            ResourcesX.UpdateResourceFile(ht, @"E:\Documents\vs\Projects\sunamo\Resources\ResourcesDuo.resx");
        }
    }
}