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
    private async void Btn_CarregarListaUsuarios(object sender, EventArgs e)
    {
		List<ModelUser> ListaDeUsuarios = new List<ModelUser>();
		ListaDeUsuarios = await RESTResources.GetListUsers("GUSTAVO");
    }
    private async void Btn_CarregarListaStatus(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeStatus = new List<ModelGeneric>();
        ListaDeStatus = await RESTResources.GetListStatus();
    }
    private async void Btn_CarregarListaFuncoes(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeFuncoes = new List<ModelGeneric>();
        ListaDeFuncoes = await RESTResources.GetListFunctions();
    }
    private async void Btn_CarregarListaEstagios(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeEstagios = new List<ModelGeneric>();
        ListaDeEstagios = await RESTResources.GetListStages();
    }
    private async void Btn_CarregarListaClassificacoes(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeClassificacoes = new List<ModelGeneric>();
        ListaDeClassificacoes = await RESTResources.GetListClassifications();
    }
    private async void Btn_CarregarTiposDocumentos(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeDocumentos = new List<ModelGeneric>();
        ListaDeDocumentos = await RESTResources.GetListDocumentTypes();
    }
    private async void Btn_CarregarListaDeclinio(object sender, EventArgs e)
    {
        List<ModelGeneric> ListaDeRazoes = new List<ModelGeneric>();
        ListaDeRazoes = await RESTResources.GetListReasons();
    }
    private async void Btn_CheckStage(object sender, EventArgs e)
    {
        bool resposta = new bool();
        resposta = await RESTProject.GetCheckOpenStage(1807,4,1);
    }
    private async void Btn_ClassificarProjeto(object sender, EventArgs e)
    {
        int classificacao = 1; //Classifica��o vai de 1 a 3
        int projeto_id = 13;

        //Enviar a classifica��o. Resposta = Ok, BadRequest
        bool resposta = await RESTProject.ClassifyProject(projeto_id,classificacao);
    }
    private async void Btn_EnviarParaAnalise(object sender, EventArgs e)
    {
        bool resposta = new bool();
        resposta = await RESTProject.SendToAnalysis(13);
    }
    private async void Btn_AtualizarAnalise(object sender, EventArgs e)
    {
        bool resposta = new bool();

        string descricao="Descri��o teste";

        int project_id = 13;
        resposta = await RESTAnalysis.UpdateAnalysis(project_id,descricao);
    }

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
    }


}
