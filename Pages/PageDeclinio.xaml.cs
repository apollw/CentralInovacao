using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageDeclinio : ContentPage
{
    Project                 objProject    = new Project();
    List<ModelGenericLocal> ListaDeRazoes = new List<ModelGenericLocal>();

    public PageDeclinio(Project projeto)
    {
        InitializeComponent();
        GetLista();
        objProject = projeto;

        _picker.ItemsSource        = ListaDeRazoes;
        _picker.ItemDisplayBinding = new Binding("Description");
    }

    public async void GetLista()
    {
        ListaDeRazoes = await RESTResources.GetListReasons();
    }

    private async void Btn_Retornar(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void Btn_Declinar(object sender, EventArgs e)
    {
        if (_picker.SelectedItem is ModelGenericLocal selected)
        {
            if (await RESTAnalysis.DeclineProject(objProject.Id, selected.Id))
            {
                await DisplayAlert("Aviso","Proposta Declinada com Sucesso!","Retornar");
                await Shell.Current.Navigation.PopModalAsync();
            }            
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, selecione uma razão para declínio.", "OK");
        }
    }

}