namespace CentralInovacao.Views;

public partial class ViewProjeto : ContentPage
{
    public ViewProjeto()
	{
		InitializeComponent();
    }

    private async void Btn_Solicitacao(object sender, EventArgs e)
    {
       // await Navigation.PushAsync(new ViewEsteiraSolicitacao());
        await Shell.Current.GoToAsync($"{nameof(ViewEsteiraSolicitacao)}");

    }

    private async void Btn_AnaliseBriefing(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ViewEsteiraBriefing)}");
    }

    private async void Btn_Squad(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ViewEsteiraSquad)}");
    }

    private async void Btn_Planejamento(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ViewEsteiraPlanejamento)}");

    }
    private async void Btn_Acompanhamento(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ViewEsteiraAcompanhamento)}");
    }
}