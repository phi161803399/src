namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpressionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expressions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Operation = c.Int(nullable: false),
                        Val = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpressionAsString = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expressions");
        }
    }
}
