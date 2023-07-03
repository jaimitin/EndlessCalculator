using Microsoft.Maui.Controls;

namespace EndlessCalculator.Models.Menu
{
    public interface IMenuItem
    {
        string Text { get; set; }
        ImageSource? Icon { get; set; }
    }

    public class MenuItem : Model, IMenuItem
    {
        private string _text = string.Empty;
        private ImageSource? _icon;

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        public ImageSource? Icon
        {
            get => _icon;
            set => Set(ref _icon, value);
        }
    }
}
