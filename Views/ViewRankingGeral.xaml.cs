namespace CentralInovacao.Views;

public partial class ViewRankingGeral : ContentPage
{
	public ViewRankingGeral()
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
        myListView.ItemsSource = itemList;
    }
}