using System;
using NUnit.Framework;

namespace SunamoMathpix.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TextClientTest()
        {
            var bytes = TF.ReadAllBytes(@"d:\_Test\WpfApp1\WpfApp1\OpticalCharacterRecognitionUC\a.jpg").ToArray();
            var b = Convert.ToBase64String(bytes);
            b = "data:image/jpeg;base64," + b;
            MathpixHelper mathpixHelper = new MathpixHelper("sunamocz_gmail_com_966d39", "bc811dc177d29f2b0ce0");
            var result = mathpixHelper.TextClient(b);
            Assert.Pass();
        }

        [Test]
        public void TextTest()
        {
            var bytes = TF.ReadAllBytes(@"d:\_Test\WpfApp1\WpfApp1\OpticalCharacterRecognitionUC\a.jpg").ToArray();
            var b = Convert.ToBase64String(bytes);
            b = "data:image/jpeg;base64," + b;
            MathpixHelper mathpixHelper = new MathpixHelper("sunamocz_gmail_com_966d39", "bc811dc177d29f2b0ce0");
            var result = mathpixHelper.Text(b);
            Assert.Pass();
        }
    }
}