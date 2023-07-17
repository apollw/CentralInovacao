using CentralInovacao.Views;

namespace CentralInovacao;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ViewFirstPage), typeof(ViewFirstPage));
        Routing.RegisterRoute(nameof(ViewSecondPage), typeof(ViewSecondPage));

    }
}
