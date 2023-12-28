using CentralInovacao.Pages;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Registro de Rotas
        Routing.RegisterRoute(nameof(PageFiltro)                , typeof(PageFiltro));
        Routing.RegisterRoute(nameof(PageProjeto)               , typeof(PageProjeto));
        Routing.RegisterRoute(nameof(PageLoading)               , typeof(PageLoading));
        Routing.RegisterRoute(nameof(PageEsteiraSquad)          , typeof(PageEsteiraSquad));
        Routing.RegisterRoute(nameof(PageEsteiraBriefing)       , typeof(PageEsteiraBriefing));
        Routing.RegisterRoute(nameof(PageNovaOportunidade)      , typeof(PageNovaOportunidade));
        Routing.RegisterRoute(nameof(PageEsteiraSolicitacao)    , typeof(PageEsteiraSolicitacao));
        Routing.RegisterRoute(nameof(PageEsteiraPlanejamento)   , typeof(PageEsteiraPlanejamento));
        Routing.RegisterRoute(nameof(PageEsteiraAcompanhamento) , typeof(PageEsteiraAcompanhamento));
    }
}
