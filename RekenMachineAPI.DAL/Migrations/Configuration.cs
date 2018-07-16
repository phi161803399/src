using System.Data.Entity.Migrations;

namespace RekenMachineAPI.DAL.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}