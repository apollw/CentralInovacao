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
    public void Btn_Animation(ImageButton button)
    {
        // Define a escala inicial do bot�o
        button.Scale = 1;
        // Cria a anima��o de escalonamento
        var scaleAnimation = new Animation(v => button.Scale = v, 1, 0.8);
        // Define a dura��o da anima��o (em milissegundos)
        scaleAnimation.Commit(button, "PressingButtonAnimation", length: 250, easing: Easing.SinOut, finished: (v, c) => button.Scale = 1);
    }            

    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int animationDuration = 100;

        //Executa Anima��o
        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //Desabilita o bot�o at� o fim da tarefa
        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;
        button.IsEnabled            = false;

        await Shell.Current.GoToAsync($"{nameof(PageNovaOportunidade)}");

        //Reativa o bot�o ap�s o fim da tarefa
        button.IsEnabled            = true;
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

                btn.IsEnabled = true;

                //Reativa o bot�o ap�s o fim da tarefa
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
            }
        }
    }
    
}