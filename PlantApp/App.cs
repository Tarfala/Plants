using System;
using System.Collections.Generic;
using System.Text;

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
            ShowPlantsMenu();
            SeeUserPlantsMenu();
            SearchTipsMenu();
        }

        private void SearchTipsMenu()
        {

        }

        private void SeeUserPlantsMenu()
        {
        }

        private void ShowPlantsMenu()
        {
            ShowAllPlantsOnName();
            ShowOnCategory();
            AddPlant();
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
