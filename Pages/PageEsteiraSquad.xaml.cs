using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
    ViewModelProject VMProject   = new ViewModelProject();
    RESTProject      RESTProject = new RESTProject();    

    public PageEsteiraSquad(Project projeto)
    {
        InitializeComponent();
        VMProject.Project = projeto;
        BindingContext    = VMProject;
    }

    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await DisplayAlert("Alerta", "Colaborador Adicionado", "Fechar");
        btn.IsEnabled = true; 
    }

    private async void Button_EnviarPlanejamento(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        if (await RESTProject.SendToStage(VMProject.Project.Id, 4))
            await DisplayAlert("Aviso", "Enviado para Planejamento", "Fechar");
        btn.IsEnabled = true;
    }
}