using Microsoft.Maui.Controls;

namespace EndlessCalculator.Models
{
    public abstract class ViewModel : Model
    {
        public static INavigation Navigation => Application.Current!.MainPage!.Navigation;

        #region Stores

        private bool _isBusy;

        #endregion


        #region Properties

        public bool IsBusy
        {
            get => _isBusy;
            protected set => Set(ref _isBusy, value);
        }

        #endregion


        protected ViewModel()
        {
        }


        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}
