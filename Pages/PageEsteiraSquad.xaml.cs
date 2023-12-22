using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSquad : ContentPage
{
    int              user_id   = Preferences.Get("AuthUserId", 0);
    ViewModelProject VMProject = new ViewModelProject();

    public PageEsteiraSquad(Project projeto)
    {
        InitializeComponent();
        VMProject.ObjProject = projeto;
        BindingContext       = VMProject;
    }

    public async void LoadSquad()
    {
        List<Squad> ListaDaSquad = await RESTSquad.GetSquadProject(VMProject.ObjProject.Id, user_id);
        VMProject.SquadProject   = new ObservableCollection<Squad>(ListaDaSquad);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        LoadSquad();
    }

    private async void Button_AddColaborador(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await Shell.Current.Navigation.PushAsync(new PageAddColaborador(VMProject.ObjProject));
        btn.IsEnabled = true;
    }

    private async void Button_AtualizarUsuarioSquad(object sender, EventArgs e)
    {
        var imageButton = sender as ImageButton;
        var squad = imageButton?.BindingContext as Squad;

        imageButton.IsEnabled = false;
        if (squad != null)
        {
            int novoCodigo = (squad.Status == 1) ? 2 : 1;
            if(await RESTSquad.UpdateUserInSquad(VMProject.ObjProject.Id, squad.User, user_id, novoCodigo))
            {
                LoadSquad();
            }
        }
        imageButton.IsEnabled = true;
    }

    private async void Button_ExcluirUsuarioSquad(object sender, EventArgs e)
    {
        var imageButton = sender as ImageButton;
        var squad  = imageButton?.BindingContext as Squad;

        imageButton.IsEnabled = false;
        if (squad != null)
        {
            string message = "Deseja excluir " + squad.LkpUser + "?";
            bool confirmar = await DisplayAlert("Aviso", message, "Sim", "Não");

            if (confirmar)
            {
                if(await RESTSquad.DeleteUserInSquad(VMProject.ObjProject.Id, squad.User, user_id))
                {
                    VMProject.SquadProject.Remove(squad);
                }
            }
        }
        imageButton.IsEnabled = true;
    }

    private async void Button_EnviarPlanejamento(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        if (await RESTProject.SendToStage(VMProject.ObjProject.Id, 4))
            await DisplayAlert("Aviso", "Enviado para Planejamento", "Fechar");
        btn.IsEnabled = true;
    }
}