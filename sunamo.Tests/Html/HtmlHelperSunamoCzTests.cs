using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class HtmlHelperSunamoCzTests
{
    /*

     */

    [Fact]
    public void ConvertTextToHtmlWithAnchorsTest()
    {
        //Užitečný nástroj který stahuje auta ze 
        var input = @"https://sauto.cz a vytváří tabulku v Google Sheets pro snadné porovnání dostupných dat pro zvolení auta jež je nejblíže Vašemu snu o nové mobilitě.";
        var actual = HtmlHelperSunamoCz.ConvertTextToHtmlWithAnchors(input);
        int s = 0;
    }
}