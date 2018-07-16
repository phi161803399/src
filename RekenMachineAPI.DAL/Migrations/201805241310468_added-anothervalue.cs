namespace RekenMachineAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanothervalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "AnotherValue", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Samples", "AnotherValue");
        }
    }
}
