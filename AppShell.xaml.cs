using CentralInovacao.Views;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Registro de Rotas
		Routing.RegisterRoute(nameof(ViewInicio), typeof(ViewInicio));
        Routing.RegisterRoute(nameof(ViewMeusProjetos), typeof(ViewMeusProjetos));
        Routing.RegisterRoute(nameof(ViewMinhasOportunidades), typeof(ViewMinhasOportunidades));

    }
}
