 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

public class XHelperTests
{
    [Fact]
    public void InnerTextOfNode()
    {
        var excepted = "1.40.2.1593";
        var xml = "<PackageReference Include=\"Google.Apis.YouTube.v3\"><Version>1.40.2.1593</Version></PackageReference>";
        var xe = XElement.Parse(xml);

        var actual = XHelper.InnerTextOfNode(xe, "Version");
        Assert.Equal(actual, excepted);
    }
}