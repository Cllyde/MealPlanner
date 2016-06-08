namespace MealPlanner.Migrations
{
    using MealPlanner.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MealPlanner.Models.MealPlannerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MealPlanner.Models.MealPlannerContext";
        }

        protected override void Seed(MealPlanner.Models.MealPlannerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Meals.AddOrUpdate(
                m => m.ID,
                    new Meal { ID = 9, Name = "Big Mac", Directions = "Drive to McDonalds and order one.", Ingredients = "2 all beef patties, special sauce, pickles, lettuce.", IsDinner = true, Url = "http://www.mcdonalds.com" },
                    new Meal { ID = 5, Name = "FiberOne protein bar", Directions = "Open the wrapper and munch on it.", Ingredients = @"Fiber. Protein. Bar.", IsBreakfast = true, Url = "http://www.fiberone.com" },
                    new Meal { ID = 11, Name = "Frozen Pizza", Directions = "Bake it in the oven for some time.", Ingredients = "my pizza.", IsDinner = true, Url = "http://www.tostinos.com" },
                    new Meal { ID = 3, Name = "Gatorade®", Directions = "Drink it straight from the bottle.", Ingredients = "12 oz of fluid.", IsSide = true, Url = "http://www.gatorade.com" },
                    new Meal { ID = 15, Name = "Homemade sandwich", Directions = "Put stuff on bread.", Ingredients = "Whatever you want, really.", IsDinner = true, Url = "http://lmgtfy.com/?q=Sandwich" },
                    new Meal { ID = 6, Name = "Macaroni and cheese", Directions = @"Boil the water. Cook the macaroni's for 10 minutes or until al dente. Drain the macaroni's. Put 3/4 cup of milk, 1 tbsp. of butter, and cheese sauce into pan and melt it all together.", Ingredients = @"Macaroni. Cheese.", IsDinner = true, Url = "http://www.kraft.com" },
                    new Meal { ID = 8, Name = "Meatball marinara", Directions = "Order it from subway.", Ingredients = @"Bread. Meatballs. Marinara sauce. Mozzarella cheese.", IsLunch = true, Url = "http://www.subway.com" },
                    new Meal { ID = 14, Name = "Oatmeal", Directions = "Put the water in the package of oatmeal and microwave it until it gets absorbed and looks like a good enough consistency to eat.", Ingredients = "1-2 packages of instant oatmeal. 1-2 cups of water, depending on taste.", IsBreakfast = true, Url = "http://www.quakeroats.com" },
                    new Meal { ID = 7, Name = "Pasta", Directions = @"Boil the noodles until al dente. Drain water. Add sauce.", Ingredients = @"1 16 oz. package of noodles. 1 16 oz. can of pasta sauce.", IsDinner = true, Url = "http://www.hunts.com" },
                    new Meal { ID = 1, Name = "Pop-Tarts®", Directions = "Put them in the toaster.", Ingredients = "2 Pop-Tarts® toaster pastries", IsBreakfast = true, Url = "http://www.poptarts.com" },
                    new Meal { ID = 13, Name = "Pretzel and cheese", Directions = "Someone at Sam's club will serve it to you.", Ingredients = "1 Pretzel. A cheese sauce packet.", IsDinner = true, Url = "http://www.samsclub.com" },
                    new Meal { ID = 16, Name = "Spanish Rice", Directions = "cook it in water.", Ingredients = "Spanish. Rice.", IsSide = true, Url = "" },
                    new Meal { ID = 4, Name = "Triple-zero yogurt", Directions = "Spoon it into your face.", Ingredients = "Zero", IsBreakfast = true, Url = "http://www.oikos.com" },
                    new Meal { ID = 12, Name = "Tuesday lunch", Directions = "Depends where you want to go.", Ingredients = "Depends where you want to go.", IsDinner = true, Url = "http://www.wtfsigte.com" },
                    new Meal { ID = 2, Name = "Turkey Sandwich", Directions = "Put the turkey between the bread, and whatever else you want in there, and that's it.", Ingredients = @"Piece of bread. Sliced turkey breast. Whatever else you want on it", IsLunch = true, Url = "http://www.butterball.com" },
                    new Meal { ID = 10, Name = "Whopper", Directions = "Haven't you ever heard of Burger King?", Ingredients = "Bun, sauce, lettuce, cheese, meat.", IsDinner = true, Url = "http://www.burgerking.com" }
                );
        }
    }
}
