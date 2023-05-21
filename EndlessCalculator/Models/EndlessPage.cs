using EndlessCalculator.Util;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace EndlessCalculator.Models
{
    public abstract class EndlessPage : ContentPage
    {
        protected EndlessPage()
        {
            if (DeviceUtil.IsIOS)
            {
                On<iOS>().SetUseSafeArea(true);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is ViewModel vm)
            {
                vm.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is ViewModel vm)
            {
                vm.OnDisappearing();
            }
        }
    }
}
