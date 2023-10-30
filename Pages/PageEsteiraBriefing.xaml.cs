using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();

    public PageEsteiraBriefing(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;
    }
    void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor1.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void Button_Declinar(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await Navigation.PushAsync(new PageDeclinio(Oportunidade));
        btn.IsEnabled = true;
    }

    private async void Button_EnviarSquad(object sender, EventArgs e)
    {
        Button btn = (Button)sender; 
        btn.IsEnabled = false;
        await DisplayAlert("", "Enviada para Definição de Squad", "Fechar");
        await Navigation.PopAsync();
        btn.IsEnabled = true;
    }
}