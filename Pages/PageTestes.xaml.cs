using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using RestSharp;

namespace CentralInovacao.Pages;

public partial class PageTestes : ContentPage
{
	RESTResources RESTResources = new RESTResources();
    RESTProject   RESTProject   = new RESTProject();

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
    private async void Btn_CheckStage(object sender, EventArgs e) //Dúvida
    {
        bool resposta = new bool();
        resposta = await RESTProject.GetCheckOpenStage(1807,4,1);
    }    
}
