namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveExpressionTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Calculations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Calculations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Operation = c.Int(nullable: false),
                        Result = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Calculation = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
