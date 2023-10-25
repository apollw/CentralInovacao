using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelTarefa       VMTarefa       = new ViewModelTarefa();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();

    public PageEsteiraPlanejamento()
    {
        InitializeComponent();
        BindingContext = VMOportunidade;
        //FillPage();
    }

    public PageEsteiraPlanejamento(Oportunidade oportunidade)
	{
		InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;

        RefreshScreen();

        // Vincule a coleção à CollectionView
        //_collectionView.ItemsSource = oportunidade.ListaDeTarefas;
        //_collectionView1.ItemsSource = Items;
        //_collectionView2.ItemsSource = Items;
    }

    //protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    //{
    //    base.OnNavigatedTo(args);

    //    Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);
    //    _collectionView.ItemsSource = Oportunidade.ListaDeTarefas;
    //}

    //protected async override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);

    //    // Filtrando as tarefas com base no status
    //    var tarefasStatus0 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 0).ToList();
    //    var tarefasStatus1 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 1).ToList();
    //    var tarefasStatus2 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 2).ToList();

    //    // Atribuindo listas filtradas às CollectionViews correspondentes
    //    _collectionView.ItemsSource  = tarefasStatus0;
    //    _collectionView1.ItemsSource = tarefasStatus1;
    //    _collectionView2.ItemsSource = tarefasStatus2;

    //}
    protected async void RefreshScreen()
    {
        Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);

        // Filtrando as tarefas com base no status
        var tarefasStatus0 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 0).ToList();
        var tarefasStatus1 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 1).ToList();
        var tarefasStatus2 = Oportunidade.ListaDeTarefas.Where(tarefa => tarefa.Status == 2).ToList();

        // Atribuindo listas filtradas às CollectionViews correspondentes
        _collectionView.ItemsSource = tarefasStatus0;
        _collectionView1.ItemsSource = tarefasStatus1;
        _collectionView2.ItemsSource = tarefasStatus2;

    }

    private async void Btn_AdicionarTarefa(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        await Navigation.PushAsync(new PageTarefa(Oportunidade));

        //Consertar isso aqui

        RefreshScreen();
    }
    private void Btn_ExcluirTarefa(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        Button button = (Button)sender;
        Tarefa tarefa = (Tarefa)button.CommandParameter;

        VMTarefa.ExcluirTarefa(Oportunidade, tarefa);

        RefreshScreen();

        // Atualizando a CollectionView após a exclusão
        //_collectionView.ItemsSource = Oportunidade.ListaDeTarefas;

        //await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
    }

    private async void Btn_AdicionarItem(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        Button button = (Button)sender;
        Tarefa tarefa = (Tarefa)button.CommandParameter;

        await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
    }    
}
