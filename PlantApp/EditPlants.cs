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
            Header("Vilken planta vill du jobba med? Välj ett Id");
            foreach (Plant bp in sortedList)
            {
                WriteLine(bp.PlantId.ToString().PadRight(30) + bp.Name.PadRight(5));
            }
            Write("Plantan som ska väljas: ");
            string command = Console.ReadLine();
            List<Plant> singePlant = _dataAccess.GetSinglePlant(command);
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
            WriteLine("d) Visa kommentarer");

            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.A)
                {
                    GoogleThePlantPlease(singePlant);
                    break;
                }
                if (input == ConsoleKey.B)
                {
                    AddACommentToPlant(singePlant);
                    break;
                }
                if (input == ConsoleKey.C)
                {
                    MainMenu();
                    break;
                }
                if (input == ConsoleKey.D)
                {
                    ShowComment(singePlant);
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, wrong input...");
                }
            }         

        }

        private void ShowComment(List<Plant> singePlant)
        {
            Header("Visar kommentarer för: " + singePlant[0].Name);

            Plant onlyOne = new Plant();
            onlyOne.Name = singePlant[0].Name;
            onlyOne.PlantId = singePlant[0].PlantId;
            onlyOne.LatinName = singePlant[0].LatinName;
            onlyOne.LocationId = singePlant[0].LocationId;
            onlyOne.WaterFrekuenseInDays = singePlant[0].WaterFrekuenseInDays;
            onlyOne.PlantTypeId = singePlant[0].PlantTypeId;
            onlyOne.ScentId = singePlant[0].ScentId;
            onlyOne.NutritionId = singePlant[0].NutritionId;
            onlyOne.OriginId = singePlant[0].OriginId;
            onlyOne.PoisonId = singePlant[0].PoisonId;
            onlyOne.GeneralInfo = singePlant[0].GeneralInfo;
            List<PlantComment> plantcomment = _dataAccess.ShowComment(onlyOne);
            PrintGreenText("Kommentar".PadRight(30) + "Användare");
            foreach (PlantComment item in plantcomment)
            {
                Console.WriteLine(item.CommentFromUser.PadRight(30) + item.UserComment);
            }
            Console.ReadLine();
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
            Header("Lägg till kommentar om " + singePlant[0].Name);
            string comment = Console.ReadLine();
            Plant onlyOne = new Plant();
            onlyOne.Name = singePlant[0].Name;
            onlyOne.PlantId = singePlant[0].PlantId;
            onlyOne.LatinName = singePlant[0].LatinName;
            onlyOne.LocationId = singePlant[0].LocationId;
            onlyOne.WaterFrekuenseInDays = singePlant[0].WaterFrekuenseInDays;
            onlyOne.PlantTypeId = singePlant[0].PlantTypeId;
            onlyOne.ScentId = singePlant[0].ScentId;
            onlyOne.NutritionId = singePlant[0].NutritionId;
            onlyOne.OriginId = singePlant[0].OriginId;
            onlyOne.PoisonId = singePlant[0].PoisonId;
            onlyOne.GeneralInfo = singePlant[0].GeneralInfo;

            _dataAccess.AddComment(onlyOne, comment, loggedOnUser);

            Console.ReadLine();
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
