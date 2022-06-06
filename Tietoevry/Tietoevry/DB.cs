using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

public class DB
{
    public static List<Meal> AllMealsList = new List<Meal>();
    public static List<DayMeals> WeekMenu = new List<DayMeals>();

    const string Data_File = "data.json";
    const string Data_File2 = "SuggestedMeals.json";


    public static void SaveMeals()
    {
        var textData = JsonConvert.SerializeObject(AllMealsList);
        File.WriteAllText(Data_File, textData);
    }
    public static void LoadMeals()
    {
        if (File.Exists(Data_File))
        {
            var textData = File.ReadAllText(Data_File);
            var objectData = JsonConvert.DeserializeObject<List<Meal>>(textData);
            AllMealsList = objectData;
        }
    }

    public static void SaveMealsWeek()
    {
        var textData = JsonConvert.SerializeObject(WeekMenu);
        File.WriteAllText(Data_File2, textData);
    }
}
