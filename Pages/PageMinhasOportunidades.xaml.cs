using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageMinhasOportunidades : ContentPage
{
    ViewModelProject VMProject = new ViewModelProject();

	public PageMinhasOportunidades()
	{
		InitializeComponent();
        BindingContext = VMProject;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        VMProject.GetListaProjetosUsuario();
    }

    private async void Btn_AbrirEsteira(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        if (btn is Button button)
        {            
            if (button.BindingContext is Project project)
            {
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                btn.IsEnabled               = false;

                VMProject.GetProjeto(project.Id, project.User);
                await Navigation.PushAsync(new PageEsteiraGeral(VMProject.Project));

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

        VMProject.GetListaProjetosUsuarioFiltroPorData(DateIni, DateEnd);
    }

    private void Btn_LimparFiltros(object sender, EventArgs e)
    {
        VMProject.GetListaProjetosUsuario();
    }

}

//protected override void OnAppearing()
//{
//    base.OnAppearing();

//}