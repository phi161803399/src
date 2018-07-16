namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSamplesTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Samples");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 10),
                        AnotherValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
