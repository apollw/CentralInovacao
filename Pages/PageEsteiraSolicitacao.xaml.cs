namespace CentralInovacao.Pages;

public partial class PageEsteiraSolicitacao : ContentPage
{
	public PageEsteiraSolicitacao()
	{
		InitializeComponent();
	}

    void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor1.Text;
    }
    void OnEditorTextChanged2(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor2.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void Button_Solicitacao(object sender, EventArgs e)
    {
        await DisplayAlert("", "Solicita��o Salva", "Fechar");
        await Shell.Current.GoToAsync("..");
    }
}