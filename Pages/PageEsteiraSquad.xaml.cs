using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
    int              user_id        = Preferences.Get("AuthUserId", 0);
    RESTSquad        ObjRESTSquad   = new RESTSquad();
    RESTProject      ObjRESTProject = new RESTProject();
    ViewModelProject VMProject      = new ViewModelProject();

    public PageEsteiraSquad(Project projeto)
    {
        InitializeComponent();
        VMProject.ObjProject = projeto;
        BindingContext       = VMProject;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        List<Squad> ListaDaSquad = await ObjRESTSquad.GetSquadProject(VMProject.ObjProject.Id, user_id);
        VMProject.SquadProject   = new ObservableCollection<Squad>(ListaDaSquad);
    }

    private async void Btn_AddColaborador(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await Shell.Current.Navigation.PushAsync(new PageAddColaborador(VMProject.ObjProject));
        btn.IsEnabled = true;
    }

    private async void Button_EnviarPlanejamento(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        if (await ObjRESTProject.SendToStage(VMProject.ObjProject.Id, 4))
            await DisplayAlert("Aviso", "Enviado para Planejamento", "Fechar");
        btn.IsEnabled = true;
    }
}