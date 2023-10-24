using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageRankingGeral : ContentPage
{
    public PageRankingGeral()
    {
        InitializeComponent();

        // Cria a coleção de itens
        var itemList = new List<string>
               {
                   "Danilo Ferreira",
                   "Edem Fernando",
                   "Alessandro Gaspar",
                   "Bruce Dickson",
                   "João Victor",
                   "Fernando Gregório",
                   "Lucas Leiva",
                   "João Sardinha",
                   "Helda Freitas",
                   "Alessandra Lima",
                   "Dayane Borges",
                   "Sandra Lopes",
                   "Carlos Augusto",
                   "Simão Freitas",
                   "Caroline Marques",
                   "Roberto Dias",
                   "Antonio Souza"
               };

        // Vincula a coleção à ListView
        _myListView.ItemsSource = itemList;

        var itemList2 = new List<string>
               {
                   "7",
                   "6",
                   "6",
                   "5",
                   "4",
                   "4",
                   "3",
                   "3",
                   "3",
                   "2",
                   "2",
                   "2",
                   "1",
                   "1",
                   "1",
                   "1",
                   "1"
               };

        // Vincula a coleção à ListView
        _myListView1.ItemsSource = itemList2;
    }
}



