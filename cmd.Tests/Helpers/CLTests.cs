using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class CLTests
{
    //[TestMethod]
    public void CmdTableTest()
    {
        var els = "Extra long string";
        els = "C";

        List<List<string>> l = new List<List<string>>();
        l.Add(CA.ToList<string>("A", els));
        l.Add(CA.ToList<string>("B", els));

        CL.CmdTable(l);
    }


}