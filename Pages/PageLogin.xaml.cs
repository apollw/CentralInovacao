namespace CentralInovacao.Pages;

public partial class PageLogin : ContentPage
{
	public PageLogin()
	{
		InitializeComponent();
	}
    private async void Btn_Login(object sender, EventArgs e)
    {
        //Navegar para uma P�gina Espec�fica
        // Os dois "//" servem para fazer navega��o de rota absoluta
        //if (_entryNome.Text == "LOGIN")
        await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
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