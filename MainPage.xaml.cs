using CentralInovacao.Pages;
using CentralInovacao.Services;

namespace CentralInovacao;

public partial class MainPage : ContentPage
{
    private readonly AuthService _authService;
    public MainPage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }
    private async void Btn_Login(object sender, EventArgs e)
    {      
        await _authService.LoginAsync(_entryNome.Text,_entrySenha.Text);
        await Shell.Current.GoToAsync($"{nameof(PageLoading)}");
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

