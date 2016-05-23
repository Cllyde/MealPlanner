﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [DataType(DataType.MultilineText)]
        public string Directions { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [NotMapped]
        public string IngredientsDisplay
        {
            get
            {
                if (Ingredients.Length > CONSTANTS.CHAR_DISPLAY_LIMIT)
                {
                    return Ingredients.Substring(0, CONSTANTS.CHAR_DISPLAY_LIMIT) + "...";
                }
                else
                {
                    return Ingredients;
                }
            }
        }

        [NotMapped]
        public string DirectionsDisplay
        {
            get
            {
                if (Directions.Length > CONSTANTS.CHAR_DISPLAY_LIMIT)
                {
                    return Directions.Substring(0, CONSTANTS.CHAR_DISPLAY_LIMIT) + "...";
                }
                else
                {
                    return Directions;
                }
            }
        }
    }
}