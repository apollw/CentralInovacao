using CentralInovacao.Views;

namespace CentralInovacao;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    //private async void Btn_Login(object sender, EventArgs e)
    //{
    //    //Navegar para uma Página Específica
    //    // Os dois "//" servem para fazer navegação de rota absoluta
    //    //if (_entryNome.Text == "LOGIN")
    //    await Navigation.PushAsync(new ViewLogin());
    //    //else
    //    //    await DisplayAlert("Alerta", "Login Incorreto", "Fechar");
    //}
    private async void Btn_Login(object sender, EventArgs e)
    {
        //Navegar para uma Página Específica
        // Os dois "//" servem para fazer navegação de rota absoluta
        //if (_entryNome.Text == "LOGIN")
        await Shell.Current.GoToAsync($"//{nameof(ViewInicio)}");
        //else
        //    await DisplayAlert("Alerta", "Login Incorreto", "Fechar");
    }

    //Comportamento de Focar e Desfocar das Entries - ReturnType - Done
    private void _entryNome_Focused(object sender, FocusEventArgs e)
    {
        _entryNome.Completed += (s, e) =>
        {
            _entrySenha.Focus();
        };
    }
    private void _entrySenha_Focused(object sender, FocusEventArgs e)
    {
        _entrySenha.Completed += (s, e) =>
        {
            _entrySenha.IsEnabled = false;
            _entrySenha.Unfocus();
            _entrySenha.IsEnabled = true;
        };
    }
}

