using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageMinhasOportunidades : ContentPage
{
    //ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    ViewModelProject VMProject = new ViewModelProject();

	public PageMinhasOportunidades()
	{
		InitializeComponent();
        BindingContext = VMProject;
        VMProject.GetListaProjetosUsuario();
    }

    private async void Btn_AbrirEsteira(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        if (btn is Button button)
        {            
            if (button.BindingContext is Project project)
            {
                //Desabilita o botão até o fim da tarefa
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                btn.IsEnabled               = false;

                //await Navigation.PushAsync(new PageEsteiraGeral(project));
                VMProject.GetProjeto(project.Id, project.User);
                await Navigation.PushAsync(new PageEsteiraGeral(VMProject.Project));

                //Reativa o botão após o fim da tarefa
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                btn.IsEnabled = true;

            }
        }
    }
    private async void Btn_AbrirEsteiraLocal(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        if (btn is Button button)
        {
            if (button.BindingContext is Oportunidade oportunidade)
            {
                //Desabilita o botão até o fim da tarefa
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                btn.IsEnabled = false;

                //await Navigation.PushAsync(new PageEsteiraGeral(oportunidade));
                await Task.Delay(1000);

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

        VMProject.GetListaProjetosUsuarioFiltroPorData(DateIni, DateEnd);
    }

    private void Btn_LimparFiltros(object sender, EventArgs e)
    {
        VMProject.GetListaProjetosUsuario();
    }

}

//protected async override void OnAppearing()
//{
//    base.OnAppearing();

//    activityIndicator.IsRunning = true;
//    activityIndicator.IsVisible = true;

//    //await VMOportunidade.CarregarOportunidadesAsyncLocal();
//    VMProject.GetListaProjetosUsuario();

//    //Reativa o botão após o fim da tarefa
//    activityIndicator.IsRunning = false;
//    activityIndicator.IsVisible = false;

//}