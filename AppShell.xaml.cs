using CentralInovacao.Views;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Registro de Rotas
        Routing.RegisterRoute(nameof(ViewInicio), typeof(ViewInicio));
        Routing.RegisterRoute(nameof(ViewProjeto), typeof(ViewProjeto));
        Routing.RegisterRoute(nameof(ViewChamado), typeof(ViewChamado));
        Routing.RegisterRoute(nameof(ViewNovaOportunidade), typeof(ViewNovaOportunidade));

        Routing.RegisterRoute(nameof(ViewRankingGeral), typeof(ViewRankingGeral));
        Routing.RegisterRoute(nameof(ViewMeusProjetos), typeof(ViewMeusProjetos));
        Routing.RegisterRoute(nameof(ViewMinhasOportunidades), typeof(ViewMinhasOportunidades));

        Routing.RegisterRoute(nameof(ViewEsteiraSquad), typeof(ViewEsteiraSquad));
        Routing.RegisterRoute(nameof(ViewEsteiraBriefing), typeof(ViewEsteiraBriefing));
        Routing.RegisterRoute(nameof(ViewEsteiraSolicitacao), typeof(ViewEsteiraSolicitacao));
        Routing.RegisterRoute(nameof(ViewEsteiraPlanejamento), typeof(ViewEsteiraPlanejamento));
        Routing.RegisterRoute(nameof(ViewEsteiraAcompanhamento), typeof(ViewEsteiraAcompanhamento));


    }
}
