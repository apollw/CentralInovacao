using CentralInovacao.Models;
using CentralInovacao.ViewModels;

namespace CentralInovacao.Views;

public partial class ViewProjeto : ContentPage
{
    public ViewProjeto()
	{
		InitializeComponent();
        BindingContext = new ViewModelProjeto();
    }   
}