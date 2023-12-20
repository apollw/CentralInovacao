using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageFiltro : ContentPage
{
    RESTResources           objRESTResources = new RESTResources();
    ViewModelProject        VMProject        = new ViewModelProject();
    List<ModelGenericLocal> ListaStatus      = new List<ModelGenericLocal>();

    public PageFiltro()
	{
		InitializeComponent();
        FillPage();
	}

    public async void FillPage()
    {
        ListaStatus               = await objRESTResources.GetListStatus();
        VMProject.ListAreaGeneral = await objRESTResources.GetListAreas();

        _CollectionViewAreas.ItemsSource  = VMProject.ListAreaGeneral;
        _CollectionViewStatus.ItemsSource = ListaStatus;
    }
}