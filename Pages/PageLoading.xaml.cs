using CentralInovacao.Services;

namespace CentralInovacao.Pages;

public partial class PageLoading : ContentPage
{
	private readonly AuthService _authService;
	public PageLoading(AuthService authService)
	{
		InitializeComponent();
		_authService = authService;
	}
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        
        if (await _authService.IsAuthenticatedAsync())
        {
            //Usuário está logado
            //Redirecionar para a PageInicio
            await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
        }
        else
        {
            //Usuário não está logado
            //Redirecionar para MainPage
            await DisplayAlert("Alerta", "Usuário não autenticado", "Retornar");
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}