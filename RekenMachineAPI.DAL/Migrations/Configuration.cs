using System.Data.Entity.Migrations;

namespace RekenMachineAPI.DAL.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}