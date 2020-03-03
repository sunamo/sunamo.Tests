using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

[TestClass]
public class VisualTreeHelpersTests
{
    [TestMethod]
    public void FindDescendentsTest()
    {
        var sp = new StackPanel();
        var chb = new CheckBox();
        var tb = new TextBlock();

        const string inputText = "Hello world!";
        tb.Text = inputText;

        chb.Content = tb;
        sp.Children.Add(chb);

        var ele = VisualTreeHelpers.FindDescendents<TextBlock>(sp);
        var tb2 = ele.First();
        Assert.AreEqual(inputText, tb2.Text);
    }
}