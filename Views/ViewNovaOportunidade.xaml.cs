using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Views;

public partial class ViewNovaOportunidade : ContentPage
{
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    ModelOportunidade ModelOportunidade = new ModelOportunidade();  
    
    public ViewNovaOportunidade()
	{
		InitializeComponent();
        BindingContext = VMOportunidade;
        
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
        ModelOportunidade.TituloDaSolucao  =_entryTitulo.Text;
        ModelOportunidade.AspectosPositivos=_editor1.Text;
        ModelOportunidade.AspectosNegativos=_editor2.Text;
        
        VMOportunidade.SalvarOportunidade(ModelOportunidade);

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