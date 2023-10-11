using System.Reflection;

namespace CentralInovacao.Pages;

public partial class PagePontuacao : ContentPage
{
	public PagePontuacao()
	{
		InitializeComponent();
    }

    private async void Btn_Logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}