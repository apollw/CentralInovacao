using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CentralInovacao.Pages;

public partial class PageAddColaborador : ContentPage
{
    int             _user_id         = Preferences.Get("AuthUserId", 0);
    Project         _objProjeto      = new Project();
    RESTSquad       _objRESTSquad    = new RESTSquad();
	ViewModelSquad  _vmSquad         = new ViewModelSquad();

    public PageAddColaborador(Project projeto)
	{
		InitializeComponent();

        _vmSquad.CarregarListaDeFuncoes();
        _vmSquad.CarregarListaDeUsuarios();

        _objProjeto         = projeto;
        _picker.ItemsSource = _vmSquad.FunctionList;

        BindingContext = _vmSquad;
    }

    private async void Btn_Add_Colaborador(object sender, EventArgs e)
    {
        if (_picker.SelectedItem is ModelGenericLocal selectedFunction)
        {
            Squad squadUser = new Squad();

            squadUser.User     = 0; //CORRIGIR
            squadUser.Function = selectedFunction.Id;
            squadUser.Status   = 1;          

            if (await _objRESTSquad.AddUserInSquad(squadUser, _objProjeto.Id, _user_id))
            {
                await DisplayAlert("Aviso", "Proposta Declinada com Sucesso!", "Retornar");
                await Shell.Current.Navigation.PopModalAsync();
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, selecione uma razão para declínio.", "OK");
        }
    }
}