using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ConnectFour
{
    public class ColorPickerDialog : ContentPage
    {
        private TaskCompletionSource<Color> _tcs;
        private List<ColorItem> _colors;

        public async Task<Color> ShowAsync()
        {
            _tcs = new TaskCompletionSource<Color>();
            _colors = await App.Database.GetColorsAsync();

            var stackLayout = new StackLayout();

            foreach (var colorItem in _colors)
            {
                var colorButton = new Button { BackgroundColor = Color.FromArgb(colorItem.ColorHex), Text = colorItem.ColorName };
                colorButton.Clicked += (s, e) => _tcs.SetResult(Color.FromArgb(colorItem.ColorHex));
                stackLayout.Children.Add(colorButton);
            }

            var addColorButton = new Button { Text = "Add New Color" };
            addColorButton.Clicked += async (s, e) => await AddNewColor();

            stackLayout.Children.Add(addColorButton);

            Content = stackLayout;

            await Application.Current.MainPage.Navigation.PushModalAsync(this);

            return await _tcs.Task;
        }

        private async Task AddNewColor()
        {
            var colorNameEntry = new Entry { Placeholder = "Color Name" };
            var colorHexEntry = new Entry { Placeholder = "Color Hex (e.g., #FF0000)" };
            var saveButton = new Button { Text = "Save" };

            saveButton.Clicked += async (s, e) =>
            {
                var newColor = new ColorItem
                {
                    ColorName = colorNameEntry.Text,
                    ColorHex = colorHexEntry.Text
                };

                await App.Database.SaveColorAsync(newColor);
                await Application.Current.MainPage.Navigation.PopModalAsync();
            };

            var stackLayout = new StackLayout
            {
                Children = { colorNameEntry, colorHexEntry, saveButton }
            };

            Content = stackLayout;
        }
    }
}

