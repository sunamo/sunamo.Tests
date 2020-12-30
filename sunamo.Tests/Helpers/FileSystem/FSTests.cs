using sunamo.Enums;
using sunamo.Helpers;
using sunamo.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace sunamo.Tests.Helpers.FileSystem
{
    public class FSTests
    {
        #region ctor
        public FSTests()
        {
            AllExtensionsHelper.Initialize();
        }
        #endregion

        #region GetNameWithoutSeries
        [Fact]
        public void GetNameWithoutSeries()
        {
            string input1 = "abc(1).txt";
            string expected = "abc.txt";
            string result1 = FS.GetNameWithoutSeries(input1, true);
            Assert.Equal(expected, result1);
        }

        [Fact]
        public void GetNameWithoutSeries1()
        {
            bool hasSerie;
            int serie;
            string input = "abc(1).txt";
            string result = "";
            string expected = "abc.txt";
            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.Brackets, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);

            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.All, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);




        }

        [Fact]
        public void GetNameWithoutSeries2()
        {
            bool hasSerie;
            int serie;
            string input = "abc-1.txt";
            string result = "";
            string expected = "abc.txt";
            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.Dash, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);

            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.All, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);

            input = "abc.txt";
            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.Dash, out serie);
            Assert.Equal(expected, result);
            Assert.False(hasSerie);
            Assert.Equal(-1, serie);


        }

        [Fact]
        public void GetNameWithoutSeries3()
        {
            bool hasSerie;
            int serie;
            string input = "abc-1.txt.txt";
            string result = "";
            string expected = "abc.txt.txt";
            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.Dash, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);
        }

        [Fact]
        public void GetNameWithoutSeries4()
        {
            bool hasSerie;
            int serie;
            string input = @"d:\a\b\abc-1.txt.txt";
            string result = "";
            string expected = @"d:\a\b\abc.txt.txt";
            result = FS.GetNameWithoutSeries(input, true, out hasSerie, Enums.SerieStyle.Dash, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);
        }

        [Fact]
        public void GetNameWithoutSeries5()
        {
            bool hasSerie;
            int serie;
            string input = @"d:\a\b\abc-1.txt.txt";
            string result = "";
            string expected = @"abc.txt.txt";
            result = FS.GetNameWithoutSeries(input, false, out hasSerie, Enums.SerieStyle.Dash, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);
        }

        [Fact]
        public void GetNameWithoutSeries6()
        {
            bool hasSerie;
            int serie;
            string input = @"d:\a\b\abc_001_01.txt.txt";
            string result = "";
            string expected = @"abc.txt.txt";
            result = FS.GetNameWithoutSeries(input, false, out hasSerie, Enums.SerieStyle.Underscore, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);
        }

        [Fact]
        public void MascFromExtensionTest()
        {
            Func<string, string> m = FS.MascFromExtension;
            var a = m.Invoke("cs");
            var a1 = m(".cs");

            var expected = "*.cs";
            Assert.Equal(expected, a);
            Assert.Equal(expected, a1);
        }

        //
        [Fact]
        public void GetNameWithoutSeries7()
        {
            bool hasSerie;
            int serie;
            string input = @"d:\a\b\MainPage.xaml_008.cs";
            string result = "";
            string expected = @"MainPage.xaml.cs";
            result = FS.GetNameWithoutSeries(input, false, out hasSerie, Enums.SerieStyle.Underscore, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(8, serie);
        }
        #endregion

        [Fact]
        public void PathSpecialAndLevelTest()
        {
            var input = @"d:\pa\_toolsSystem\cmder\vendor\clink-completions\modules\";
            var basePath = @"d:\pa\";
            var d = FS.PathSpecialAndLevel(basePath, input, 1);
            var expected = @"d:\pa\_toolsSystem\cmder";
            Assert.Equal(expected, d);
        }

        [Fact]
        public void GetSizeInAutoStringTest()
        {
            long o = 1024;

            long kb = o;
            long mb = kb * o;
            long gb = mb * o;

            var b = ComputerSizeUnits.B;

            var kbs = FS.GetSizeInAutoString(kb, b);
            var mbs = FS.GetSizeInAutoString(mb, b);
            var gbs = FS.GetSizeInAutoString(gb, b);
            var gbsMinusOne = FS.GetSizeInAutoString(gb-1, b);

            int i = 0;
        }

        [Fact]
        public void AllExtensionsInFolders()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\AllExtensionsInFolders\";
            var excepted = CA.ToListString(".html", ".bowerrc", ".php");
            var actual = FS.AllExtensionsInFolders(System.IO.SearchOption.TopDirectoryOnly, folder);
            Assert.Equal<string>(excepted, actual);
        }

        [Fact]
        public void DeleteSerieDirectoryOrCreateNewTest()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\DeleteSerieDirectoryOrCreateNew\";
            FS.DeleteSerieDirectoryOrCreateNew(folder);
        }

        [Fact]
        public void ReplaceIncorrectCharactersFileTest()
        {
            var input = "abcde";
            var exclued = "bd";
            var expected = "a c e";

            var actual = FS.ReplaceIncorrectCharactersFile(input, exclued, AllStrings.space);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertBetweenFileNameAndExtensionTest()
        {
            var original = "2017-08-11 T18_48_48 307 segments.gpx";
            var input = @"With friend from seznamka.cz on Poruba's forest";
            var whatInsert = "-abcd";

            var actual = FS.InsertBetweenFileNameAndExtension(input, whatInsert);
            var expected = "With friend from seznamka.cz on Poruba's forest" + whatInsert;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DeleteFilesWithSameContent()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContent\";

            var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1 = true });
            FS.DeleteFilesWithSameContent(files);

            files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1 = true });

            var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
            Assert.Equal<string>(filesExcepted, files);
        }

        [Fact]
        public void DeleteFilesWithSameContentBytes()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContentBytes\";

            var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1 = false });
            FS.DeleteFilesWithSameContentBytes(files);

            files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1 = true });

            var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
            Assert.Equal<string>(filesExcepted, files);
        }

        [Fact]
        public void DeleteAllEmptyDirectoriesTest()
        {
            string folder = @"d:\_Test\sunamo\sunamo\Helpers\FileSystem\FS\DeleteAllEmptyDirectories\";
            
                FS.DeleteAllEmptyDirectories(folder);
            
            
            int actual = FS.GetFolders(folder, SearchOption.AllDirectories).Count;
            Assert.Equal(2, actual);
        }

        [Fact]
        public void DeleteEmptyFilesTest()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteEmptyFiles\";
            FS.DeleteEmptyFiles(folder, System.IO.SearchOption.TopDirectoryOnly);
            List<string> actual = FS.OnlyNames( FS.GetFiles(folder));
            List<string> excepted = CA.ToListString("ab.txt", "DeleteEmptyFiles.zip");
            Assert.Equal(excepted, actual);

        }
    }
}