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
            SeeUserPlantMenu();
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

            WriteLine("");
            WriteLine("a) Uppdatera Planta");
            WriteLine("b) Vattna Planta");
            WriteLine("c) Gå tillbaka");


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                UpdateUserPlant(AllUserPlants);

            if (key == ConsoleKey.B)
                ShowAllUserPlants();

            if (key == ConsoleKey.C)
                ShowUserInformation();

            if (key == ConsoleKey.D)
                MainMenu();

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
            }









            Console.ReadKey();
            SeeUserPlantMenu();
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

            private void UpdateUserPlant(List<UserPlant> list)
            {
            Header("Uppdatera planta");
            foreach (var plant in list)
            {
                WriteLine("Id: " + plant.UserPlantId);
                WriteLine("Namn: " + plant.Name);
            }
           
            WriteLine("Vilken Planta vill du uppdatera?");
            int uppdPlant = int.Parse(Console.ReadLine());
            UserPlant PlantToUppdate =_dataAccess.FindPlantOnId(uppdPlant);

            Header("Uppdaterar" + PlantToUppdate.Name);

            WriteLine("Vad vill du uppdatera?");
            // Lication, Waterfrequence, Ta bort, kommentar/info.


            }

    }
}
