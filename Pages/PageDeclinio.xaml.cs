using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageDeclinio : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    public PageDeclinio(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;
    }
    private async void Btn_Declinada(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        await DisplayAlert("Alerta", "Proposta Declinada", "Fechar");
        await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
        btn.IsEnabled = true;
    }
}