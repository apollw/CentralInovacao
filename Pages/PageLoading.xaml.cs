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
            //Usu�rio est� logado
            //Redirecionar para a PageInicio
            await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
        }
        else
        {
            //Usu�rio n�o est� logado
            //Redirecionar para MainPage
            await DisplayAlert("Alerta", "Usu�rio n�o autenticado", "Retornar");
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}