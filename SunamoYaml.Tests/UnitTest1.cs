using sunamo.Essential;
using System;
using System.IO;
using Xunit;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace SunamoYaml.Tests
{
    public class UnitTest1
    {
        const string path = @"C:\Users\jancirad\Documents\Visual Studio 2017\Projects\sunamo.Tests\SunamoYaml.Tests\test.yaml";
        const string s = "s";
        const string ixTest = "text";

        [Fact]
        public void Load()
        {
            // Setup the input
            var input = new StringReader(File.ReadAllText(path));

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            var text = mapping[ixTest];
            Assert.Equal(s, text.ToString());
            
        }

        [Fact]
        public void Save()
        {
            // Four node types: Alias, Mapping, Scalar, Sequence

            var o = new
            {
                text = s,
                date = new DateTime(2007, 8, 6),
                anonymousType = new
                {
                    given = "Dorothy",
                    family = "Gale"
                },
                items = new[]
                {
                    new
                    {
                        id = 0,
                        name = "a"
                    },
                    new
                    {
                        id = 1,
                        name = "b"
                    }
                }
            };

            var serializer = new Serializer();
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, o);
            File.WriteAllText(path, sw.ToString());
        }
    }
}
