using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    public PageEsteiraSquad(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;
    }
    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await DisplayAlert("Alerta", "Colaborador Adicionado", "Fechar");
        btn.IsEnabled = true; 
    }
}