using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Functions
{
    public static void AddDish()
    {

        Meal Dish = new Meal();

        Console.WriteLine("Enter name of the dish");
        Dish.Name = Console.ReadLine();
        Console.WriteLine("Enter the number of calories");
        Dish.Calories = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of proteins");
        Dish.Protein = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of carbohydrates");
        Dish.Carbohydrate = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of fats");
        Dish.Fat = Int32.Parse(Console.ReadLine());

        DB.AllMealsList.Add(Dish);
        DB.SaveMeals();
    }
    public static void ViewAllMealsList()
    {
        for (int i = 0; i < DB.AllMealsList.Count; i++)
        {
            Console.WriteLine("Name: {0}\nCalories: {4} \nProtein:{1} \nCarbohydrate:{2} \nFats:{3} \n", DB.AllMealsList[i].Name, DB.AllMealsList[i].Protein, DB.AllMealsList[i].Carbohydrate, DB.AllMealsList[i].Fat, DB.AllMealsList[i].Calories);
        }
    }

    public static void GenerateMenu(int InputCalories)
    {

        Random rnd = new Random();

        if (InputCalories >= 500 && InputCalories <= 3000)
        {
            double Protein = InputCalories * 0.2 / 4;
            double Carbohydrate = InputCalories * 0.6 / 4;
            double Fat = InputCalories * 0.2 / 9;

            for (int i = 0; DB.WeekMenu.Count < 7; i++)
            {
                int Calories = InputCalories;
                List<Meal> TempMenu = new List<Meal>();

                while (Calories > 100)
                {
                    int index = rnd.Next(0, DB.AllMealsList.Count);
                    Meal Dish = DB.AllMealsList[index];


                    if (Calories - Dish.Calories >= 0 && Protein - Dish.Protein >= 0 && Carbohydrate - Dish.Carbohydrate >= 5 && Fat - Dish.Fat >= 5)
                    {
                        TempMenu.Add(Dish);
                        Calories = Calories - Dish.Calories;
                    }

                }

                string[] DaysArray = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

                DB.WeekMenu.Add(new DayMeals
                {
                    Day = DaysArray[i],
                    MealForDay = TempMenu
                });
            }
            DB.SaveMealsWeek();

        }
        else { Console.WriteLine("Wrong input. Choose a number between 500 and 3000"); }

    }

}

