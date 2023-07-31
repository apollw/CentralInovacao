namespace CentralInovacao.Views;

public partial class ViewRankingGeral : ContentPage
{
	public ViewRankingGeral()
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
        myListView.ItemsSource = itemList;
    }
}