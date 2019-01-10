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
            Header("Här är listan på alla plantor i databasen");
            List<Plant> plant = _dataAccess.GetAllPlantSorted();
            var sortedList = plant.OrderBy(x => x.Name).ToList();
            PrintGreenText("Plantans Id".PadRight(30) + "Plantans namn".PadRight(5));
            foreach (Plant bp in sortedList)
            {
                WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            }
            WriteLine("");
            PrintGreenText("Vad vill du göra?");
            WriteLine("a) Välj en planta att arbeta med");
            WriteLine("b) Gå till huvudmenyn");
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
            throw new ArgumentException();

            //Header("Vilken planta vill du jobba med? Välj ett Id");
            //foreach (Plant bp in sortedList)
            //{
            //    WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            //}
            //Write("Plantan som ska väljas: ");
            //string command = Console.ReadLine();
            //List<Plant> singePlant = _dataAccess.GetSinglePlant(command);
            //Header("Info om plantan");
            //PrintGreenText("Plantans ID".PadRight(30) + "Plantans namn".PadRight(30) + "Latinska namn".PadRight(30) + "Vattnas varje x:e dag" + "     " + "Info".PadRight(30));

            //foreach (Plant bp in singePlant)
            //{
            //    Console.WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(30) + bp.LatinName.PadRight(30) + bp.WaterFrekuenseInDays + "              " + bp.GeneralInfo.PadRight(30));
            //}
            //Console.WriteLine("");

            
            //var firstElement = singePlant.First().Name;
            //Console.WriteLine(firstElement);
            //Header("Vad vill du göra med" + firstElement + "en?");
            //WriteLine("a) Google efter plantan");
            //WriteLine("b) Lägg till en kommentar");
            //WriteLine("c) Gå till huvudmenyn");
            //while (true)
            //{
            //    ConsoleKey input = Console.ReadKey(true).Key;

            //    if (input == ConsoleKey.A)
            //    {
            //        GoogleThePlantPlease(singePlant);
            //        break;
            //    }
            //    if (input == ConsoleKey.B)
            //    {
            //        AddACommentToPlant(singePlant);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Sorry, wrong input...");
            //    }
            //}         

        }

        private void GoogleThePlantPlease(List<Plant> singePlant)
        {
            var firstElement = singePlant.First().Name;
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "https://www.google.se/search?q=" + firstElement); // Ska visa bilder på växten
            Console.WriteLine("");
            MainMenu();
        }

        private void AddACommentToPlant(List<Plant> sortedList)
        {
                        
        }

        private void WorkWithPlant(string command)
        {
            Console.WriteLine("Fixa detta");
            Console.ReadLine();

        }

        private void ShowOnCategory()
        {
            Header("Välj en kategori");
            List <PlantType> category = _dataAccess.GetCategort();
            PrintGreenText("Kategori Id".PadRight(30) + "Kategori".PadRight(5));

            foreach (PlantType bp in category)
            {
                WriteLine(bp.PlantTypeId.ToString().PadRight(30) + bp.PlantTypes.PadRight(5));
            }
            WriteLine("");
            int input = int.Parse(Console.ReadLine());
            List<Plant> plantCategory = _dataAccess.GetPlantByCategory(input);
            Console.Clear();
            Header("Visar alla plantor i den kategorin");
            PrintGreenText("Plantans Id".PadRight(30) + "Plantans namn".PadRight(5));

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
            int waterDate;
            Header("Lägg till planta i databsen");
            List<Plant> addPlantList = new List<Plant>();

            WriteLine("Vad är plantans namn på Svenska?");
            string nameOnPlant = Console.ReadLine();
            WriteLine("Vad är plantans latinska namn?");
            string latinName = Console.ReadLine();
            Console.WriteLine("Hur ofta ska plantan vattnas, skriv antal dagar (ex '5')");            
            waterDate = int.Parse(Console.ReadLine());            
            Console.WriteLine("Skriv lite info om plantan");
            string info = Console.ReadLine();

            Plant added = new Plant();
            added.Name = nameOnPlant;
            added.LatinName = latinName;
            added.GeneralInfo = info;
            added.WaterFrekuenseInDays = waterDate;
            _dataAccess.AddPlant(added);
        }
    }
}
