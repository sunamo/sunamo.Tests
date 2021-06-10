using Microsoft.VisualStudio.TestTools.UnitTesting;
using sunamo.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sunamo.Tests.Storage
{
    public class ApplicationDataContainerTests
    {
        const string fileTest = @"d:\_Test\sunamo\Storage\ApplicationDataContainer\file.txt";
        Dictionary<string, AB> testData = new Dictionary<string, AB>();
        const string key1 = "k1";
        const string key2 = "k2";
        const string value1 = "Love";
        const int value2 = NumConsts.zeroInt;

        public ApplicationDataContainerTests()
        {
            testData.Add(key1, AB.Get(Types.tString, value1));
            testData.Add(key2, AB.Get(Types.tInt, value2));
        }

        [TestMethod]
        public void Save()
        {
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            
            foreach (var item in testData)
            {
                container.Values[item.Key] = item.Value.B;
            }

            //Assert.AreEqual(2, container.Values.Count());
        }

        [TestMethod]
        public void Load()
        {
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            
            foreach (var item in container.Values.GetItems())
            {

                if (testData.ContainsKey(item.Key))
                {
                    testData.Remove(item.Key);
                }
                else
                {
                    DoesNotContain(testData, ContainsCollection);
                }
            }

            Assert.AreEqual(0, testData.Count());
        }

        private void DoesNotContain(Dictionary<string, AB> testData, Func<KeyValuePair<string, AB>, bool> containsCollection)
        {
            
        }

        bool ContainsCollection(KeyValuePair<string, AB> pair)
        {
            return testData.ContainsKey(pair.Key);
        }

        [TestMethod]
        public void Clear()
        {
            Save();
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            container.Values.Nuke();

            container = new ApplicationDataContainer(fileTest);
            Assert.AreEqual(0, container.Values.Count());
        }

        [TestMethod]
        public void DeleteEntry()
        {
            Save();

            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            container.Values.DeleteEntry(key1);

            container = new ApplicationDataContainer(fileTest);

            // Is really object, not AB
            var o = container.Values[key2];
            Assert.AreEqual(value2, o);
            Assert.AreEqual(1, container.Values.Count());
        }
    }
}