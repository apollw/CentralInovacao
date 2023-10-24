using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageRankingGeral : ContentPage
{
    public PageRankingGeral()
    {
        InitializeComponent();

        // Cria a cole��o de itens
        var itemList = new List<string>
               {
                   "Danilo Ferreira",
                   "Edem Fernando",
                   "Alessandro Gaspar",
                   "Bruce Dickson",
                   "Jo�o Victor",
                   "Fernando Greg�rio",
                   "Lucas Leiva",
                   "Jo�o Sardinha",
                   "Helda Freitas",
                   "Alessandra Lima",
                   "Dayane Borges",
                   "Sandra Lopes",
                   "Carlos Augusto",
                   "Sim�o Freitas",
                   "Caroline Marques",
                   "Roberto Dias",
                   "Antonio Souza"
               };

        // Vincula a cole��o � ListView
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

        // Vincula a cole��o � ListView
        _myListView1.ItemsSource = itemList2;
    }
}



