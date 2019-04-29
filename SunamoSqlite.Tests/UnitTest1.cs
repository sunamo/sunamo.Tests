using DocArch.SqLite;
using System;
using System.Data;
using System.Data.SQLite;
using Xunit;

namespace SunamoSqlite.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateDbSqliteTest()
        {
            var dbPath = @"d:\_Test\sunamo\SunamoSqlite\test.db";

            DatabaseLayer.Init(dbPath);

            string tableName = "table2";

            ColumnsDB c = new ColumnsDB(SloupecDB.CI(TypeAffinity.Int64, "ID"), SloupecDB.CI(TypeAffinity.Int64, "value"));
            SQLiteCommand comm = c.GetSqlCreateTable(tableName);
            if (comm.CommandText != null)
            {
                comm.ExecuteNonQuery();
            }

            long first = 1;
            long second = 2;

            StoredProceduresSqliteI.ci.Insert4(tableName, 0, 1);
            StoredProceduresSqliteI.ci.Insert4(tableName, 2, 3);

            var dt = StoredProceduresSqliteI.ci.GetDataTableAllRows(tableName);
            Assert.Equal(first, dt.Rows[0][1]);
            Assert.Equal(second, dt.Rows[1][0]);
        }

        public void CreateJoinedTablesTest()
        {

        }
    }
}
