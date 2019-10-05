using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.Text
{
    public class SHTests
    {
        const string splitAndKeepInput = "Shared settings <%--RL:SharedSettings--%> <span> aplikace</span>";
        readonly List<string> expected = CA.ToListString("Shared settings", "aplikace");

        [Fact]
        public void SplitAndKeepTest()
        {
            var actual = SH.SplitAndKeep(splitAndKeepInput, AspxConsts.all.ToArray());
            Assert.Equal<string>(expected, actual);
        }

        [Fact]
    public void MultiWhitespaceLineToSingleTest()
    {
        List<string> input = SH.GetLines(@"a

 
b

c");

        var excepted = SH.GetLines(@"a

b

c");

        input = SH.GetLines( SH.MultiWhitespaceLineToSingle(input));

        Assert.Equal(excepted, input);

            //            input = SH.GetLines(@":/ Pak je pobyli, Judskeho krale si vzal primo ten Bab., mesto lehlo popelem, vetsinu odvlekly do Bab., Bab. pobyly vsechny pronarody v okoli, ale nakonec buh ukazal kdo jsou jeho vyvoleni a Izrael se zase vysvobodil, vsechno krveproliti se obratilo proti Babylonanum.





            //A VDV - akt.budu cist kapitolu 14, moc se ji nevenuji, viz.status.Porad jsem u toho, jak byly kazatele evangelia prohlaseni za kacire a upaleni, jak se rozsirovala potajnu bible, jak kazdy odpor byl zbytecny, protoze to byla setba..");

            input = TF.GetLines(@"D:\_Test\sunamo\sunamo\Helpers\Text\SH\MultiWhitespaceLineToSingle\a.txt");

            excepted = SH.GetLines( @":/ Pak je pobyli, Judskeho krale si vzal primo ten Bab., mesto lehlo popelem, vetsinu odvlekly do Bab., Bab. pobyly vsechny pronarody v okoli, ale nakonec buh ukazal kdo jsou jeho vyvoleni a Izrael se zase vysvobodil, vsechno krveproliti se obratilo proti Babylonanum.

A VDV - akt.budu cist kapitolu 14, moc se ji nevenuji, viz.status.Porad jsem u toho, jak byly kazatele evangelia prohlaseni za kacire a upaleni, jak se rozsirovala potajnu bible, jak kazdy odpor byl zbytecny, protoze to byla setba..");


            input = SH.GetLines(SH.MultiWhitespaceLineToSingle(input));

            Assert.Equal(excepted, input);


        }

        [Fact]
        public void SplitParagraphToMaxCharsTest()
        {
            ClipboardHelper.Instance = ClipboardHelperCore.Instance;

            string input2 = @"";

            var input3 = @"";

            var input = @"Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tečka je v další větě. tečka je v další větě. Tečka je v další větě. Tečka je v další větě.

Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tečka je v další větě. Tečka je v další větě. Tečka je v další větě. Tečka je v další větě.

Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků Tento paragraph nemá žádnou tečku a je delší než 250 znaků

Tento paragraph má méně než 250 znaků. Tento paragraph má méně než 250 znaků. Tento paragraph má méně než 250 znaků. Tento paragraph má méně než 250 znaků. Tento paragraph má méně než 250 znaků. 

";

            input = "Tento paragraph má více než 250 znaků. Tento paragraph má více než 250 znaků. Tento paragraph má více než 250 znaků. Tento paragraph má více než 250 znaků. Tento paragraph má více než 250 znaků. Tento paragraph má více než 250 znaků 273. Tento paragraph má více než 250 znaků. ";

//            input = "Na nekolik jsem i dostal odpoved, ale nektere vstupni pozadavky me docela zdrtili. Jeden mi nechtel verit ze umim 2 jazyky. Druhy mi poslal 3 strankovy dokument, ani nevim co s nim, 3 mel 20 otazek prichystanych. Na FB jsem poslal jen jeden song, 23.7.2009. Jinak jsem tu za cely den neudelal vubec nic. Co se tyce programovani, zacinal jsem chapat, ze zadny poradny web neudelam v \"poloautomatickem\" editoru, jaky jsem udelal ja a uz jsem se zase soustredoval na toto. Dnes jsem zacal konecne poradne twitterovat. Vzhledem k tomu webu, zacal jsem si shanet clanky na webu. Zacal jsem se znova zajimat o svoje programy, i kdyz ne v intenzite, ktera prijde pozdeji. Uz jsem mel tak malo mista na disku, takze jsem se snazil vypalovat. Vzal jsem ty cedla od Andreho, ale s nimi jsem nepochodil ani trochu, nejen ze se nacitali nevim jak dlouho ale kdyz jsem dal napalovani, chytlo to vzdycky takove obratky a docela logicky se to nikdy nepohlo ani o jedno procentu. Nuze, zkusim ty svoje stare divka. Projizdel jsem vsechny od 200 do 250, ale nektere se mi nepodarilo nacist, na tom zbytku nebylo misto. Ksakru, co ted? Nakonec jsem se odhodlal k zoufalemu kroku.." + @"

            //" + "to co jsem celou dobu strezil, me WV, i se vsemi programy jsem musel smazat, nikde jinde misto nebylo. V polovine jsem to asi zastavil, ale i tak je to nenavratne poskozeno. Tak zas nekdy priste :/.Jak uz jsem byl ujisten, je to jeste horsi nez pred utesnovanim tita.Kacena travila vetsinu casu dole a lezlo mi to poradne na nervy..Vecer, po tom celodennim sbirani tutorialu na GIMP jsem jeste nasel neco na Paint.NET, nebo spise ono si to naslo me.Dosud jsem se mu uspesne schvalne vyhybal.";

            //input = @"Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků. Tento odstavec má vice než 500 znaků.";

            string actual = SH.SplitParagraphToMaxChars(input, 250);
            int i = 0;
        }

        [Fact]
        public void SubstringTest()
        {
            var input = "12345";
            var expected = "123";

            var actual = SH.Substring(input, 0, 3, true);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitAndKeepDelimiters()
        {
            var input = HtmlHelper.StripAllTags(splitAndKeepInput);
            var actual = SH.SplitAndKeepDelimiters(splitAndKeepInput, CA.ToListString(AllStrings.gt, AllStrings.lt));

            CA.ChangeContent(actual, d =>
            {
                if (d.EndsWith(AllChars.gt))
                {
                    d = string.Empty;
                }
                return d.TrimEnd(AllChars.lt).Trim();
            }
                );
            CA.RemoveStringsEmpty(actual);

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void ReplaceManyFromStringTest()
        {
            string testString = @"Assert.Equal -> Assert.AreEqual
Assert.AreEqual<*> -> CollectionAssert.AreEqual
[Fact] -> [TestMethod]
using Xunit; -> using Microsoft.VisualStudio.TestTools.UnitTesting;";
            testString = "Assert.AreEqual<*> -> CollectionAssert.AreEqual";

            string file = @"d:\Documents\Visual Studio 2017\Projects\sunamo.Tests\sunamo.Tests.Data\ReplaceManyFromString\In_ReplaceManyFromString.cs";
            var s = TF.ReadFile(file);

            s = SH.ReplaceManyFromString(s, testString, "->");

            TF.SaveFile(s, file);
        }

        [Fact]
        public void GetTextBetweenTwoCharsTest()
        {
            var input = "a {b} c";
            var expected = "b";

            var actual = SH.GetTextBetweenTwoChars(input, input.IndexOf('{'), input.IndexOf('}'));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void XCharsBeforeAndAfterWholeWordsTest()
        {
            var s = "12\"45" + Environment.NewLine + "12\"45";

            var occ = SH.ReturnOccurencesOfString(s, "\"");

            StringBuilder sb = new StringBuilder();
            foreach (var item in occ)
            {
                var r = SH.XCharsBeforeAndAfterWholeWords(s, item, 2);
                sb.AppendLine( r);
            }

            ClipboardHelper.SetText(sb);
        }

        [Fact]
        public void CharsBeforeAndAfterTest()
        {
            var s = "12\"45" + Environment.NewLine + "12\"45";

            
            
            //var sb = SH.CharsBeforeAndAfter(s, '\"', 2, 2);

            //ClipboardHelper.SetLines(sb);
        }

        //

        [Fact]
        public void GetLineIndexFromCharIndexTest()
        {
            var excepted = 2;
            // length is 10
            var input = @"ab
cd
ef";
            var l = input.Length;

            var lineF = SH.GetLineIndexFromCharIndex(input, 9);
            var lineE = SH.GetLineIndexFromCharIndex(input, 8);
            var lineD = SH.GetLineIndexFromCharIndex(input, 5);

            Assert.Equal(2, lineF);
            Assert.Equal(2, lineE);
            Assert.Equal(1, lineD);
        }

        [Fact]
        public void HasTextRightFormatTest()
        {
            FromTo requiredLength = new FromTo(1,2);
            var dash = CharFormatData.Get(null, new FromTo(1,1), AllChars.dash);
            var onlyNumbers = CharFormatData.GetOnlyNumbers(requiredLength);
            TextFormatData textFormat = new TextFormatData(false, -1, onlyNumbers, dash, onlyNumbers, dash, onlyNumbers, dash, onlyNumbers);

            string actual1 = " 01-1-1-1";
            string actual2 = "1-1-1-1";
            string actual3 = "123-1-1-1";
            string actual4 = "1-1-1";
            string actual5 = "1-1-1-1-1";
            string actual6 = "12-1-1-1";

            Assert.False(SH.HasTextRightFormat(actual1, textFormat));
            Assert.True(SH.HasTextRightFormat(actual2, textFormat));
            Assert.False(SH.HasTextRightFormat(actual3, textFormat));
            Assert.False(SH.HasTextRightFormat(actual4, textFormat));
            Assert.False(SH.HasTextRightFormat(actual5, textFormat));
            Assert.True(SH.HasTextRightFormat(actual6, textFormat));
        }

        [Fact]
        public void RemoveAfterFirstTest()
        {
            string actual = "1 - 2";
            string excepted = "1";
            actual = SH.RemoveAfterFirst(actual, excepted);
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void TextWithoutDiacriticTest()
        {
            var actual = "Příliš žluťoučký kůň úpěl ďábelské ódy";
            var expected = "Prilis zlutoucky kun upel dabelske ody";

            actual = SH.TextWithoutDiacritic(actual);
            Assert.Equal(expected, actual);
        }
    }
}
