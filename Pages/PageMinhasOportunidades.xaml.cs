using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageMinhasOportunidades : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
	public PageMinhasOportunidades()
	{
		InitializeComponent();
        BindingContext = VMOportunidade;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        await VMOportunidade.CarregarOportunidadesAsyncLocal();

        //Reativa o bot�o ap�s o fim da tarefa
        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

    }
    private async void Btn_AbrirEsteira(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        if (btn is Button button)
        {            
            if (button.BindingContext is Oportunidade oportunidade)
            {
                //Desabilita o bot�o at� o fim da tarefa
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                btn.IsEnabled               = false;

                await Navigation.PushAsync(new PageEsteiraGeral(oportunidade));

                //Reativa o bot�o ap�s o fim da tarefa
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                btn.IsEnabled = true;

            }
        }
    }
}