namespace CentralInovacao.Views;

public partial class ViewEsteiraSquad : ContentPage
{
	public ViewEsteiraSquad()
	{
		InitializeComponent();
	}
    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        //Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushAsync(new ViewNovaOportunidade());
        //await Shell.Current.GoToAsync($"{nameof(ViewNovaOportunidade)}");
    }
}