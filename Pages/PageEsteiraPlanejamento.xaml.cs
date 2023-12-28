using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    ViewModelProject VMProject = new ViewModelProject();

    public PageEsteiraPlanejamento(Project projeto)
    {
        InitializeComponent();
        VMProject.ObjProject = projeto;
        BindingContext = VMProject;
        LoadPage();
    }

    private async void LoadPage()
    {
        List<ModelProjectTaskGroup> ListaDeTarefasGeral = new List<ModelProjectTaskGroup>();
        ListaDeTarefasGeral = await RESTPlanning.GetListProjectTasks(VMProject.ObjProject);
        //VMProject.TaskListGeneral = new ObservableCollection<List<ModelProjectTaskGroup>>(ListaDeTarefasGeral);  
    }

    private async void Btn_AdicionarTarefaBacklog(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageTarefa(VMProject));
    }

    private void Btn_AdicionarTarefaExecucao(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        //await Navigation.PushAsync(new PageTarefa(Oportunidade));
    }

    private void Btn_AdicionarTarefaFinalizadas(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        //await Navigation.PushAsync(new PageTarefa(Oportunidade));
    }

    private void Btn_ExcluirTarefa(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        //ImageButton btn = (ImageButton)sender;
        Button btn = (Button)sender;

        ProjectTask tarefa = (ProjectTask)btn.CommandParameter;

        btn.IsEnabled = false;        
        //Oportunidade.ListaDeTarefasBacklog.Remove(tarefa);
        btn.IsEnabled = true;        
    }

    private void Btn_AdicionarItem(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        ImageButton btn = (ImageButton)sender;
        ProjectTask tarefa = (ProjectTask)btn.CommandParameter;

        btn.IsEnabled = false;
        //await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
        btn.IsEnabled = true;
    }

    private void OnBorderTapped_PaginaItem(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        //ImageButton btn = (ImageButton)sender;
        Border border = (Border)sender;

        ProjectTask tarefa = (ProjectTask)border.BindingContext;
        //await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
    }

}

//protected async override void OnNavigatedTo(NavigatedToEventArgs args)
//{
//    base.OnNavigatedTo(args);

//    Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);
//    _collectionView.ItemsSource = Oportunidade.ListaDeTarefas;
//}
