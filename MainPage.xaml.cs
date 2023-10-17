using CentralInovacao.Pages;
using CentralInovacao.Services;

namespace CentralInovacao;

public partial class MainPage : ContentPage
{
    private readonly AuthService         _authService;
    private readonly ConnectivityService _connectivityService;

 //   public MainPage(AuthService authService)
	//{
	//	InitializeComponent();
 //       _authService = authService;
 //   }
    public MainPage(AuthService authService, ConnectivityService connectivityService)
    {
        InitializeComponent();
        _authService         = authService;
        _connectivityService = connectivityService;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (await _authService.IsAuthenticatedAsync())
        {
            // O usuário já está autenticado; permitir o acesso às áreas restritas.
            await Shell.Current.GoToAsync($"{nameof(PageLoading)}");
        }
    }

    private async void Btn_Login(object sender, EventArgs e)
    {
        if (_connectivityService.GetNetworkAccess() == NetworkAccess.Internet)
        {
            if (await _authService.IsAuthenticatedAsync())
            {
                // O usuário já está autenticado; permitir o acesso às áreas restritas.
                await Shell.Current.GoToAsync($"{nameof(PageLoading)}");
            }
            else
            {
                await _authService.LoginAsync(_entryNome.Text, _entrySenha.Text);
                await Shell.Current.GoToAsync($"{nameof(PageLoading)}");
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Verifique a Conexão com a Internet", "Retornar");
        }
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
