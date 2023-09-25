namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
	public PageEsteiraBriefing()
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
        //await DisplayAlert("", "Proposta Declinada", "Fechar");
          await Navigation.PushAsync(new PageDeclinio()); 
    }

    private async void Button_EnviarSquad(object sender, EventArgs e)
    {
        await DisplayAlert("", "Enviada para Definição de Squad", "Fechar");
        await Shell.Current.GoToAsync("..");
    }
}