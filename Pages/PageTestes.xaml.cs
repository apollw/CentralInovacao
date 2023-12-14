using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using RestSharp;

namespace CentralInovacao.Pages;

public partial class PageTestes : ContentPage
{
	RESTResources RESTResources = new RESTResources();
    RESTProject   RESTProject   = new RESTProject();
    RESTAnalysis  RESTAnalysis  = new RESTAnalysis();

    public PageTestes()
	{
		InitializeComponent();
	}

    //RESOURCES
    private async void Btn_CarregarListaUsuarios(object sender, EventArgs e)
    {
		List<ModelUser> ListaDeUsuarios = new List<ModelUser>();
		ListaDeUsuarios = await RESTResources.GetListUsers("GUSTAVO");
    }
    private async void Btn_CarregarListaStatus(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeStatus = new List<ModelGenericLocal>();
        ListaDeStatus = await RESTResources.GetListStatus();
    }
    private async void Btn_CarregarListaFuncoes(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeFuncoes = new List<ModelGenericLocal>();
        ListaDeFuncoes = await RESTResources.GetListFunctions();
    }
    private async void Btn_CarregarListaEstagios(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeEstagios = new List<ModelGenericLocal>();
        ListaDeEstagios = await RESTResources.GetListStages();
    }
    private async void Btn_CarregarListaClassificacoes(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeClassificacoes = new List<ModelGenericLocal>();
        ListaDeClassificacoes = await RESTResources.GetListClassifications();
    }
    private async void Btn_CarregarTiposDocumentos(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeDocumentos = new List<ModelGenericLocal>();
        ListaDeDocumentos = await RESTResources.GetListDocumentTypes();
    }
    private async void Btn_CarregarListaDeclinio(object sender, EventArgs e)
    {
        List<ModelGenericLocal> ListaDeRazoes = new List<ModelGenericLocal>();
        ListaDeRazoes = await RESTResources.GetListReasons();
    }

    //PROJECT
    private async void Btn_CheckStage(object sender, EventArgs e)
    {
        bool resposta = new bool();
        resposta = await RESTProject.GetCheckOpenStage(1807,4,1);
    }//--------------------IMPLEMENTADO
    private async void Btn_ClassificarProjeto(object sender, EventArgs e)
    {
        int classificacao = 1; //Classificação vai de 1 a 3
        int projeto_id = 13;

        //Enviar a classificação. Resposta = Ok, BadRequest
        bool resposta = await RESTProject.ClassifyProject(projeto_id,classificacao);
    }//------------IMPLEMENTADO
    private async void Btn_EnviarParaAnalise(object sender, EventArgs e)
    {
        bool resposta = new bool();
        int stage = 2;
        int project_id = 13;

        resposta = await RESTProject.SendToStage(project_id,stage);
    }//-------------IMPLEMENTADO
    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
        // Abre a galeria para selecionar uma imagem
        var result = await MediaPicker.PickPhotoAsync();
        Project project = new Project();

        project = await RESTProject.GetProject(13, 3068);

        if (result != null)
        {
            FileInfo f = new FileInfo(result.FullPath);

            byte[] imageByte = File.ReadAllBytes(f.FullName);
            string file = Convert.ToBase64String(imageByte);

            ViewModelProject vmp = new ViewModelProject();

            vmp.SalvarImagemProjeto(project, f, file);

            _img.Source = ImageSource.FromStream(() => new MemoryStream(imageByte));
        }
    }//--------------IMPLEMENTADO

    //ANALYSIS
    private async void Btn_AtualizarAnalise(object sender, EventArgs e)
    {
        bool resposta = new bool();

        string descricao="Descrição teste";

        //public async Task<bool> UpdateAnalysis(int project_id, string descricao)

        int project_id = 13;
        resposta = await RESTAnalysis.UpdateAnalysis(project_id,descricao);
    }//--------------IMPLEMENTADO
    private async void Btn_AtivarProjeto(object sender, EventArgs e)
    {
        bool resposta = new bool();

        int project_id = 13;
        resposta = await RESTAnalysis.ActivateProject(project_id);
    }//-----------------IMPLEMENTADO
    private async void Btn_DeclinarProjeto(object sender, EventArgs e)
    {
        bool resposta = new bool();

        int project_id = 13;
        int decline_reason = 1;
        resposta = await RESTAnalysis.DeclineProject(project_id, decline_reason);
    }//---------------IMPLEMENTADO
}

