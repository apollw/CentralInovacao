using CentralInovacao.Models;
using CentralInovacao.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CentralInovacao.Pages;

public partial class PageClassificar : ContentPage
{
    Project                 objProject            = new Project();
    RESTProject             objRESTProject        = new RESTProject();
    RESTResources           objRESTResources      = new RESTResources();
    List<ModelGenericLocal> ListaDeClassificacoes = new List<ModelGenericLocal>();

    public PageClassificar(Project projeto)
	{
		InitializeComponent();
        GetLista();
        objProject = projeto;

        _picker.ItemsSource        = ListaDeClassificacoes;
        _picker.ItemDisplayBinding = new Binding("Description");
    }

    public async void GetLista()
    {
        ListaDeClassificacoes = await objRESTResources.GetListClassifications();
    }

    private async void Btn_Retornar(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void Btn_Classificar(object sender, EventArgs e)
    {
        if (_picker.SelectedItem is ModelGenericLocal selected)
        {
            if (await objRESTProject.ClassifyProject(objProject.Id, selected.Id))
            {
                await DisplayAlert("Aviso", "Classificação Registrada!", "Retornar");
                await Shell.Current.Navigation.PopModalAsync();
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, selecione uma classificação.", "OK");
        }
    }
}