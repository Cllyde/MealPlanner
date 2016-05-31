namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MealCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "MealCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "MealCategory");
        }
    }
}
