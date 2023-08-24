namespace CentralInovacao.Views;

public partial class ViewMinhasRequisicoes : ContentPage
{
	public ViewMinhasRequisicoes()
	{
		InitializeComponent();
	}
    private async void Btn_AbrirRequisicao(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ViewChamado)}");
    }
    private async void Btn_Logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}