namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
	public PageEsteiraSquad()
	{
		InitializeComponent();
	}
    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        await DisplayAlert("Alerta", "Colaborador Adicionado", "Fechar");
    }
}