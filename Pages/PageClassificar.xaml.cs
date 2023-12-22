using CentralInovacao.Models;
using CentralInovacao.Repositories;

namespace CentralInovacao.Pages;

public partial class PageClassificar : ContentPage
{
    Project                 _objProject           = new Project();
    List<ModelGenericLocal> ListaDeClassificacoes = new List<ModelGenericLocal>();

    public PageClassificar(Project projeto)
	{
		InitializeComponent();
        GetLista();
        _objProject = projeto;

        _picker.ItemsSource        = ListaDeClassificacoes;
        _picker.ItemDisplayBinding = new Binding("Description");
    }

    public async void GetLista()
    {
        ListaDeClassificacoes = await RESTResources.GetListClassifications();
    }

    private async void Button_Retornar(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void Button_Classificar(object sender, EventArgs e)
    {
        if (_picker.SelectedItem is ModelGenericLocal selected)
        {
            if (await RESTProject.ClassifyProject(_objProject.Id, selected.Id))
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