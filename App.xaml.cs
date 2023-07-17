using CentralInovacao.Views;

namespace CentralInovacao;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
    }
}
