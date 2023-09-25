using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    public ObservableCollection<string> Items { get; set; }

    public PageEsteiraPlanejamento()
	{
		InitializeComponent();

        // Inicialize a coleção de itens e adicione alguns exemplos
        Items = new ObservableCollection<string>
            {
                "Tarefa 1",
                "Tarefa 2",
                "Tarefa 3",
                "Tarefa 1",
                "Tarefa 2",
                "Tarefa 3",
                "Tarefa 1",
                "Tarefa 2",
                "Tarefa 3",
                "Tarefa 1",
                "Tarefa 2",
                "Tarefa 3",
                "Tarefa 1",
                "Tarefa 2",
                "Tarefa 3"
            };

        // Vincule a coleção à CollectionView
        _collectionView.ItemsSource  = Items;
        _collectionView1.ItemsSource = Items;
        _collectionView2.ItemsSource = Items;
    }
}
