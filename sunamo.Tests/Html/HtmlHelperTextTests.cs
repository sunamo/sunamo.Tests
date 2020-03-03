using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class HtmlHelperTextTests
{
    [Fact]
    public void InsertMissingEndingTagsTest()
    {
        var input = "ab <a href=\"http://mobilovinky.blog.mobilmania.cz/2011/06/vodafone-a-cd-75-sleva-na-tarif/\" target=\"_blank\">http://mobilovinky.blog.mobilmania.cz/2011/06/vodafone-a-cd-75-sleva-na-tarif/ c <a href=\"d\">d</a> <a>e ";

        var excepted = "ab <a href=\"http://mobilovinky.blog.mobilmania.cz/2011/06/vodafone-a-cd-75-sleva-na-tarif/\" target=\"_blank\">http://mobilovinky.blog.mobilmania.cz/2011/06/vodafone-a-cd-75-sleva-na-tarif/</a> c <a href=\"d\">d</a> <a>e</a> ";

        input = HtmlHelperText.InsertMissingEndingTags(input, "a");

        Assert.Equal(excepted, input);
    }
}