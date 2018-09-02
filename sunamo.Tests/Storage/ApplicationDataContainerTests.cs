using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace sunamo.Tests.Storage
{
    public class ApplicationDataContainerTests
    {
        const string fileTest = @"d:\_Test\sunamo\Storage\ApplicationDataContainer\file.txt";
        Dictionary<string, AB> testData = new Dictionary<string, AB>();
        const string key1 = "k1";
        const string key2 = "k2";

        public ApplicationDataContainerTests()
        {
            testData.Add(key1, AB.Get("_string", "Love"));
            testData.Add(key2, AB.Get("int", 1));
        }

        [Fact]
        public void Save()
        {
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            foreach (var item in testData)
            {
                container.Values[item.Key] = item.Value.B;
            }

            Assert.Equal(2, container.Values.Count());
        }

        [Fact]
        public void Load()
        {
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            foreach (var item in container.Values)
            {
                if (testData.ContainsKey(item.Key))
                {
                    testData.Remove(item.Key);
                }
                else
                {
                    Assert.DoesNotContain<KeyValuePair<string, AB>>(testData, ContainsCollection);
                }
            }

            Assert.Equal(0, testData.Count());
        }

        bool ContainsCollection(KeyValuePair<string, AB> pair)
        {
            return testData.ContainsKey(pair.Key);
        }

        [Fact]
        public void Clear()
        {
            Save();
            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            container.Values.Nuke();
        }

        [Fact]
        public void DeleteEntry()
        {
            Save();

            ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
            container.Values.DeleteEntry(key1);

            container = new ApplicationDataContainer(fileTest);

            Assert.Equal(1, container.Values.Count());
        }
    }
}
