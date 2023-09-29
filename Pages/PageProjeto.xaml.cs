namespace CentralInovacao.Pages;

public partial class PageProjeto : ContentPage
{
    public PageProjeto()
	{
		InitializeComponent();
    }

    private async void Btn_Solicitacao(object sender, EventArgs e)
    {
       // await Navigation.PushAsync(new ViewEsteiraSolicitacao());
        await Shell.Current.GoToAsync($"{nameof(PageEsteiraSolicitacao)}");
    }
    private async void Btn_AnaliseBriefing(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PageEsteiraBriefing)}");
    }
    private async void Btn_Squad(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PageEsteiraSquad)}");
    }

    private async void Btn_Planejamento(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PageEsteiraPlanejamento)}");

    }
    private async void Btn_Acompanhamento(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PageEsteiraAcompanhamento)}");
    }
}