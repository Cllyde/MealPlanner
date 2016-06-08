namespace MealPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadioToCheckbox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "IsBreakfast", c => c.Boolean(nullable: false));
            AddColumn("dbo.Meals", "IsLunch", c => c.Boolean(nullable: false));
            AddColumn("dbo.Meals", "IsDinner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Meals", "IsSide", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Meals", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Meals", "MealCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "MealCategory", c => c.Int(nullable: false));
            AlterColumn("dbo.Meals", "Name", c => c.String());
            DropColumn("dbo.Meals", "IsSide");
            DropColumn("dbo.Meals", "IsDinner");
            DropColumn("dbo.Meals", "IsLunch");
            DropColumn("dbo.Meals", "IsBreakfast");
        }
    }
}
