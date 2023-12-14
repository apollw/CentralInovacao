using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
    ViewModelProject VMProject    = new ViewModelProject();
    RESTProject      RESTProject  = new RESTProject();
    RESTAnalysis     RESTAnalysis = new RESTAnalysis();
    
    public PageEsteiraBriefing(Project projeto)
    {
        InitializeComponent();
        VMProject.Project           = projeto;
        VMProject.StatusActivated   = (VMProject.Project.Status > 1) ? 1 : 0;
        VMProject.StatusDeactivated = (VMProject.Project.Status > 1) ? 0 : 1;
        BindingContext              = VMProject;
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
    
    private async void Button_Declinar(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        int decline_reason = 1;

        if (await RESTAnalysis.DeclineProject(VMProject.Project.Id, decline_reason))
        {
            VMProject.StatusActivated   = 1;
            VMProject.StatusDeactivated = 0;

            await DisplayAlert("Aviso", "Proposta Declinada", "Fechar");
        }
        btn.IsEnabled = true;
    }

    private async void Button_Ativar(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        if (await RESTAnalysis.ActivateProject(VMProject.Project.Id))
        {
            VMProject.StatusActivated   = 0;
            VMProject.StatusDeactivated = 1;

            await DisplayAlert("Aviso", "Proposta Ativada", "Fechar");
        }
        btn.IsEnabled = true;
    }

    private async void Button_EnviarSquad(object sender, EventArgs e)
    {
        Button btn    = (Button)sender; 
        btn.IsEnabled = false;

        if (await RESTProject.SendToStage(VMProject.Project.Id, 3))
            await DisplayAlert("Aviso", "Enviado para Definição de Squad", "Fechar");
        btn.IsEnabled = true;
    }

    private async void Button_AlterarCapaProjeto(object sender, EventArgs e) 
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        var result = await MediaPicker.PickPhotoAsync();        

        if (result != null)
        {
            FileInfo f = new FileInfo(result.FullPath);

            byte[] imageByte = File.ReadAllBytes(f.FullName);            
            string file = Convert.ToBase64String(imageByte);           

            VMProject.SalvarImagemProjeto(VMProject.Project, f, file);
        }

        btn.IsEnabled = true;
    } //--------------PARCIAL

    private async void Button_AtualizarAnalise(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        string descricao = _editor1.Text;

        if (await RESTAnalysis.UpdateAnalysis(VMProject.Project.Id, descricao))
            await DisplayAlert("Aviso", "Análise atualizada!", "Fechar");
        btn.IsEnabled = true;
    }   

}
