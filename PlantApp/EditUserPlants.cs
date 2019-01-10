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
                TimeSpan t = CalculateWaterDay(plant.LastWatered, plant.WaterFrequence);
                string countDown = DisplayDaysTilWater(t);

                WriteLine(plant.Name);
                WriteLine("User: " + plant.UserName);
                WriteLine("Bought Date: " + plant.Bought);
                WriteLine("Water Frequence: " + plant.WaterFrequence);
                WriteLine(countDown);
                WriteLine($"Info from: {plant.UserName} \n" +
                    $"{plant.UserInfo}");
                Console.WriteLine();
            }
            Console.ReadKey();
            SeeUserPlantsMenu();
        }


        private TimeSpan CalculateWaterDay(DateTime wateredDay, int Waterfrequence)
        {

            DateTime today = DateTime.Now;
            DateTime daytowater = wateredDay.AddDays(Waterfrequence);
            TimeSpan t = daytowater - today;

            return t;

        }

        private string DisplayDaysTilWater(TimeSpan t)
        {
            string countDown;

            if (t.Days >= 5)
            {

                countDown = $"{t.Days} dagar till vattning. Lungt!";
                return countDown;
            }

            if (t.Days < 2 && t.Days > 0)
            {
                countDown = $"{t.Days} dagar till vattning!";
                return countDown;
            }

            if (t.Days == 0)
            {
                countDown = $"Idag ska den vattnas.";
                return countDown;
            }

            if (t.Days < 0)
            {

                countDown = $"Åh, nej! Du skulle vattnat för {t.Days * -1} dagar sedan!";
                return countDown;
            }

            else
            {
                countDown = "";
                return countDown;
            }

            

        }
    }
}
