using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [UIHint("MealPanel")]
        public Meal Breakfast { get; set; }
        [UIHint("MealPanel")]
        public Meal Lunch { get; set; }
        [UIHint("MealPanel")]
        public Meal Dinner { get; set; }
        [UIHint("MealPanel")]
        public Meal Side { get; set; }
    }
}