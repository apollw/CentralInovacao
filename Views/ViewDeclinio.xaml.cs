namespace CentralInovacao.Views;

public partial class ViewDeclinio : ContentPage
{
	public ViewDeclinio()
	{
		InitializeComponent();
	}

    private async void Btn_Declinada(object sender, EventArgs e)
    {
        await DisplayAlert("", "Proposta Declinada", "Fechar");
        //await Shell.Current.GoToAsync("..");
        await Navigation.PopModalAsync();
    }
}