namespace CentralInovacao.Views;

public partial class ViewMeusProjetos : ContentPage
{
	public ViewMeusProjetos()
	{
		InitializeComponent();
	}

    private async void Btn_AbrirProjeto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewProjeto());
        //await Shell.Current.GoToAsync($"{nameof(ViewProjeto)}");
    }
}