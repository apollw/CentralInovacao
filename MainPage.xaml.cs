using CentralInovacao.Views;

namespace CentralInovacao;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private async void Btn_Login(object sender, EventArgs e)
    {
        //Navegar para uma Página Específica
        // Os dois "//" servem para fazer navegação de rota absoluta
        //if (_entryNome.Text == "LOGIN")
        await Navigation.PushAsync(new ViewLogin());
        //else
        //    await DisplayAlert("Alerta", "Login Incorreto", "Fechar");
    }
}

