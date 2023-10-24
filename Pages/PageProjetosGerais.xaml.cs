using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageMeusProjetos : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    List<Oportunidade> ListaDeOportunidades = new List<Oportunidade>();
    public PageMeusProjetos()
    {
        InitializeComponent();
        BindingContext = VMOportunidade;
        ListaDeOportunidades = VMOportunidade.CarregarOportunidades();
    }
    private async void Btn_AbrirProjeto(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ViewProjeto());
        await Shell.Current.GoToAsync($"{nameof(PageProjeto)}");
    }

    private async void Btn_AbrirEsteira(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (button.BindingContext is Oportunidade oportunidade)
            {
                await Navigation.PushAsync(new PageEsteiraGeral(oportunidade));
            }
        }
    }
}