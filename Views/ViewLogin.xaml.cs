namespace CentralInovacao.Views;

public partial class ViewLogin : ContentPage
{
	public ViewLogin()
	{
		InitializeComponent();
	}
    private async void Btn_Login(object sender, EventArgs e)
    {
        //Navegar para uma Página Específica
        // Os dois "//" servem para fazer navegação de rota absoluta
        //if (_entryNome.Text == "LOGIN")
        await Shell.Current.GoToAsync($"//{nameof(ViewInicio)}");
        //else
        //    await DisplayAlert("Alerta", "Login Incorreto", "Fechar");
    }
}