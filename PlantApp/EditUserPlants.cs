using System;
using System.Collections.Generic;
using System.Text;
using PlantApp.Domain;


namespace PlantApp
{
    partial class App
    {
        // Här fixar vi med användarplantor.

       private void ShowAllUserPlants()
        {
            Header("Alla användarplantor");

           List<UserPlant> AllUserPlants = _dataAccess.ShowAllUserPlantsList();

            foreach (var plant in AllUserPlants)
            {
                WriteLine(plant.Name);
                WriteLine("User: " + plant.UserName);
                WriteLine("Bought Date: " + plant.Bought);
                WriteLine("Warter Frequence: " + plant.WaterFrequence);
                WriteLine($"Info from: {plant.UserName} \n" +
                    $"{plant.UserInfo}");
                Console.WriteLine();
            }
            Console.ReadKey();
            SearchPlants();
        }

       private void ShowPlantsOnUser()
        {
            // Visar alla plantor registrerade på användare. 

            Header("Alla Dina Plantor");

            List<UserPlant> AllUserPlants = _dataAccess.ShowAllPlantsOnUser(loggedOnUser.UserId);

            foreach (var plant in AllUserPlants)
            {
                WriteLine(plant.Name);
                WriteLine("User: " + plant.UserName);
                WriteLine("Bought Date: " + plant.Bought);
                WriteLine("Warter Frequence: " + plant.WaterFrequence);
                WriteLine($"Info from: {plant.UserName} \n" +
                    $"{plant.UserInfo}");
                Console.WriteLine();
            }
            Console.ReadKey();
            SeeUserPlantsMenu();
        }

    }
}
