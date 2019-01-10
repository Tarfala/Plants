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
            string user1 = loggedOnUser.UserName;

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
                loggedOnUser.UserName = userName;
                bool testUserName = _dataAccess.TestOfUserName(loggedOnUser);

                if (testUserName == false)
                {
                    Write("Ange ett lösenord: ");
                    passWord = Console.ReadLine();
                    WriteLine("");
                    Write("Ange en e-post: ");
                    email = Console.ReadLine(); // lägg till validering av e-post.
                    WriteLine("Välj hur bostads exponeras mot solen");
                    List<Location> apparmentTypes = _dataAccess.GetAppartmentTypes();

                    foreach (var location in apparmentTypes)
                    {
                        WriteLine(location.LocationId.ToString().PadLeft(5) + location.LocationIn.PadLeft(20));
                    }

                    Write("Exponering: ");
                    loggedOnUser.UserLocationId = int.Parse(Console.ReadLine());
                    WriteLine("I vilken klimatzon bor du?");
                    List<Zone> zoneTypes = _dataAccess.GetZoneTypes();

                    foreach (var zone in zoneTypes)
                    {
                        WriteLine(zone.OriginId.ToString().PadLeft(5) + zone.ZoneIn.PadLeft(20));
                    }

                    Write("Boendezon: ");
                    loggedOnUser.ZoneId = int.Parse(Console.ReadLine());
                    loggedOnUser.PassWord = passWord;
                    loggedOnUser.Email = email;
                    break;
                }
                else
                {
                    WriteLine("Användarnamnet är upptaget, välj ett nytt.");
                }
            }
            _dataAccess.CreateNewAccount(loggedOnUser);
            loggedOnUser = _dataAccess.GetUserData(userName);
            WelcomeToPlantBook(loggedOnUser);
            
        }

        private void UserLoggIn()
        {
            while (true)
            {
                WriteLine("Logga in i applikationen");
                Write("Användarnamn: ");
                userName = Console.ReadLine();
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
                    loggedOnUser = _dataAccess.GetUserData(userName);
                    WelcomeToPlantBook(loggedOnUser);
                    MainMenu();
                    break;
                }
            }
        }

        private void WelcomeToPlantBook(User loggedOnUser)
        {
            Header("PlantBook");
            WriteLine("");
            WriteLine($"Hej {loggedOnUser.UserName}!");
            WriteLine("Du har loggat in i PlantBook.");
            WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
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
