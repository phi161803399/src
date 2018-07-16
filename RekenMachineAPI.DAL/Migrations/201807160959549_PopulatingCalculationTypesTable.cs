namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingCalculationTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CalculationTypes VALUES ('*')");
            Sql("INSERT INTO CalculationTypes VALUES ('/')");
            Sql("INSERT INTO CalculationTypes VALUES ('+')");
            Sql("INSERT INTO CalculationTypes VALUES ('-')");
            Sql("INSERT INTO CalculationTypes VALUES ('mixed')");
        }
        
        public override void Down()
        {
        }
    }
}
