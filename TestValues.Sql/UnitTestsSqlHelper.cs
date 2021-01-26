using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

//[TestClass]
public class UnitTestsSqlHelper
{
    [Fact]
    public void Init(UnitTestInit i)
    {
        if (i.databases.HasValue)
        {
            DatabasesConnections.SetConnToMSDatabaseLayer(i.databases.Value);
        }
        if (i.cryptData)
        {
            CryptHelper.ApplyCryptData(CryptHelper.RijndaelBytes.Instance, CryptDataWrapper.rijn);
        }
    }
}
