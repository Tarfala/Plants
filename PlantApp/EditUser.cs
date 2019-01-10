using System;
using System.Collections.Generic;
using System.Text;
using PlantApp.Domain;


namespace PlantApp
{
   partial class App
    {
       private void ShowUserInformation()
        {
            Header("Användarinformation");
            WriteLine($"Användarnamn: {loggedOnUser.UserName}");
            WriteLine($"Email: {loggedOnUser.Email}");
            
        }
    }
}
