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
            SeeUserPlantsMenu();
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

            WriteLine("");
            WriteLine("a) Uppdatera Planta");
            WriteLine("b) Vattna Planta");
            WriteLine("c) Gå tillbaka");


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                UpdateUserPlant(AllUserPlants);

            if (key == ConsoleKey.B)
                WaterPlantQuestion(AllUserPlants);


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
            UserPlant PlantToUppdate = SortOutUserPlant(list, uppdPlant);

            Header("Uppdaterar " + PlantToUppdate.Name);

            UserPlant newUserPlant = PlantToUppdate;
            WriteLine("Vad vill du uppdatera?");
            WriteLine("a) Placering");
            WriteLine("b) Dagar mellan vattning");
            WriteLine("c) Uppdatera informationen");
            WriteLine("d) Vattna");
            WriteLine("e) Ta bort Planta");
            WriteLine("e) Tillbaka");

            ConsoleKey key2 = Console.ReadKey(true).Key;

            if (key2 == ConsoleKey.A)
            {
                WriteLine("Här kan man uppdatera väderstreck sen");
                WriteLine("Uppdaterat!");
                Console.ReadKey();
                SeeUserPlantsMenu();
            }


            if (key2 == ConsoleKey.B)
            {
                Console.WriteLine();
                WriteLine("Hur många dagar vill du ha mellan vattning?");

                newUserPlant.WaterFrequence = int.Parse(Console.ReadLine());

                _dataAccess.UpdateUserPlant(newUserPlant);
                Console.Clear();
                WriteLine("Uppdaterat!");
                Console.ReadKey();
                SeeUserPlantsMenu();
            }
            if (key2 == ConsoleKey.C)
            {
                Console.WriteLine();
                WriteLine("Ange ny information om plantan.");
                newUserPlant.UserInfo = Console.ReadLine();

                _dataAccess.UpdateUserPlant(newUserPlant);
                Console.Clear();
                WriteLine("Uppdaterat!");
                Console.ReadKey();
                SeeUserPlantsMenu();
            }

            if (key2 == ConsoleKey.D)
            {
                WaterPlant(newUserPlant);
            }


            if (key2 == ConsoleKey.E)
            {
                DeleteUserPlant(PlantToUppdate.UserPlantId);
            }
            if (key2 == ConsoleKey.D)
            {
                SeeUserPlantsMenu();
            }
            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
            }

            // Lication, Waterfrequence, Ta bort, kommentar/info.


        }

        private void WaterPlantQuestion(List<UserPlant> list)
        {
            Header("Vattna");
            Console.WriteLine();
            foreach (var plant in list)
            {
                WriteLine("Id: " + plant.UserPlantId);
                WriteLine("Namn: " + plant.Name);
            }

            Console.WriteLine();
            WriteLine("Vilken Planta vill du Vattna?");
            int uppdPlant = int.Parse(Console.ReadLine());
            UserPlant PlantToWater = SortOutUserPlant(list, uppdPlant);

            Console.Clear();
            Console.WriteLine();


            WriteLine("Vattnar blomman...");
            Console.ReadKey();
            PlantToWater.LastWatered = DateTime.Now;

            _dataAccess.UpdateUserPlant(PlantToWater);

            Console.ReadKey();
            SeeUserPlantsMenu();


        }
        private void WaterPlant(UserPlant newUserPlant)
        {
            Console.Clear();
            Console.WriteLine();
            WriteLine("Vattnar blomman...");
            Console.ReadKey();
            newUserPlant.LastWatered = DateTime.Now;

            _dataAccess.UpdateUserPlant(newUserPlant);

            Console.ReadKey();
            SeeUserPlantsMenu();

        }


        private UserPlant SortOutUserPlant(List<UserPlant> list, int UserPlantId)
        {
            UserPlant newPlant = new UserPlant();
            foreach (var plant in list)
            {
                if (plant.UserPlantId == UserPlantId)
                {
                    newPlant = plant;
                }
                else
                {
                    WriteLine("Nu blev det fel");
                }
            }
            return newPlant;
        }

        private void DeleteUserPlant(int UserPlantId)
        {
            Header("Ta bort planta");
            WriteLine("Är du säker?");
            string yn = Console.ReadLine();


            if (yn.ToLower() == "ja")
            {

                //Skapa funktionen sen.
                _dataAccess.DeleteUserPlant(UserPlantId);

                WriteLine("Plantan är borttagen!");
                Console.ReadKey();
                SeeUserPlantsMenu();
            }

            else
            {
                WriteLine("Ingen planta har tagits bort");
                Console.ReadKey();
                SeeUserPlantsMenu();
            }
        }
    }
}
