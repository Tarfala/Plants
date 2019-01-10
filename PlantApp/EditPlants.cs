using PlantApp.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            PrintGreenText("What do you want to do?");
            WriteLine("a) Pick a plant to work with");
            WriteLine("b) Go to main menu");
            while (true)
            {
                ConsoleKey command = Console.ReadKey(true).Key;

                if (command == ConsoleKey.A)
                {
                    PickAPlant(sortedList);
                    break;
                }
                if (command == ConsoleKey.B)
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Sorry, wrong input...");
                }
            }
            ShowPlantsMenu();
        }

        private void PickAPlant(List<Plant> sortedList)
        {
            Header("What plant do you want to work with? Pick a Id");
            foreach (Plant bp in sortedList)
            {
                WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            }
            Write("Plant to pick: ");
            //string command = Console.ReadLine();
            List<Plant> singePlant = _dataAccess.GetSinglePlant();
            Header("Info on plant");
            PrintGreenText("Plant ID".PadRight(30) + "Plant Name".PadRight(30) + "Latin Name".PadRight(30) + "Water every 'x days" + "     " + "Info".PadRight(30));

            foreach (Plant bp in singePlant)
            {
                Console.WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(30) + bp.LatinName.PadRight(30) + bp.WaterFrekuenseInDays + "              " + bp.GeneralInfo.PadRight(30));
            }
            Console.WriteLine("");

            
            var firstElement = singePlant.First().Name;
            //Console.WriteLine(firstElement);
            PrintGreenText("Vad vill du göra med " + firstElement + "en?");
            WriteLine("a) Google efter plantan");
            WriteLine("b) Lägg till en kommentar");
            WriteLine("c) Gå till huvudmenyn");
            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.A)
                {
                    PickAPlant(sortedList);
                    break;
                }
                if (input == ConsoleKey.B)
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Sorry, wrong input...");
                }
            }

            Console.ReadLine();
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "https://www.google.se/search?q=" + firstElement); // Ska visa bilder på växten
            Console.WriteLine("");

        }




        private void WorkWithPlant(string command)
        {
            Header("What do you want to show?");
            WriteLine("a) Show an image of the plant");
            WriteLine("b) Show information about the plant");
            WriteLine("c) Add tips to other users");

            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.A)
                {

                    break;
                }
                if (input == ConsoleKey.B)
                {
                    break;

                }
                if (input == ConsoleKey.C)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, wrong input...");
                }
            }

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
