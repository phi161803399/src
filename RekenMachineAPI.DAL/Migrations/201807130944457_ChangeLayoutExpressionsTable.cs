namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLayoutExpressionsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Expressions", newName: "Calculations");
            RenameColumn(table: "dbo.Calculations", name: "DateCreated", newName: "Date");
            RenameColumn(table: "dbo.Calculations", name: "Val", newName: "Result");
            RenameColumn(table: "dbo.Calculations", name: "ExpressionAsString", newName: "Calculation");
            AlterColumn("dbo.Calculations", "Calculation", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calculations", "Calculation", c => c.String(maxLength: 4000));
            RenameColumn(table: "dbo.Calculations", name: "Calculation", newName: "ExpressionAsString");
            RenameColumn(table: "dbo.Calculations", name: "Result", newName: "Val");
            RenameColumn(table: "dbo.Calculations", name: "Date", newName: "DateCreated");
            RenameTable(name: "dbo.Calculations", newName: "Expressions");
        }
    }
}
