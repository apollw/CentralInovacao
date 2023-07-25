using CentralInovacao.Views;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ViewInicio), typeof(ViewInicio));
        Routing.RegisterRoute(nameof(ViewInteracoes), typeof(ViewInteracoes));
        Routing.RegisterRoute(nameof(ViewMeusProjetos), typeof(ViewMeusProjetos));
        Routing.RegisterRoute(nameof(ViewMinhasOportunidades), typeof(ViewMinhasOportunidades));

    }
}
