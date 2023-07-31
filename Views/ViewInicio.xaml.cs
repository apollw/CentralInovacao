namespace CentralInovacao.Views;

public partial class ViewInicio : ContentPage
{
    private List<InteractionItem> lastInteractions;

    public List<InteractionItem> LastInteractions
    {
        get => lastInteractions;
        set
        {
            lastInteractions = value;
            OnPropertyChanged();
        }
    }

    [Obsolete]
    public ViewInicio()
    {
        InitializeComponent();

        // Exemplo de dados
        LastInteractions = new List<InteractionItem>
            {
                new InteractionItem { Title = "Edem Fernando", Description = "Alterou a foto de perfil" },
                new InteractionItem { Title = "Danilo Ferreira", Description = "Adicionou uma nova oportunidade" },
                new InteractionItem { Title = "Bruce Dickson", Description = "Iniciou um projeto" },
                new InteractionItem { Title = "Fernando Gregório", Description = "Finalizou um projeto" },
                new InteractionItem { Title = "Arthur Carvalho", Description = "Subiu no Ranking Geral" }
            };

        // Inicia um timer para atualizar automaticamente os itens do CarouselView
        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            // Roda os itens automaticamente
            RotateItems();

            // Retorna true para continuar a execução do timer
            return true;
        });
    }
    // Método para rotacionar os itens do CarouselView
    private void RotateItems()
    {
        // Remove o primeiro item e adiciona no final da lista
        var firstItem = LastInteractions[0];
        LastInteractions.RemoveAt(0);
        LastInteractions.Add(firstItem);

        // Atualiza o BindingContext para atualizar o CarouselView
        carouselView.BindingContext = null;
        carouselView.BindingContext = this;
    }
    private async void Btn_Logout(object sender, EventArgs e)
    {
        //Navegar para uma Página Específica
        // Os dois "//" servem para fazer navegação de rota absoluta
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
    private async void Btn_MeusProjetos(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewMeusProjetos());
    }
    private async void Btn_MinhasOp(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewMinhasOportunidades());
    }
    private async void Btn_RankingGeral(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewRankingGeral());
    }
    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewNovaOportunidade());
    }
    private async void Btn_Chamado(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewChamado());
    }
    private async void OnImageTapped(object sender, EventArgs e)
    {
        // URL do site que você deseja abrir
        string websiteUrl = "https://academia.ceapebrasil.org.br/university/";

        // Abra o link do site no navegador
        await Launcher.OpenAsync(new Uri(websiteUrl));
    }
}

// Classe para representar os dados da "última interação"
public class InteractionItem
{
    public string Title { get; set; }
    public string Description { get; set; }
}