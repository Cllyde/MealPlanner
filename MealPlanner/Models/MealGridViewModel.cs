using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class MealGridViewModel
    {
        public MealGridViewModel()
        {
            DailyMeals = new List<MealsForADay>();
        }
        public List<MealsForADay> DailyMeals { get; set; }
    }

    public class MealsForADay
    {
        public string DayName { get; set; }
        public Meal Breakfast { get; set; }
        public Meal Lunch { get; set; }
        public Meal Dinner { get; set; }
        public Meal Side { get; set; }
    }
}