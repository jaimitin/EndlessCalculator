using EndlessCalculator.Models;
using EndlessCalculator.Models.Menu;
using EndlessCalculator.Models.Pages;
using EndlessCalculator.Modules.Medals;
using EndlessCalculator.Util;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace EndlessCalculator
{
    public partial class FlyoutMenuPage : ViewModelPage<FlyoutMenuPageViewModel>
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }
    }

    public sealed class FlyoutMenuPageViewModel : ViewModel
    {

        #region Properties

        public List<INavigationMenuItem> Items { get; } = new()
        {
            new NavigationMenuItem<SpiritRestPage>("Spirit Rest")
        };

        #endregion


        #region Commands

        public Command HomeTappedCommand { get; }
        public Command<INavigationMenuItem> ItemTappedCommand { get; }

        #endregion


        public FlyoutMenuPageViewModel()
        {
            HomeTappedCommand = new Command(HomeTapped);
            ItemTappedCommand = new Command<INavigationMenuItem>(ItemTapped);
        }


        private void HomeTapped()
        {
            Application.Current!.MainPage = new FlyoutMasterPage();
        }

        private void ItemTapped(INavigationMenuItem item)
        {
            Guard.IsNotNull(item, nameof(item));

            if (item.Target != null)
            {
                if (Activator.CreateInstance(item.Target) is not Page target)
                {
                    throw new InvalidOperationException("Nav menu item must target a type deriving from Page");
                }

                Application.Current!.MainPage = new FlyoutMasterPage() { Detail = new NavigationPage(target) };
            }
        }
    }
}