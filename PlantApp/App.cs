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

            if (key == ConsoleKey.D)
                Environment.Exit(0);


            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu(null);
            }
        }

        private void SearchTipsMenu()
        {
            Header("Tips");
            WriteLine("a) Visa alla tips\n" +
                "b) Sök på tips\n" +
                "c) Gå tillbaka");


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                ShowAllTips();

            if (key == ConsoleKey.B)
                SearchTips();

            if (key == ConsoleKey.C)
                MainMenu(null);

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu(null);
            }

        }

        private void SeeUserPlantsMenu()
        {
            Header("Användarväxter");
            WriteLine("a) Visa mina växter\n" +
                "b) Se andras växter\n" +
                "c) Användaruppgifter\n" +
                "d) Gå tillbaka");


            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.A)
                ShowPlantsOnUser();

            if (key == ConsoleKey.B)
               ShowAllUserPlants();

            if (key == ConsoleKey.C)
                ShowUserInformation();

            if (key == ConsoleKey.D)
                MainMenu(null);

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu(null);
            }

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
                MainMenu(null);

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu(null);
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();

        }
    }
}
