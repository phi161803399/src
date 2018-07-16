namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalculationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalculationString = c.String(maxLength: 4000),
                        Created = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CalculationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalculationTypes", t => t.CalculationTypeId, cascadeDelete: true)
                .Index(t => t.CalculationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calculations", "CalculationTypeId", "dbo.CalculationTypes");
            DropIndex("dbo.Calculations", new[] { "CalculationTypeId" });
            DropTable("dbo.Calculations");
        }
    }
}
