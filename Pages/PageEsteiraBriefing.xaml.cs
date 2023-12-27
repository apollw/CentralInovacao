using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace CentralInovacao.Pages;

public partial class PageEsteiraBriefing : ContentPage
{
    Project          objProject = new Project();
    ViewModelProject VMProject  = new ViewModelProject();

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

        int maxLength = 300;
        int caracteresRestantes = maxLength - newText.Length;
        _lblCaracteresRestantes.Text = $"{caracteresRestantes} caracteres restantes";

        string myText  = _editor1.Text;
    }

    private void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void LoadPage()
    {
        VMProject.ObjProject        = await RESTProject.GetProject(objProject.Id, objProject.User);
        VMProject.StatusActivated   = (VMProject.ObjProject.Status > 1) ? 1 : 0;
        VMProject.StatusDeactivated = (VMProject.ObjProject.Status > 1) ? 0 : 1;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        LoadPage();        
    }

    private async void Button_Declinar(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        await Shell.Current.Navigation.PushAsync(new PageDeclinio(VMProject.ObjProject));
        btn.IsEnabled = true;
    }    

    private async void Button_Ativar(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        if (await RESTAnalysis.ActivateProject(VMProject.ObjProject.Id))
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

        if (await RESTProject.SendToStage(VMProject.ObjProject.Id, 3))
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
            
            if(imageByte.Length <= 2_000_000)
            {
                VMProject.SalvarImagemProjeto(VMProject.ObjProject, f, file);
            }
            else
            {
                await Shell.Current.DisplayAlert("Aviso", $"Tamanho do arquivo excede os limites (Máx: 2 MB)", "Retornar");
            }
        }
        btn.IsEnabled = true;
    } 

    private async void Button_AtualizarAnalise(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        string descricao = _editor1.Text;

        if (await RESTAnalysis.UpdateAnalysis(VMProject.ObjProject.Id, descricao))
            await DisplayAlert("Aviso", "Análise atualizada!", "Fechar");
        btn.IsEnabled = true;
    }    

}
