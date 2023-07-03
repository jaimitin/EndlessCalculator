namespace EndlessCalculator.Models.Pages
{
    public abstract class ViewModelPage<TViewModel> : EndlessPage where TViewModel : ViewModel, new()
    {
        protected ViewModelPage()
        {
            BindingContext = new TViewModel();
        }
    }
}
