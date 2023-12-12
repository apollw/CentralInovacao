using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageNovaOportunidade : ContentPage
{
    RESTResources         RESTResources = new RESTResources();
    ViewModelProject      VMProject      = new ViewModelProject();

    public PageNovaOportunidade()
	{
		InitializeComponent();
        BindingContext = VMProject;        
        FillPage();
    }    

    public async void FillPage()
    {
        VMProject.ListAreaGeneral        = await RESTResources.GetListAreas();
        _CollectionViewAreas.ItemsSource = VMProject.ListAreaGeneral;
    }

    void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor1.Text;
    }

    void OnEditorTextChanged2(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText  = _editor2.Text;
    }

    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }

    private async void Btn_SalvarOportunidade(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        VMProject.Project.User                = Preferences.Get("AuthUserId", 0);
        VMProject.Project.Name                = _entryTitulo.Text; 
        VMProject.Project.DescriptionPositive = _editor1.Text;
        VMProject.Project.DescriptionNegative = _editor2.Text;

        if(await VMProject.SalvarProjeto(VMProject.Project))
        {
            await Shell.Current.DisplayAlert("Aviso", "Projeto Registrado!", "Voltar");
            await Shell.Current.GoToAsync("..");
        }     

        btn.IsEnabled = true;
    }

    public void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;

        //Verifica se o CheckBox foi clicado
        if (checkBox.BindingContext is ModelArea area)
        {
            if (e.Value)
            {
                VMProject.Project.ListArea.Add(area);
            }
            else
            {
                VMProject.Project.ListArea.Remove(area);
            }
        }                
    }

}