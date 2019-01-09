using System;
using System.Collections.Generic;
using System.Text;
using PlantApp.Domain;

namespace PlantApp
{
    partial class App
    {
        DataAccess _dataAccess = new DataAccess();
        internal void Run()
        {
            Login();
        }

        private void Login()
        {
            ///// Tobbe gör login
            MainMenu();
        }

        private void MainMenu()
        {
            Header("HuvudMeny");
            WriteLine("a) Visa plantorna i databasen\n" +
                "b) Visa användarplantor\n" +
                "c) Sök bland tips\n" +
                "d) Avsluta");
           

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                ShowPlantsMenu();

            if (key == ConsoleKey.B)
                SeeUserPlantsMenu();

            if (key == ConsoleKey.C)
                SearchTipsMenu();

            if (key == ConsoleKey.C)
                Environment.Exit(0);


            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
            }
        }

        private void SearchTipsMenu()
        {

        }

        private void SeeUserPlantsMenu()
        {
        }

        private void ShowPlantsMenu()
        {
            Header("Visa växter");
            WriteLine("a) Visa alla plantor sorterat på namn\n" +
                "b) Visa efter kategori\n" +
                "c) Lägg till planta\n" +
                "d) Gå tillbaka");


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                ShowAllPlantsOnName();

            if (key == ConsoleKey.B)
                ShowOnCategory();

            if (key == ConsoleKey.C)
                AddPlant();

            if (key == ConsoleKey.D)
                MainMenu();

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
            }
            
        }       

        public void WriteLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();

        }
        public void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();

        }
        public void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();

        }
    }
}
