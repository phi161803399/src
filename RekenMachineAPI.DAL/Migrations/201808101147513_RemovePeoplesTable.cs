namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThisIsATest : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
