using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class BitmapHelperTests
{
    string GetFile(string n)
    {
        return @"d:\_Test\sunamo\desktop\Helpers\Controls\BitmapHelperTests\"+n+".png";
    }

    [TestMethod]
    public void ChangeColor2Test()
    {
        Bitmap bmp = new Bitmap(GetFile("In"));
        var nB = BitmapHelper.ChangeColor2(bmp, Color.Black, Color.Orange);
        nB.Save(GetFile("Out"));
    }
}