namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingCalculationTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CalculationTypes VALUES ('product')");
            Sql("INSERT INTO CalculationTypes VALUES ('division')");
            Sql("INSERT INTO CalculationTypes VALUES ('addition')");
            Sql("INSERT INTO CalculationTypes VALUES ('subtraction')");
            Sql("INSERT INTO CalculationTypes VALUES ('mixed')");
        }
        
        public override void Down()
        {
        }
    }
}
