namespace CentralInovacao.Views;

public partial class ViewEsteiraBriefing : ContentPage
{
	public ViewEsteiraBriefing()
	{
		InitializeComponent();
	}
    void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = _editor1.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void Button_Declinar(object sender, EventArgs e)
    {
        await DisplayAlert("", "Proposta Declinada", "Fechar");
    }

    private async void Button_EnviarSquad(object sender, EventArgs e)
    {
        await DisplayAlert("", "Enviada para Definição de Squad", "Fechar");
    }
}