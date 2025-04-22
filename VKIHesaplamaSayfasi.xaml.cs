namespace MauiApp1_Ogrenci_G;
using Microsoft.Maui.Controls;
public partial class VKIHesaplamaSayfasi : ContentPage
{
	public VKIHesaplamaSayfasi()
	{
		InitializeComponent();
	}

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Read current slider values
        double kilo = kiloSlider.Value;
        double boyCm = boySlider.Value;

        // Update the kilo and boy labels (rounded to whole numbers)
        kiloLabel.Text = $"Kilo: {kilo:F0} kg";
        boyLabel.Text = $"Boy: {boyCm:F0} cm";

        // Compute BMI: weight (kg) / (height (m))^2
        double boyM = boyCm / 100.0;
        double vki = kilo / (boyM * boyM);

        // Update VKİ label (two decimal places)
        vkiLabel.Text = $"VKİ: {vki:F2}";
    }

}