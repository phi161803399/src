using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using RekenMachineAPI.DAL;
using Configuration = RekenMachineAPI.DAL.Migrations.Configuration;

namespace RekenMachineAPI.Tests.Component.Helpers
{
    public class DatabaseManager
    {
        private static readonly ConnectionStringSettings ConnectionString;

        static DatabaseManager()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Context"];
        }

        public static void Create()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }

        public static void Drop()
        {
            using (var db = new Context())
            {
                db.Database.Delete();
            }
        }

        public static void Truncate()
        {
            using (var conn = new SqlConnection(ConnectionString.ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand(@"truncate table samples", conn);
                command.ExecuteNonQuery();
            }
        }
    }
}