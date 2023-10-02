using CentralInovacao.Pages;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Registrar rotas no XAML e no Code-Behind causa ambiguidade de rotas

        //Routing.RegisterRoute(nameof(PageInicio)               , typeof(PageInicio));
        //Routing.RegisterRoute(nameof(PagePontuacao)            , typeof(PagePontuacao));
        //Routing.RegisterRoute(nameof(PageRankingGeral)         , typeof(PageRankingGeral));
        //Routing.RegisterRoute(nameof(PageMeusProjetos)         , typeof(PageMeusProjetos));
        //Routing.RegisterRoute(nameof(PageMinhasOportunidades)  , typeof(PageMinhasOportunidades));

        //Registro de Rotas
        Routing.RegisterRoute(nameof(PageProjeto)               , typeof(PageProjeto));
        Routing.RegisterRoute(nameof(PageEsteiraSquad)          , typeof(PageEsteiraSquad));
        //Routing.RegisterRoute(nameof(PageEsteiraGeral)          , typeof(PageEsteiraGeral));
        Routing.RegisterRoute(nameof(PageEsteiraBriefing)       , typeof(PageEsteiraBriefing));
        Routing.RegisterRoute(nameof(PageNovaOportunidade)      , typeof(PageNovaOportunidade));
        Routing.RegisterRoute(nameof(PageEsteiraSolicitacao)    , typeof(PageEsteiraSolicitacao));
        Routing.RegisterRoute(nameof(PageEsteiraPlanejamento)   , typeof(PageEsteiraPlanejamento));
        Routing.RegisterRoute(nameof(PageEsteiraAcompanhamento) , typeof(PageEsteiraAcompanhamento));


    }
}
