using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    Oportunidade Oportunidade = new Oportunidade();
    public PageEsteiraSquad()
	{
		InitializeComponent();
	}
    public PageEsteiraSquad(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade = oportunidade;
        BindingContext = VMOportunidade;
    }
    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        await DisplayAlert("Alerta", "Colaborador Adicionado", "Fechar");
    }
}