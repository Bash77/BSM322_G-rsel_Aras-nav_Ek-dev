
namespace MauiApp1_Ogrenci_G;

public partial class KrediHesaplamaSayfasi : ContentPage
{
	public KrediHesaplamaSayfasi()
	{
		InitializeComponent();
	}
    private void OnVadeSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        int vade = (int)e.NewValue;
        vadeLabel.Text = $"Vade: {vade} Ay";
    }

    private void OnHesaplaClicked(object sender, EventArgs e)
    {
        try
        {
            // Kullanıcıdan bilgileri al
            string krediTuru = krediTuruPicker.SelectedItem?.ToString();
            double krediTutari = double.Parse(krediTutariEntry.Text);
            double faizOraniYillik = double.Parse(faizOraniEntry.Text);
            int vade = (int)vadeSlider.Value;

            // Aylık faiz oranı
            double aylikFaizOrani = faizOraniYillik / 12 / 100;

            // Aylık taksit hesaplama (eşit taksit yöntemi)
            double taksit = (krediTutari * aylikFaizOrani) / (1 - Math.Pow(1 + aylikFaizOrani, -vade));
            double toplamGeriOdeme = taksit * vade;

            // Sonuçları yazdır
            sonucLabel.Text = $"Kredi Türü: {krediTuru}\n" +
                              $"Aylık Taksit: {taksit:F2} ₺\n" +
                              $"Toplam Ödeme: {toplamGeriOdeme:F2} ₺";
        }
        catch (Exception ex)
        {
            sonucLabel.Text = $"Hata: Lütfen tüm alanları doğru doldurun.\n{ex.Message}";
        }
    }
}
