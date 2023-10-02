using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSolicitacao : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    Oportunidade Oportunidade = new Oportunidade();
    public PageEsteiraSolicitacao()
	{
		InitializeComponent();
	}

    public PageEsteiraSolicitacao(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade = oportunidade;
        BindingContext = VMOportunidade;
        //FillPage();
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
    private async void Btn_EnviarAnalise(object sender, EventArgs e)
    {
        //await DisplayAlert("", "Solicitação Salva", "Fechar");
        //await Shell.Current.GoToAsync("..");
        //await Navigation.PushAsync(new PageEsteiraBriefing(Oportunidade));

    }

    private async void Btn_Solicitacao(object sender, EventArgs e)
    {
        await DisplayAlert("", "Solicitação Salva", "Fechar");
        await Shell.Current.GoToAsync("..");
    }
}