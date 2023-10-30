using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageItem : ContentPage
{
    Tarefa          Tarefa       = new Tarefa();
    Oportunidade    Oportunidade = new Oportunidade(); 
    ViewModelTarefa VMTarefa     = new ViewModelTarefa();
        
    public PageItem(Oportunidade oportunidade, Tarefa tarefa)
    {
        InitializeComponent();
        Tarefa         = tarefa;
        Oportunidade   = oportunidade;
        BindingContext = VMTarefa;
        //FillPage();
    }

    private async void Btn_SalvarItem(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;
        //Preenche o item novo da tarefa específica
        Tarefa.ItemNovo.id   = VMTarefa.GerarNovoIdItem(Tarefa.ItemNovo.id,Oportunidade, Tarefa);
        Tarefa.ItemNovo.Nome = _itemTitulo.Text;
        Tarefa.ItemNovo.Data = DateTime.Now;

        VMTarefa.SalvarItemTarefa(Oportunidade, Tarefa);
        await Navigation.PopModalAsync();
        btn.IsEnabled = false;
    }
}