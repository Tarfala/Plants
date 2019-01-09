using PlantApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantApp
{
    partial class App
    {
        private void ShowAllPlantsOnName()
        {
            Header("List of plants in database");
            List<Plant> plant = _dataAccess.GetAllPlantSorted();
            var sortedList = plant.OrderBy(x => x.Name).ToList();
            PrintGreenText("Plant ID".PadRight(30) + "Plant Name".PadRight(5));
            foreach (Plant bp in sortedList)
            {
                WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            }
            WriteLine("");
            Console.ReadKey();
            ShowPlantsMenu();
        }
        private void ShowOnCategory()
        {
            Header("Select the category you want to see");
            List <PlantType> category = _dataAccess.GetCategort();
            PrintGreenText("Type ID".PadRight(30) + "Type".PadRight(5));

            foreach (PlantType bp in category)
            {
                WriteLine(bp.PlantTypeId.ToString().PadRight(30) + bp.PlantTypes.PadRight(5));
            }
            WriteLine("");
            int input = int.Parse(Console.ReadLine());
            List<Plant> plantCategory = _dataAccess.GetPlantByCategory(input);
            Console.Clear();
            Header("Showing all plants in that category");
            PrintGreenText("Plant id".PadRight(30) + "Plant Name".PadRight(5));

            foreach (Plant bp in plantCategory)
            {
                WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            }
            WriteLine("");
            Console.ReadKey();
            ShowPlantsMenu();

        }
        private void AddPlant()
        {
        }
    }
}
