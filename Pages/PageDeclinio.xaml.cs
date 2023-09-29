namespace CentralInovacao.Pages;

public partial class PageDeclinio : ContentPage
{
	public PageDeclinio()
	{
		InitializeComponent();
	}

    private async void Btn_Declinada(object sender, EventArgs e)
    {
        await DisplayAlert("", "Proposta Declinada", "Fechar");
        await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
    }
}