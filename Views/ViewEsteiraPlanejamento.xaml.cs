using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Views;

public partial class ViewEsteiraPlanejamento : ContentPage
{
    public ObservableCollection<string> Items { get; set; }

    public ViewEsteiraPlanejamento()
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
