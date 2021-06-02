using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TestSqlHelper
{
    //[Fact]
    public static void Init(UnitTestInit i)
    {
        XlfResourcesHSunamo.SaveResouresToRLSunamo();

        CryptHelper.ApplyCryptData(CryptHelper.RijndaelBytes.Instance, CryptDataWrapper.rijn);


        // First must ApplyCryptData
        if (i.cryptData)
        {
            CryptHelper.ApplyCryptData(CryptHelper.RijndaelBytes.Instance, CryptDataWrapper.rijn);
        }

        // Then I can connect
        if (i.databases.HasValue)
        {
            DatabasesConnections.SetConnToMSDatabaseLayer(i.databases.Value);
        }
    }
}