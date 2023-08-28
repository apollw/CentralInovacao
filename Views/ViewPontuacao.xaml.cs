namespace CentralInovacao.Views;

public partial class ViewPontuacao : ContentPage
{
	public ViewPontuacao()
	{
		InitializeComponent();
	}
    private async void Btn_Logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}