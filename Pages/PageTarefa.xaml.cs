using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageTarefa : ContentPage
{
    Tarefa                Tarefa         = new Tarefa();
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelTarefa       VMTarefa       = new ViewModelTarefa();
    
    public PageTarefa()
	{
		InitializeComponent();
        BindingContext = VMTarefa;
	}
    public PageTarefa(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMTarefa;
        //FillPage();
    }
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
    private async void Btn_SalvarTarefa(object sender, EventArgs e)
    {
        Tarefa.IdProjeto = Oportunidade.Id;
        Tarefa.IdUsuario = Oportunidade.Usuario;
        Tarefa.Data      = DateTime.Now;
        Tarefa.Titulo    = _tarefaTitulo.Text;
        Tarefa.Status    = 0;
        Tarefa.Ordem     = 0;
        Tarefa.Descricao = _editorDescricao.Text;

        VMTarefa.SalvarTarefa(Oportunidade,Tarefa);

        await DisplayAlert("Aviso", "Tarefa Registrada!", "Voltar");
        await Navigation.PopModalAsync();
    }
}