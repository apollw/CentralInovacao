using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageTarefa : ContentPage
{
    ProjectTask      _objProjectTask = new ProjectTask();
    ViewModelProject VMProject       = new ViewModelProject();

    public PageTarefa(ViewModelProject vmProject)
    {
        InitializeComponent();
        VMProject      = vmProject;
        BindingContext = VMProject;
    }

    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _tarefaDescricao.Text;
    }

    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void Btn_SalvarTarefaBacklog(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        _objProjectTask.Title       = _tarefaTitulo.Text;
        _objProjectTask.Description = _tarefaDescricao.Text; 

        if(await RESTPlanning.CreateTask(
            _tarefaTitulo.Text,
            _tarefaDescricao.Text,
            VMProject.ObjProject.Id
          )
        )
        {   //Alteração Local
            //VMProject.TaskListBacklog.Add(_objProjectTask);
            await DisplayAlert("Aviso", "Tarefa Registrada!", "Voltar");
            await Navigation.PopAsync();
        }
        btn.IsEnabled = true;
    }

    //protected async void RefreshScreen()
    //{
    //    Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);

    //    // Filtrando as tarefas com base no status
    //    var tarefasStatus0 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 0).ToList();
    //    var tarefasStatus1 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 1).ToList();
    //    var tarefasStatus2 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 2).ToList();        
    //}
}