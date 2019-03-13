using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System;

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