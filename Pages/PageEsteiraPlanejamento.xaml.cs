using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    ViewModelTarefa VMTarefa= new ViewModelTarefa();
    Oportunidade Oportunidade = new Oportunidade();

    public PageEsteiraPlanejamento(Oportunidade oportunidade)
	{
		InitializeComponent();
        Oportunidade = oportunidade;
        BindingContext = VMTarefa;

        //Carrega itens da oportunidade
        Oportunidade.ListaDeTarefas = VMTarefa.CarregarTarefas(Oportunidade);

        // Inicialize a coleção de itens e adicione alguns exemplos
        //Items = new ObservableCollection<string>
        //    {
        //        "Tarefa 1",
        //        "Tarefa 2",
        //        "Tarefa 3",
        //        "Tarefa 1",
        //        "Tarefa 2",
        //        "Tarefa 3",
        //        "Tarefa 1",
        //        "Tarefa 2",
        //        "Tarefa 3",
        //        "Tarefa 1",
        //        "Tarefa 2",
        //        "Tarefa 3",
        //        "Tarefa 1",
        //        "Tarefa 2",
        //        "Tarefa 3"
        //    };

        //// Vincule a coleção à CollectionView
        //_collectionView.ItemsSource = Items;
        //_collectionView1.ItemsSource = Items;
        //_collectionView2.ItemsSource = Items;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        VMTarefa.NovoItem(Oportunidade);
    }
}
