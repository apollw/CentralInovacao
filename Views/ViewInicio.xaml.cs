namespace CentralInovacao.Views;

public partial class ViewInicio : ContentPage
{
    public ViewInicio()
    {
        InitializeComponent();
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