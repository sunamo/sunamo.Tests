using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Generic number can be compare in this way
/// </summary>
public class CompareTo
{
    void TestCompareTo()
    {
        var a = 1;
        var b = 2;
        var i = a.CompareTo(b);
        // A is lower, return -1
        Console.WriteLine(i);
    }
}

