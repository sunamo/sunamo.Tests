using System;
using Xunit;

namespace SunamoGoPay.Tests
{
    public class SunamoGoPayHelperTests
    {
        [Fact]
        public void HashEncryptTest()
        {
            string secureKey = GoConsts.secureKey;

            string input = "abc";

            var h = SunamoGoPayHelper.Hash(input);
            var h2 = SunamoGoPayHelper.Hash(input + input);

            var s = SunamoGoPayHelper.Encrypt(h, secureKey);
            var s2 = SunamoGoPayHelper.Encrypt(h2, secureKey);

            var f = (s + Environment.NewLine + s2);
        }

        [Fact]
        public void EncryptTest()
        {
            string secureKey = GoConsts.secureKey;

            string input = "abc";
            var s = SunamoGoPayHelper.Encrypt(input, secureKey);
            var s2 = SunamoGoPayHelper.Encrypt(input + input, secureKey);

            var f = (s + Environment.NewLine + s2);
        }

        /// <summary>
        /// must load SIGNATURE FROM CRYPTED!!
        /// otherwise is in SuccessCs
        /// </summary>
        [Fact]
        public void PaymentSignatureTest()
        {
            long paymentSessionId = 3093595206;
            long targetGoId = 8700421323;
            string expected = "a6340745333d05ef4ec6321eddcd36faddfa9ccd94365ed3faf76cc562d427db6bbae7b917c74f4b6c81232ddd8f9cbc";

            var actual = SunamoGoPayHelper.PaymentSignature(paymentSessionId, targetGoId);

            string s = expected + Environment.NewLine + actual;

            Assert.Equal(expected, actual);
        }
    }
}
