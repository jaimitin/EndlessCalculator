﻿using Microsoft.Maui.Controls;

namespace EndlessCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutMasterPage();
        }
    }
}