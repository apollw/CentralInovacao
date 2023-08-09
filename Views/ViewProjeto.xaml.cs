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
}