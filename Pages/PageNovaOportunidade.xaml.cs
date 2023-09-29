using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageNovaOportunidade : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    Oportunidade Oportunidade = new Oportunidade();
    
    public PageNovaOportunidade()
	{
		InitializeComponent();
        //BindingContext = new ViewModelOportunidade();
        BindingContext = VMOportunidade;

    }
    public PageNovaOportunidade(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade = oportunidade;
        BindingContext = VMOportunidade;
        FillPage();
    }
    public void FillPage()
    {
        _entryTitulo.Text = Oportunidade.TituloDaSolucao;
        _editor1.Text     = Oportunidade.AspectosPositivos;
        _editor2.Text     = Oportunidade.AspectosNegativos;
    }
    void OnEditorTextChanged1(object sender, TextChangedEventArgs e)
    {
        string oldText=e.OldTextValue;
        string newText=e.NewTextValue;
        string myText =_editor1.Text;
    }
    void OnEditorTextChanged2(object sender, TextChangedEventArgs e)
    {
        string oldText=e.OldTextValue;
        string newText=e.NewTextValue;
        string myText =_editor2.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text=((Editor)sender).Text;
    }

    private async void Btn_SalvarOportunidade(object sender, EventArgs e)
    {
        Oportunidade.TituloDaSolucao   = _entryTitulo.Text;
        Oportunidade.AspectosPositivos = _editor1.Text;
        Oportunidade.AspectosNegativos = _editor2.Text;
        
        VMOportunidade.SalvarOportunidade(Oportunidade);

        await DisplayAlert("Aviso", "Oportunidade Registrada!", "Voltar");
        await Shell.Current.GoToAsync("..");
    }

    public void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;

        if (checkBox.IsChecked)
        {
            var test = 1;
            var test2 = test;
        }
    }
}