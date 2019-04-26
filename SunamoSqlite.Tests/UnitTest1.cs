using System;
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
            SQLiteConnection.CreateFile(dbPath);
            DatabaseLayer.dbFile = dbPath;
            DatabaseLayer.LoadNewConnection();
            SQLiteConnection conn = DatabaseLayer.conn;

            MSColumnsDB ms;
            //ms.GetSqlCreateTable()

            string tableName = "table";

            ColumnsDB c = new ColumnsDB(SloupecDB.CI(TypeAffinity.Int64, "ID"), SloupecDB.CI(TypeAffinity.Int64, "value"));
            SQLiteCommand comm = c.GetSqlCreateTable(tableName);

            comm.ExecuteNonQuery();


            StoredProceduresI.ci.Insert4(tableName, 0, 1);
            StoredProceduresI.ci.Insert4(tableName, 2, 3);

            var dt = StoredProceduresI.ci.SelectDataTableAllRows(tableName);
            Assert.Equal(1, dt.Rows[0][1]);
            Assert.Equal(2, dt.Rows[1][0]);
        }
    }
}
