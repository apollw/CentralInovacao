namespace CentralInovacao.Pages;

public partial class PageMeusProjetos : ContentPage
{
	public PageMeusProjetos()
	{
		InitializeComponent();
	}
    private async void Btn_AbrirProjeto(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ViewProjeto());
        await Shell.Current.GoToAsync($"{nameof(PageProjeto)}");
    }
    private async void Btn_Logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}