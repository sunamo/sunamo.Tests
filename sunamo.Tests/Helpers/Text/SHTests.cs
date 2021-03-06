﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using sunamo.Values;
using Xunit;

namespace sunamo.Tests.Helpers.Text
{
    public class SHTests
    {
        const string splitAndKeepInput = "Shared settings <%--RL:SharedSettings--%> <span> aplikace</span>";
        readonly List<string> expected = CA.ToListString("Shared settings", "aplikace");

        [Fact]
        public void IncrementLastNumberTest()
        {
            var v = "PK";
            SH.IncrementLastNumber(ref v);
            SH.IncrementLastNumber(ref v);
        }

        [Fact]
        public void AllHaveRightFormatTest()
        {
            //SH.AllHaveRightFormat(true, )
        }

        

        [Fact]
        public void ReplaceAllDoubleSpaceToSingleTest()
        {
            var input = "a   b  c d";
            var expected = "a b c d";

            var actual = SH.ReplaceAllDoubleSpaceToSingle(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplaceAllDoubleSpaceToSingle2Test()
        {
            var input = "a   b  c d";
            var expected = "a b c d";

            var actual = SH.ReplaceAllDoubleSpaceToSingle2(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAfterLastTests()
        {
            var input = "10 - cc - 24 Hours";
            var expected = "10 - cc";

            var actual = SH.RemoveAfterLast(" - ", input);
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void RemoveEndingPairCharsWhenDontHaveStarting()
        {
            var input = @"Nechť funkce  f(x)} je spojitá na kompaktním (tj. omezeném a uzavřeném) intervalu  \langle a,b\rangle } a nech f(a).f(b) < 0.Pak existuje alespoň jeden bod  c\in (a, b)} takový, že f(c)=0}";

            var excepted = @"Nechť funkce  f(x) je spojitá na kompaktním (tj. omezeném a uzavřeném) intervalu  \langle a,b\rangle  a nech f(a).f(b) < 0.Pak existuje alespoň jeden bod  c\in (a, b) takový, že f(c)=0";
            var actual = SH.RemoveEndingPairCharsWhenDontHaveStarting(input, AllStrings.lcub, AllStrings.rcub);

            input = @"c\in {(a, b)}} takový, že f(c)=0";
            excepted = @"c\in {(a, b)} takový, že f(c)=0";

            actual = SH.RemoveEndingPairCharsWhenDontHaveStarting(input, AllStrings.lcub, AllStrings.rcub);

            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void ReplaceAll3Test1()
        {
            var input = @"a

private public void SetMode(object mode2) { var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);

b";
            string replaceWhat = @"void SetMode(Mode mode)
  {";

            var replaceFor = @"public void SetMode(object mode2)
{
   var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);";

            var excepted = @"public void SetMode(object mode2)
{
 var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);";

            //input = SH.ReplaceAllDoubleSpaceToSingle2(input);
            //replaceFor = SH.ReplaceAllDoubleSpaceToSingle2(replaceFor);
            //excepted = SH.ReplaceAllDoubleSpaceToSingle2(excepted);
            //replaceWhat = SH.ReplaceAllDoubleSpaceToSingle2(replaceWhat);

            var result = SH.ReplaceAll( input, replaceFor, replaceWhat);
            result = result.Replace("private public", "public");

            result = SH.ReplaceAllDoubleSpaceToSingle2(result);
            
            Assert.Equal(excepted, result);
        }

        [Fact]
        public void SplitToPartsFromEndTest()
        {
            var expected1 = @"E:\Documents\vs\Haskell_Projects\LearnHaskell";
            var expected2 = @"3Types.hs";

            var input = expected1 + "\\" + expected2;
            var p = SH.SplitToPartsFromEnd(input, 2, AllChars.bs);

            Assert.Equal(expected1, p[0]);
            Assert.Equal(expected2, p[1]);

            input = expected2;
            expected1 = string.Empty;
            // expected2 keep as is

            p = SH.SplitToPartsFromEnd(input, 2, AllChars.bs);
            Assert.Equal(expected1, p[0]);
            Assert.Equal(expected2, p[1]);
        }

        /// <summary>
        /// more left
        /// </summary>
        [Fact]
        public void GetPairsStartAndEnd()
        {
            var input = "{ } } {";
            string cbl = AllStrings.lcub;
            string cbr = AllStrings.rcub;

            var expected = new List<Tuple<int, int>>();
            expected.Add(new Tuple<int, int>(0, 2));

            List<int> onlyLeftExcepted = CA.ToList<int>(6);
            List<int> onlyRightExcepted = CA.ToList<int>(4);


            var occL = SH.ReturnOccurencesOfString(input, cbl);
            var occR = SH.ReturnOccurencesOfString(input, cbr);

            List<int> onlyLeft = null;
            List<int> onlyRight = null;
            var actual = SH.GetPairsStartAndEnd(occL, occR, ref onlyLeft, ref onlyRight);

            AssertExtensions.EqualTuple<int, int>(expected, actual);
            Assert.Equal<int>(onlyLeftExcepted, onlyLeft);
            Assert.Equal<int>(onlyRightExcepted, onlyRight);
        }

        /// <summary>
        /// more left
        /// </summary>
        [Fact]
        public void GetPairsStartAndEnd_2()
        {
            var input = "{ { } { } }";
            string cbl = AllStrings.lcub;
            string cbr = AllStrings.rcub;

            var expected = new List<Tuple<int, int>>();
            expected.Add(new Tuple<int, int>(2, 4));
            expected.Add(new Tuple<int, int>(6, 8));

            List<int> onlyLeftExcepted = CA.ToList<int>(0);
            List<int> onlyRightExcepted = CA.ToList<int>(10);


            var occL = SH.ReturnOccurencesOfString(input, cbl);
            var occR = SH.ReturnOccurencesOfString(input, cbr);

            List<int> onlyLeft = null;
            List<int> onlyRight = null;
            var actual = SH.GetPairsStartAndEnd(occL, occR, ref onlyLeft, ref onlyRight);

            AssertExtensions.EqualTuple<int, int>(expected, actual);

            onlyLeft.Sort();

            Assert.Equal<int>(onlyLeftExcepted, onlyLeft);
            Assert.Equal<int>(onlyRightExcepted, onlyRight);
        }

        /// <summary>
        /// more right
        /// </summary>
        [Fact]
        public void GetPairsStartAndEnd_3()
        {
            var input = "{ { } } } {";
            string cbl = AllStrings.lcub;
            string cbr = AllStrings.rcub;

            var expected = new List<Tuple<int, int>>();
            expected.Add(new Tuple<int, int>(0, 6));
            expected.Add(new Tuple<int, int>(2, 4));
            

            List<int> onlyLeftExcepted = CA.ToList<int>(10);
            List<int> onlyRightExcepted = CA.ToList<int>(8);

            var occL = SH.ReturnOccurencesOfString(input, cbl);
            var occR = SH.ReturnOccurencesOfString(input, cbr);

            List<int> onlyLeft = null;
            List<int> onlyRight = null;
            var actual = SH.GetPairsStartAndEnd(occL, occR, ref onlyLeft, ref onlyRight);

            AssertExtensions.EqualTuple<int, int>(expected, actual);

            onlyLeft.Sort();

            Assert.Equal<int>(onlyLeftExcepted, onlyLeft);
            Assert.Equal<int>(onlyRightExcepted, onlyRight);
        }

        [Fact]
        public void SplitAndKeepTest()
        {
            var actual = SH.SplitAndKeep(splitAndKeepInput, AspxConsts.all);
            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void ShortToLengthByParagraphTest()
        {
            var input = "abcd";
            var expected = "ab";

            var actual = SH.ShortToLengthByParagraph(expected, 2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplaceAllExceptPrefixed()
        {
            var input = @"System.Drawing.Image
Image";

            var excepted =  @"System.Drawing.Image
HtmlImage";

            var actual = SH.ReplaceAllExceptPrefixed(input,  "HtmlImage", "Image", "System.Drawing.");
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void ListToStringTest()
        {
            var input = TestData.list12;
            var excepted = "1,2";

            var actual = SH.ListToString(input, AllStrings.comma);
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void TabOrSpaceNextToTest()
        {
            var b = "b nopCommerce";
            var c = "SimplCommerce";
            var d = "SmartStoreNET";
            var e = "grandnode";

            var a = CA.ToList<string>(b, c, d, e);

            for (int i = 0; i < a.Count; i++)
            {
                Debug.WriteLine(a[i].Length);
            }

            var input = SH.Join("\t", a);
            //input = "a\tb\tc";
            var r = SH.TabOrSpaceNextTo(input);
            var vr = SH.SplitByIndexes(input, r);
            int i2 = 0;
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
            // Cant import core into project due to mix up standard and sunamo
            //ClipboardHelper.Instance = ClipboardHelperCore.Instance;

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
        public void TrimStartAndEndTest()
        {
            var input = ".He!*";
            var expected = "He";

            var actual = SH.TrimStartAndEnd(input, char.IsLetterOrDigit, char.IsLetterOrDigit);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitAndKeepDelimiters()
        {
            var input = HtmlHelper.StripAllTags(splitAndKeepInput);
            var actual = SH.SplitAndKeepDelimiters(splitAndKeepInput, CA.ToListString(AllStrings.gt, AllStrings.lt));

            CA.ChangeContent(null,actual, d =>
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

            string file = @"e:\Documents\vs\Projects\sunamo.Tests\sunamo.Tests.Data\ReplaceManyFromString\In_ReplaceManyFromString.cs";
            var s = TF.ReadFile(file);

            s = SH.ReplaceManyFromString(s, testString, Consts.transformTo);

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
        public void GetTextBetweenTest()
        {
            var input = "n.cojetipotom\", \"name\": \"Jan Cojetipotom\" } },";
            var expected = "Jan Cojetipotom";

            var actual = SH.GetTextBetween(input, "\"name\": \"", "\"");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void XCharsBeforeAndAfterWholeWordsTest()
        {
            //ClipboardHelper.Instance = ClipboardHelperWin.

            var s = "12\"45" + Environment.NewLine + "12\"45";

            var occ = SH.ReturnOccurencesOfString(s, "\"");

            StringBuilder sb = new StringBuilder();
            foreach (var item in occ)
            {
                var r = SH.XCharsBeforeAndAfterWholeWords(s, item, 2);
                sb.AppendLine( r);
            }

            // Cant use Clipboard, its sunamo and cant reference win
            //ClipboardHelper.SetText(sb);
        }

        [Fact]
        public void CharsBeforeAndAfterTest()
        {
            var s = "12\"45" + Environment.NewLine + "12\"45";
            //var sb = SH.CharsBeforeAndAfter(s, '\"', 2, 2);

            //ClipboardHelper.SetLines(sb);
        }

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
            FromTo requiredLength = new FromTo(1,1);
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
            Assert.False(SH.HasTextRightFormat(actual6, textFormat));
        }

        /// <summary>
        /// due to { on end, can be formatted with Format3 only
        /// </summary>
        const string formatTemplate = @"export default class {0} extends Component {";
        const string formatExpected = @"export default class a extends Component {";
        const string formatExpectedWildcard = @"export default class *.cs extends Component {";

        [Fact]
        public static void PairsBracketToCompleteBlockTest()
        {
            var input = @"const doFetchErrorStories = () => ({";

            var excepted = input + @"
});";
            var actual = SH.PairsBracketToCompleteBlock(input);
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void FormatTest()
        {
            // Cant be - { on end
            //var actual = SH.Format(formatTemplate, AllStrings.lsqb, AllStrings.rsqb, TestData.a);
            //Assert.Equal(formatExpected, actual);
        }

        [Fact]
        public void Format2Test()
        {
            // Cant be - { on end
            //var actual = SH.Format2(formatTemplate, TestData.a);
            //Assert.Equal(formatExpected, actual);
        }

        [Fact]
        public void Format3Test()
        {
            var actual = SH.Format3(formatTemplate, TestData.a);
            Assert.Equal(formatExpected, actual);

            actual = SH.Format3(formatTemplate, TestData.wildcard);
            Assert.Equal(formatExpectedWildcard, actual);


        }

        [Fact]
        public void Format4Test()
        {
            // Cant be - { on end
            //var actual = SH.Format4(formatTemplate, TestData.a);
            //Assert.Equal(formatExpected, actual);
        }

        [Fact]
        public void  MatchWildcardTest()
        {
            var input = "sunamo.web";
            var actual = SH.MatchWildcard(input, "*.web");

            Assert.True(actual);

            
        }

        [Fact]
        public void IsWildcardTest()
        {
            var actual = SH.IsWildcard("aaa*.cs");
            Assert.True(actual);
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