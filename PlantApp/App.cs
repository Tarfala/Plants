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
            Header("Plant");
            WriteLine("För att logga in i Plant skriv (L). Om du inte har ett konto skriv (N) för att skapa nytt konto");
            ConsoleKey command = Console.ReadKey(true).Key;
            if(command == ConsoleKey.L)
            {
                WriteLine("Logga in i applikationen");
                Write("Användarnamn: ");
                string userName = Console.ReadLine();
                WriteLine("");
                Write("Lösenord: ");
                string passWord = Console.ReadLine();
                User loggedOnUser = new User();
                loggedOnUser.UserName = userName;
                loggedOnUser.PassWord = passWord;
                while (true)
                {
                    bool userValid = _dataAccess.CheckIfUserIsValid(loggedOnUser);
                    if (userValid == false)
                    {
                        WriteLine("Användaren finns inte eller så är användarnamn eller lösenord felaktiga.");
                        WriteLine("För att få information om lösenord kontakta admin.");
                        WriteLine("Vill du fösöka logga in igen tryck I annars valfri tangent.");
                        ConsoleKey loggInCommand = Console.ReadKey(true).Key;
                        if(loggInCommand != ConsoleKey.I)
                        {
                            break;
                        }

                    }

                    if(userValid == true)
                    {
                        MainMenu(loggedOnUser);
                    }
                }

                Login();
            }
            if(command == ConsoleKey.N)
            {
                Write("Ange ett användarnamn: ");
                string userName = Console.ReadLine();
                WriteLine("");
                Write("Ange ett lösenord: ");
                string passWord = Console.ReadLine();
                WriteLine("");
                Write("Ange en e-post: ");
                string email = Console.ReadLine(); // lägg till validering av e-post.
                User loggedOnUser = new User();
                loggedOnUser.UserName = userName;
                loggedOnUser.PassWord = passWord;
                loggedOnUser.Email = email;
                _dataAccess.CreateNewAccount(loggedOnUser);
                MainMenu(loggedOnUser);
            }

        }

        private void MainMenu(User loggedOnUser)
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
