using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageTarefa : ContentPage
{
    Tarefa          Tarefa       = new Tarefa();
    //Oportunidade    Oportunidade = new Oportunidade();
    ViewModelTarefa VMTarefa     = new ViewModelTarefa();

    //public PageTarefa(Oportunidade oportunidade)
    //{
    //    InitializeComponent();
    //    Oportunidade   = oportunidade;
    //    BindingContext = VMTarefa;
    //}
    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editorDescricao.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }
    private async void Btn_SalvarTarefaBacklog(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        //Tarefa.IdProjeto = Oportunidade.Id;
        //Tarefa.IdUsuario = Oportunidade.Usuario;
        Tarefa.Data      = DateTime.Now;
        Tarefa.Titulo    = _tarefaTitulo.Text;
        Tarefa.Status    = 0;
        Tarefa.Ordem     = 0;
        Tarefa.Descricao = _editorDescricao.Text;

        //VMTarefa.SalvarTarefaBacklog(Oportunidade,Tarefa);
        //VMTarefa.SalvarTarefaExecucao(Oportunidade, Tarefa);
        //VMTarefa.SalvarTarefaFinalizadas(Oportunidade, Tarefa);


        await DisplayAlert("Aviso", "Tarefa Registrada!", "Voltar");
        await Navigation.PopAsync();

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