﻿using System;
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
        }

    }
}
