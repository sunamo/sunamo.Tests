using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

[TestClass]
public class BitmapImageHelperTests
{
    string GetFile(string n)
    {
        return @"d:\_Test\sunamo\desktop\Helpers\Content\Resource\BitmapImageHelper\Bitmap2BitmapImage\" + n +".png";
    }

    [TestMethod]
    public void Bitmap2BitmapImageTest()
    {
        var bitmap =  Image.FromFile(GetFile("17"));
        bitmap = BitmapHelper.ChangeColor2(bitmap, System.Drawing.Color.Black, ColorH.RandomColor(false).ToSystemDrawing());

        BitmapImage biVsLogo = BitmapImageHelper.Bitmap2BitmapImage(bitmap);

        var outFile = GetFile("out");
        BitmapImageHelper.Save(biVsLogo, outFile);
        PH.Start(outFile);
    }
}