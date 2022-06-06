using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayMeals
{
    public string Day { get; set; }
    public List<Meal> MealForDay { get; set; } = new List<Meal>();
}
