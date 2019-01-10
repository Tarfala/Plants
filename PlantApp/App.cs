using System;
using System.Collections.Generic;
using System.Text;
using PlantApp.Domain;

namespace PlantApp
{
    partial class App
    {
        public string passWord;
        public string userName;
        public string email;

        DataAccess _dataAccess = new DataAccess();
        public User loggedOnUser = new User();

        internal void Run()
        {
            Login();

        }

        private void Login()
        {
            Header("Plantbook");
            WriteLine("Inloggning");
            WriteLine("a) Logga in i Plant");
            WriteLine("b) Skapa nytt användarkonto.");
            ConsoleKey command = Console.ReadKey(true).Key;

            if(command == ConsoleKey.A)
            {
                UserLoggIn();
                Login();
            }
            if(command == ConsoleKey.B)
            {
                CreateAccount();
                MainMenu();
            }

        }

        private void CreateAccount()
        {
            while (true)
            {
                Write("Ange ett användarnamn: ");
                userName = Console.ReadLine();
                WriteLine("");
                Write("Ange ett lösenord: ");
                passWord = Console.ReadLine();
                WriteLine("");
                Write("Ange en e-post: ");
                email = Console.ReadLine(); // lägg till validering av e-post.
                loggedOnUser.UserName = userName;
                loggedOnUser.PassWord = passWord;
                loggedOnUser.Email = email;
                bool testUserName = _dataAccess.TestOfUserName(loggedOnUser);
                if (testUserName == false)
                    break;
                else
                {
                    WriteLine("Användarnamnet är upptaget, välj ett nytt.");
                }
            }
            _dataAccess.CreateNewAccount(loggedOnUser);
        }

        private void UserLoggIn()
        {
            while (true)
            {
                WriteLine("Logga in i applikationen");
                Write("Användarnamn: ");
                userName = Console.ReadLine();
                WriteLine("");
                Write("Lösenord: ");
                passWord = Console.ReadLine();
                loggedOnUser.UserName = userName;
                loggedOnUser.PassWord = passWord;
                bool userValid = _dataAccess.CheckIfUserIsValid(loggedOnUser);
                if (userValid == false)
                {
                    WriteLine("Användaren finns inte eller så är användarnamn eller lösenord felaktiga.");
                    WriteLine("För att få information om lösenord kontakta admin.");
                    WriteLine("Vill du fösöka logga in igen tryck I annars valfri tangent.");
                    ConsoleKey loggInCommand = Console.ReadKey(true).Key;
                    if (loggInCommand != ConsoleKey.I)
                    {
                        break;
                    }
                }
                if (userValid == true)
                {
                    MainMenu();
                }
            }
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

            if (key == ConsoleKey.D)
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
                MainMenu();

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
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
                MainMenu();

            else
            {
                WriteLine("Nu blev det fel!");
                Console.ReadKey();
                MainMenu();
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }
        public void PrintGreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }

    }
}
