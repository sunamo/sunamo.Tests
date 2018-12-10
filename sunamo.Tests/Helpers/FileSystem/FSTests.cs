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
            string input = @"D:\a\b\abc-1.txt.txt";
            string result = "";
            string expected = @"D:\a\b\abc.txt.txt";
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
            string input = @"D:\a\b\abc-1.txt.txt";
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
            string input = @"D:\a\b\abc_001_01.txt.txt";
            string result = "";
            string expected = @"abc.txt.txt";
            result = FS.GetNameWithoutSeries(input, false, out hasSerie, Enums.SerieStyle.Underscore, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(1, serie);
        }

        //
        [Fact]
        public void GetNameWithoutSeries7()
        {
            bool hasSerie;
            int serie;
            string input = @"D:\a\b\MainPage.xaml_008.cs";
            string result = "";
            string expected = @"MainPage.xaml.cs";
            result = FS.GetNameWithoutSeries(input, false, out hasSerie, Enums.SerieStyle.Underscore, out serie);
            Assert.Equal(expected, result);
            Assert.True(hasSerie);
            Assert.Equal(8, serie);
        }
        #endregion

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
            string folder = @"D:\_Test\sunamo\Helpers\FileSystem\DeleteSerieDirectoryOrCreateNew\";
            FS.DeleteSerieDirectoryOrCreateNew(folder);

        }

        [Fact]
        public void DeleteFilesWithSameContent()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContent\";

            var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, false);
            FS.DeleteFilesWithSameContent(files);

            files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, true);

            var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
            Assert.Equal<string>(filesExcepted, files);
        }

        [Fact]
        public void DeleteFilesWithSameContentBytes()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContentBytes\";

            var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, false);
            FS.DeleteFilesWithSameContentBytes(files);

            files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, true);

            var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
            Assert.Equal<string>(filesExcepted, files);
        }

        [Fact]
        public void DeleteAllEmptyDirectoriesTest()
        {
            string folder = @"d:\_Test\sunamo\Helpers\FileSystem\FS\DeleteAllEmptyDirectories\";
            
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
