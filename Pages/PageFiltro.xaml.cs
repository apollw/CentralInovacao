using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageFiltro : ContentPage
{
    ViewModelProject        VMProject        = new ViewModelProject();
    List<ModelGenericLocal> ListaStatus      = new List<ModelGenericLocal>();

    public PageFiltro()
	{
		InitializeComponent();
        FillPage();
	}

    public async void FillPage()
    {
        ListaStatus               = await RESTResources.GetListStatus();
        VMProject.ListAreaGeneral = await RESTResources.GetListAreas();

        _CollectionViewAreas.ItemsSource  = VMProject.ListAreaGeneral;
        _CollectionViewStatus.ItemsSource = ListaStatus;
    }
}