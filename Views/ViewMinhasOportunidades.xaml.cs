using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Views;

public partial class ViewMinhasOportunidades : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    ModelOportunidade ModelOportunidade = new ModelOportunidade();
	public ViewMinhasOportunidades()
	{
		InitializeComponent();
        BindingContext = VMOportunidade;

        ModelOportunidade = VMOportunidade.CarregarOportunidade();
	}
    private async void Btn_Logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    public void Btn_Animation(ImageButton button)
    {
        // Define a escala inicial do botão
        button.Scale = 1;
        // Cria a animação de escalonamento
        var scaleAnimation = new Animation(v => button.Scale = v, 1, 0.8);
        // Define a duração da animação (em milissegundos)
        scaleAnimation.Commit(button, "PressingButtonAnimation", length: 250, easing: Easing.SinOut, finished: (v, c) => button.Scale = 1);
    }

    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushAsync(new ViewNovaOportunidade());
        await Shell.Current.GoToAsync($"{nameof(ViewNovaOportunidade)}");
    }
}