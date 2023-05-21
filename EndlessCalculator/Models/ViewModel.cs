namespace EndlessCalculator.Models
{
    public abstract class ViewModel : Model
    {
        private bool isBusy;

        protected ViewModel()
        {
        }

        public bool IsBusy
        {
            get => isBusy;
            protected set => Set(ref isBusy, value);
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}
