using System;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pokud proměnná bude v metodě a ne v třídě, nedávat comment

            RoslynHelperTests r = new RoslynHelperTests();
            r.AddXmlDocumentationCommentTest();
        }
    }
}
