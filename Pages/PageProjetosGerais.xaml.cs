using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageMeusProjetos : ContentPage
{
    List<Oportunidade>    ListaDeOportunidades = new List<Oportunidade>();
    ViewModelOportunidade VMOportunidade       = new ViewModelOportunidade();
    public PageMeusProjetos()
    {
        InitializeComponent();
        BindingContext = VMOportunidade;
    }
    private async void Btn_AbrirProjeto(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        //await Navigation.PushAsync(new ViewProjeto());
        await Shell.Current.GoToAsync($"{nameof(PageProjeto)}");
        btn.IsEnabled = true;
    }

    private async void Btn_AbrirEsteira(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        if (btn is Button button)
        {
            if (button.BindingContext is Oportunidade oportunidade)
            {
                await Navigation.PushAsync(new PageEsteiraGeral(oportunidade));
            }
        }
        btn.IsEnabled = true;
    }
}