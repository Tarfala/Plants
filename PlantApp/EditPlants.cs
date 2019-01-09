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
            //Header("Select")
            //List<Plant> plantCategory = _dataAccess.GetAllPlant
        }
        private void AddPlant()
        {
        }
    }
}
