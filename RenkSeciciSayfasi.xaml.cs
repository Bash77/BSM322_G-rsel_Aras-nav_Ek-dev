using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.ApplicationModel;  // for Clipboard

namespace MauiApp1_Ogrenci_G
{
    public partial class RenkSeciciSayfasi : ContentPage
    {
        // Random instance for generating random colors
        private readonly Random _random = new Random();

        public RenkSeciciSayfasi()
        {
            InitializeComponent();

            // Initialize labels/background based on the default slider values
            UpdateColor();
        }

        // Fired whenever any of the three sliders moves
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        // Copies the current hex color code to the clipboard
        private async void OnCopyClicked(object sender, EventArgs e)
        {
            var renkKodu = hexColorLabel.Text;
            await Clipboard.Default.SetTextAsync(renkKodu);
            await DisplayAlert("Kopyalandı", renkKodu, "OK");
        }

        // Picks a random color by assigning random values to each slider
        private void OnRandomColorClicked(object sender, EventArgs e)
        {
            redSlider.Value = _random.Next(0, 256);
            greenSlider.Value = _random.Next(0, 256);
            blueSlider.Value = _random.Next(0, 256);
            // No need to call UpdateColor() here explicitly,
            // because setting Value on each slider will fire OnSliderValueChanged.
        }

        // Shared helper: read slider values, update labels, hex code, and page background
        private void UpdateColor()
        {
            int r = (int)redSlider.Value;
            int g = (int)greenSlider.Value;
            int b = (int)blueSlider.Value;

            redLabel.Text = $"Red: {r}";
            greenLabel.Text = $"Green: {g}";
            blueLabel.Text = $"Blue: {b}";

            string hex = $"#{r:X2}{g:X2}{b:X2}";
            hexColorLabel.Text = hex;

            // Apply the color to the page background
            this.BackgroundColor = Color.FromRgb(r, g, b);
        }
    }
}
