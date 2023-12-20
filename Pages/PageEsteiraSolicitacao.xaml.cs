using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSolicitacao : ContentPage
{
    RESTProject      objRESTProject    = new RESTProject();
    RESTResources    objRESTResources  = new RESTResources();
    List<AreaLocal>  ListAreaLocal     = new List<AreaLocal>();
    List<ModelArea>  ProjectAreasLocal = new List<ModelArea>();
    ViewModelProject VMProject         = new ViewModelProject();

    public PageEsteiraSolicitacao(Project projeto)
    {
        InitializeComponent();
        BindingContext    = VMProject;
        VMProject.ObjProject = projeto;
        FillPage();
    }

    public async void FillPage()
    {
        VMProject.ListAreaGeneral = await objRESTResources.GetListAreas();

        ListAreaLocal = VMProject.ListAreaGeneral.Select(modelArea =>
        {
            var areaLocal = new AreaLocal
            {
                Id   = modelArea.Id,
                Name = modelArea.Name,
                IsSelected = VMProject.ObjProject.ListArea.Any(a => a.Id == modelArea.Id)
            };
            return areaLocal;
        }).ToList();

        _CollectionViewAreas.ItemsSource = ListAreaLocal;

        _lblUsuario.Text  = VMProject.ObjProject.LkpUser;
        _entryTitulo.Text = VMProject.ObjProject.Name;
        _editor1.Text     = VMProject.ObjProject.DescriptionPositive;
        _editor2.Text     = VMProject.ObjProject.DescriptionNegative;
    }

    private async void Btn_EnviarAnalise(object sender, EventArgs e)    
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;
        
        if(await objRESTProject.SendToStage(VMProject.ObjProject.Id, 2))
            await DisplayAlert("Alerta", "Solicitação Enviada para Análise", "Fechar");

        btn.IsEnabled = true;        
    }
    
    private async void Btn_ClassificarProjeto(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        if (VMProject.ObjProject.CanUpdateClassification)
        {
            await Shell.Current.Navigation.PushAsync(new PageClassificar(VMProject.ObjProject));
        }
        else
        {
            await Shell.Current.DisplayAlert("Aviso","Apenas diretores do CEAPE Brasil podem classificar um projeto!","Retornar");
        }
        btn.IsEnabled = true;
    }

    private async void Btn_SalvarOportunidade(object sender, EventArgs e)
    {
        Button btn    = (Button)sender;
        btn.IsEnabled = false;

        VMProject.ObjProject.User                = Preferences.Get("AuthUserId", 0);
        VMProject.ObjProject.Name                = _entryTitulo.Text;
        VMProject.ObjProject.DescriptionPositive = _editor1.Text;
        VMProject.ObjProject.DescriptionNegative = _editor2.Text;

        VMProject.EditarProjeto(VMProject.ObjProject,ProjectAreasLocal);

        await DisplayAlert("Aviso", "Oportunidade Registrada!", "Voltar");
        await Shell.Current.GoToAsync("..");

        btn.IsEnabled = true;
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
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



