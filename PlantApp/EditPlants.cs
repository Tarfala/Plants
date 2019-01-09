using PlantApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantApp
{
    partial class App
    {
        private void ShowAllPlantsOnName()
        {
            List<Plant> plant = _dataAccess.GetAllPlantSorted();
            foreach (Plant bp in plant)
            {
                WriteLine(bp.PlantId.ToString().PadRight(5) + bp.Name.PadRight(30));
            }
            WriteLine("");

        }
        private void ShowOnCategory()
        {
            throw new NotImplementedException();
        }
        private void AddPlant()
        {
            throw new NotImplementedException();
        }
    }
}
