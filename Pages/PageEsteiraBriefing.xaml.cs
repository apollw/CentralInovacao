using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
    Project          objProject      = new Project();
    RESTProject      objRESTProject  = new RESTProject();
    RESTAnalysis     objRESTAnalysis = new RESTAnalysis();
    ViewModelProject VMProject       = new ViewModelProject();

    public PageEsteiraBriefing(Project projeto)
    {
        InitializeComponent();
        objProject     = projeto;
        BindingContext = VMProject;
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

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        VMProject.Project = await objRESTProject.GetProject(objProject.Id, objProject.User);
        VMProject.StatusActivated = (VMProject.Project.Status > 1) ? 1 : 0;
        VMProject.StatusDeactivated = (VMProject.Project.Status > 1) ? 0 : 1;
    }

    private async void Button_Declinar(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        await Shell.Current.Navigation.PushAsync(new PageDeclinio(VMProject.Project));
        btn.IsEnabled = true;
    }

    private async void Button_Ativar(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        if (await objRESTAnalysis.ActivateProject(VMProject.Project.Id))
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

        if (await objRESTProject.SendToStage(VMProject.Project.Id, 3))
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

        if (await objRESTAnalysis.UpdateAnalysis(VMProject.Project.Id, descricao))
            await DisplayAlert("Aviso", "Análise atualizada!", "Fechar");
        btn.IsEnabled = true;
    }   

}
