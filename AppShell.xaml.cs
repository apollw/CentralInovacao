using CentralInovacao.Pages;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Registro de Rotas
        Routing.RegisterRoute(nameof(PageProjeto)              , typeof(PageProjeto));        
        Routing.RegisterRoute(nameof(PageNovaOportunidade)     , typeof(PageNovaOportunidade));

        Routing.RegisterRoute(nameof(PageInicio)               , typeof(PageInicio));
        Routing.RegisterRoute(nameof(PagePontuacao)            , typeof(PagePontuacao));
        Routing.RegisterRoute(nameof(PageRankingGeral)         , typeof(PageRankingGeral));
        Routing.RegisterRoute(nameof(PageMeusProjetos)         , typeof(PageMeusProjetos));
        Routing.RegisterRoute(nameof(PageMinhasOportunidades)  , typeof(PageMinhasOportunidades));

        Routing.RegisterRoute(nameof(PageEsteiraSquad)         , typeof(PageEsteiraSquad));
        Routing.RegisterRoute(nameof(PageEsteiraBriefing)      , typeof(PageEsteiraBriefing));
        Routing.RegisterRoute(nameof(PageEsteiraSolicitacao)   , typeof(PageEsteiraSolicitacao));
        Routing.RegisterRoute(nameof(PageEsteiraPlanejamento)  , typeof(PageEsteiraPlanejamento));
        Routing.RegisterRoute(nameof(PageEsteiraAcompanhamento), typeof(PageEsteiraAcompanhamento));


    }
}
