using NUnit.Framework;
using SunamoLaTeX;

namespace SunamoLatex.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertToUnicodeTest()
        {
            string input = @"\( (A \vee I) \wedge(B \vee \neg l) \Leftrightarrow(A \vee l) \wedge(B \vee \neg l) \wedge(A \vee B) \)";
            var out2 = LatexHelper.ConvertToUnicode(input);

            if (LatexHelper.texSymbols.ContainsKey("\\𝑛𝑒𝑔"))
            {

            }

            if (LatexHelper.texSymbols.ContainsKey("\\neg"))
            {

            }

            /*
             * \( (𝐴 \𝑣𝑒𝑒 𝐼) \𝑤𝑒𝑑𝑔𝑒(𝐵 \𝑣𝑒𝑒 \𝑛𝑒𝑔 𝑙) \𝐿𝑒𝑓𝑡𝑟𝑖𝑔h𝑡𝑎𝑟𝑟𝑜𝑤(𝐴 \𝑣𝑒𝑒 𝑙) \𝑤𝑒𝑑𝑔𝑒(𝐵 \𝑣𝑒𝑒 \𝑛𝑒𝑔 𝑙) \𝑤𝑒𝑑𝑔𝑒(𝐴 \𝑣𝑒𝑒 𝐵) \)
             */
            Assert.Pass();
        }
    }
}