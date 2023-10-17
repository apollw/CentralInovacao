using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    ViewModelTarefa VMTarefa  = new ViewModelTarefa();
    Oportunidade Oportunidade = new Oportunidade();

    public PageEsteiraPlanejamento()
    {
        InitializeComponent();
        BindingContext = VMTarefa;
        FillPage();
    }

    public PageEsteiraPlanejamento(Oportunidade oportunidade)
	{
		InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMTarefa;

        FillPage();

        //// Vincule a coleção à CollectionView
        //_collectionView.ItemsSource = Items;
        //_collectionView1.ItemsSource = Items;
        //_collectionView2.ItemsSource = Items;
    }
    public void FillPage()
    {
        //Oportunidade.ListaDeTarefas = VMTarefa.CarregarTarefas(Oportunidade);
        //_collectionView.ItemsSource = Oportunidade.ListaDeTarefas;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        VMTarefa.NovaTarefa(Oportunidade);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
