using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

public partial class RoslynLearn
{

    public class Sample
    {
        public void Foo()
        {
            Console.WriteLine();
            #region SomeRegion
            //Some other code
            #endregion

        }
    }


}