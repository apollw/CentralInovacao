using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageDeclinio : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    Oportunidade Oportunidade = new Oportunidade();
    public PageDeclinio()
	{
		InitializeComponent();
	}
    public PageDeclinio(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;
    }
    private async void Btn_Declinada(object sender, EventArgs e)
    {
        Oportunidade.Status = "Declinada";
        await DisplayAlert("Alerta", "Proposta Declinada", "Fechar");
        await Shell.Current.GoToAsync($"//{nameof(PageInicio)}");
    }
}