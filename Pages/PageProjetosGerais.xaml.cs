using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageProjetosGerais : ContentPage
{
    ViewModelProject VMProject = new ViewModelProject();

    public PageProjetosGerais()
    {
        InitializeComponent();
        BindingContext = VMProject;
        VMProject.GetListaProjetosGeral();
    }

    //IMPLEMENTAR PARA BUSCAR PROJETOS DE DIFERENTES USUÁRIOS
    private void Btn_AbrirEsteira(object sender, EventArgs e)         
    {
        Button btn = (Button)sender;

        if (btn is Button button)
        {
            if (button.BindingContext is Project project)
            {
                //Desabilita o botão até o fim da tarefa
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                btn.IsEnabled = false;

                //await Navigation.PushAsync(new PageEsteiraGeral(project));
                //VMProject.GetProjeto(project.Id, project.User);
                //await Navigation.PushAsync(new PageEsteiraGeral(VMProject.Project));

                //Reativa o botão após o fim da tarefa
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                btn.IsEnabled = true;

            }
        }
    }

    private void Btn_Filtrar(object sender, EventArgs e)
    {
        DateTime DateIni = _datePicker1.Date;
        DateTime DateEnd = _datePicker2.Date;

        VMProject.GetListaProjetosFiltroPorData(DateIni, DateEnd);
    }

    private void Btn_LimparFiltros(object sender, EventArgs e)
    {
        VMProject.GetListaProjetosGeral();
    }

}

