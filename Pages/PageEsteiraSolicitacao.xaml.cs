using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSolicitacao : ContentPage
{
    List<AreaLocal>  ListAreaLocal     = new List<AreaLocal>();
    List<ModelArea>  ProjectAreasLocal = new List<ModelArea>();
    RESTResources    RESTResources     = new RESTResources();
    RESTProject      RESTProject       = new RESTProject();
    ViewModelProject VMProject         = new ViewModelProject();

    public PageEsteiraSolicitacao(Project projeto)
    {
        InitializeComponent();
        BindingContext    = VMProject;
        VMProject.Project = projeto;

        FillPage();
    }

    public async void FillPage()
    {
        VMProject.ListAreaGeneral = await RESTResources.GetListAreas();

        ListAreaLocal = VMProject.ListAreaGeneral.Select(modelArea =>
        {
            var areaLocal = new AreaLocal
            {
                Id   = modelArea.Id,
                Name = modelArea.Name,
                IsSelected = VMProject.Project.ListArea.Any(a => a.Id == modelArea.Id)
            };
            return areaLocal;
        }).ToList();

        _CollectionViewAreas.ItemsSource = ListAreaLocal;

        _lblUsuario.Text  = VMProject.Project.LkpUser;
        _entryTitulo.Text = VMProject.Project.Name;
        _editor1.Text     = VMProject.Project.DescriptionPositive;
        _editor2.Text     = VMProject.Project.DescriptionNegative;
    }

    private async void Btn_EnviarAnalise(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;
        
        if(await RESTProject.SendToStage(VMProject.Project.Id, 2))
            await DisplayAlert("Alerta", "Solicitação Enviada para Análise", "Fechar");

        btn.IsEnabled = true;        
    }
    
    private async void Btn_ClassificarProjeto(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        int classificacao = 1; //Classificação vai de 1 a 3

        if (await RESTProject.ClassifyProject(VMProject.Project.Id, classificacao))
            await DisplayAlert("Alerta", "Solicitação Enviada para Análise", "Fechar");

        btn.IsEnabled = true;

    } //NÃO IMPLEMENTADO

    private async void Btn_SalvarOportunidade(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        VMProject.Project.User                = Preferences.Get("AuthUserId", 0);
        VMProject.Project.Name                = _entryTitulo.Text;
        VMProject.Project.DescriptionPositive = _editor1.Text;
        VMProject.Project.DescriptionNegative = _editor2.Text;

        VMProject.EditarProjeto(VMProject.Project,ProjectAreasLocal);

        await DisplayAlert("Aviso", "Oportunidade Registrada!", "Voltar");
        await Shell.Current.GoToAsync("..");

        btn.IsEnabled = true;
    }

    public  void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;

        //Verifica se o CheckBox foi clicado
        if (checkBox.BindingContext is ModelArea area)
        {
            //Estou alterando uma lista local, para não duplicar a lista que vem do Endpoint
            if (e.Value)
            {
                ProjectAreasLocal.Add(area);
            }
            else
            {
                ProjectAreasLocal.Remove(area);
            }
        }
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
        string myText  = _editor2.Text;
    }

    private void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

}



