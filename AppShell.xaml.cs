using CentralInovacao.Views;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Registro de Rotas
        Routing.RegisterRoute(nameof(ViewInicio), typeof(ViewInicio));
        Routing.RegisterRoute(nameof(ViewChamado), typeof(ViewChamado));
        Routing.RegisterRoute(nameof(ViewRankingGeral), typeof(ViewRankingGeral));
        Routing.RegisterRoute(nameof(ViewMeusProjetos), typeof(ViewMeusProjetos));
        Routing.RegisterRoute(nameof(ViewNovaOportunidade), typeof(ViewNovaOportunidade));
        Routing.RegisterRoute(nameof(ViewMinhasOportunidades), typeof(ViewMinhasOportunidades));

    }
}
