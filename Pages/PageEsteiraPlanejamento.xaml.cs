using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    Tarefa                Tarefa         = new Tarefa();  
    ViewModelTarefa       VMTarefa       = new ViewModelTarefa();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();

    public PageEsteiraPlanejamento()
    {
        InitializeComponent();
        BindingContext = VMOportunidade;
        FillPage();
    }

    public PageEsteiraPlanejamento(Oportunidade oportunidade)
	{
		InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;

        FillPage();

        // Vincule a coleção à CollectionView
        _collectionView.ItemsSource = oportunidade.ListaDeTarefas;
        //_collectionView1.ItemsSource = Items;
        //_collectionView2.ItemsSource = Items;
    }
    public void FillPage()
    {
        //Oportunidade.ListaDeTarefas = VMTarefa.CarregarTarefas(Oportunidade);
        //_collectionView.ItemsSource = Oportunidade.ListaDeTarefas;
    }

    private async void Btn_AdicionarTarefa(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        await Navigation.PushModalAsync(new PageTarefa(Oportunidade));    
    }

    private void Btn_AdicionarItem(object sender, EventArgs e)
    {
        VMTarefa.SalvarTarefaItem(Oportunidade,VMOportunidade.ListaDeOportunidades);        
    }
}
