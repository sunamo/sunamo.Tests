using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace SunamoSqlServer.Tests
{
    [TestClass]
    public class SqlServerHelperTests
    {
        [TestMethod]
        public void SqlCommandToTSQLTextTest()
        {
            SqlCommand c = new SqlCommand(GeneratorMsSql.CombinedWhere(AB.Get("a", "b"), AB.Get("1", 2)));
            //"select * from table where @a = "

            //c.Parameters.AddWithValue();
            //c.Parameters.AddWithValue();

            var d = SqlServerHelper.SqlCommandToTSQLText(c);
            int i = 0;
        }
    }
}