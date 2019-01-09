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
            foreach (Plant bp in sortedList)
            {
                WriteLine(bp.PlantId.ToString().PadRight(5) + bp.Name.PadRight(30));
            }
            WriteLine("");
            Console.ReadKey();
            ShowPlantsMenu();
        }
        private void ShowOnCategory()
        {
            Header("Select the category you want to see");
            List <PlantType> category = _dataAccess.GetCategort();
            foreach (PlantType bp in category)
            {
                WriteLine(bp.PlantTypeId.ToString().PadRight(5) + bp.PlantTypes.PadRight(30));
            }
            WriteLine("");
            int input = int.Parse(Console.ReadLine());
            //Plant plantCategory = _dataAccess.GetPlantByCategory(input);


        }
        private void AddPlant()
        {
        }
    }
}
