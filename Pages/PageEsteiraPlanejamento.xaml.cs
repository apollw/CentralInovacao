using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraPlanejamento : ContentPage
{
    //Oportunidade Oportunidade  = new Oportunidade();
    //ViewModelTarefa VMTarefa = new ViewModelTarefa();

    Project Projeto = new Project();

 //   public PageEsteiraPlanejamento(Oportunidade oportunidade)
	//{
	//	InitializeComponent();
 //       Oportunidade   = oportunidade;
 //       BindingContext = Oportunidade;        
 //   }
    public PageEsteiraPlanejamento(Project projeto)
    {
        InitializeComponent();
        Projeto        = projeto;
        BindingContext = Projeto;
    }
    private async void Btn_AdicionarTarefaBacklog(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        //await Navigation.PushAsync(new PageTarefa(Oportunidade));        
    }
    private async void Btn_AdicionarTarefaExecucao(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        //await Navigation.PushAsync(new PageTarefa(Oportunidade));
    }
    private async void Btn_AdicionarTarefaFinalizadas(object sender, EventArgs e)
    {
        //Passa a oportunidade específica da tarefa
        //await Navigation.PushAsync(new PageTarefa(Oportunidade));
    }
    private void Btn_ExcluirTarefa(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        //ImageButton btn = (ImageButton)sender;
        Button btn = (Button)sender;

        Tarefa tarefa = (Tarefa)btn.CommandParameter;

        btn.IsEnabled = false;        
        //Oportunidade.ListaDeTarefasBacklog.Remove(tarefa);
        btn.IsEnabled = true;        
    }
    private async void Btn_AdicionarItem(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        ImageButton btn = (ImageButton)sender;
        Tarefa tarefa = (Tarefa)btn.CommandParameter;

        btn.IsEnabled = false;
        //await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
        btn.IsEnabled = true;
    }
    private async void OnBorderTapped_PaginaItem(object sender, EventArgs e)
    {
        //Encontramos a tarefa específica clicada
        //ImageButton btn = (ImageButton)sender;
        Border border = (Border)sender;

        Tarefa tarefa = (Tarefa)border.BindingContext;
        //await Navigation.PushModalAsync(new PageItem(Oportunidade, tarefa));
    }
}

//protected async override void OnNavigatedTo(NavigatedToEventArgs args)
//{
//    base.OnNavigatedTo(args);

//    Oportunidade = await VMTarefa.CarregarTarefasAsync(Oportunidade);
//    _collectionView.ItemsSource = Oportunidade.ListaDeTarefas;
//}
