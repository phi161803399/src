using System.Data.Entity.Migrations;

namespace RekenMachineAPI.DAL.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Samples",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Value = c.String(maxLength: 10)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Samples");
        }
    }
}