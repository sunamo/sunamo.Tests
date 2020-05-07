using NUnit.Framework;

namespace SunamoGoPay.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PaymentSignatureTest2()
        {
            long paymentSessionId = 3093595206;
            long targetGoId = 8700421323;
            string expected = "a6340745333d05ef4ec6321eddcd36faddfa9ccd94365ed3faf76cc562d427db6bbae7b917c74f4b6c81232ddd8f9cbc";

            var actual = SunamoGoPayHelper.PaymentSignature(paymentSessionId, targetGoId);

            Assert.AreEqual(expected, actual);
        }
    }
}