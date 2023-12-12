using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
    ViewModelProject VMProject = new ViewModelProject();    

    public PageEsteiraBriefing(Project projeto)
    {
        InitializeComponent();
        VMProject.Project = projeto;
        BindingContext    = VMProject;
    }
    
    private void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor1.Text;
    }

    private void OnEditorTextChanged2(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
    }

    private void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }
    
    private void Button_Declinar(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        //await Navigation.PushAsync(new PageDeclinio(Oportunidade));
        
        btn.IsEnabled = true;
    }

    private async void Button_EnviarSquad(object sender, EventArgs e)
    {
        Button btn    = (Button)sender; 
        btn.IsEnabled = false;

        await DisplayAlert("", "Enviada para Definição de Squad", "Fechar");
        await Navigation.PopAsync();

        btn.IsEnabled = true;
    }
}
