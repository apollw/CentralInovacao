namespace CentralInovacao.Views;

public partial class ViewFirstPage : ContentPage
{
	public ViewFirstPage()
	{
		InitializeComponent();
    }

    private async void Btn_Logout(object sender, EventArgs e)
    {
        //Navegar para uma P�gina Espec�fica
        // Os dois "//" servem para fazer navega��o de rota absoluta
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }
}