using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Roslyn.Tests
{
    public class ChildNodesTests
    {
        [Fact]
        public void MethodsTest()
        {
            Dictionary<string, List<string>> m = new Dictionary<string, List<string>>();

            var s = @"
class C1{
   private int var1;
   public string var2;

   void action1()
    {
       int var3;
       var3=var1*var1;
       var2=""Completed"";
   }
}
";

            var tree = CSharpSyntaxTree.ParseText(s);
            var root = tree.GetRoot();

            int i = 0;
        }
    }
}
