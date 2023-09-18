using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Views;

public partial class ViewNovaOportunidade : ContentPage
{
    ViewModelOportunidade ViewModelOportunidade = new ViewModelOportunidade();
    ModelOportunidade ModelOportunidade = new ModelOportunidade();
	public ViewNovaOportunidade()
	{
		InitializeComponent();
        BindingContext = ViewModelOportunidade;
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("", "Oportunidade Salva", "Fechar");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        ModelOportunidade.TituloDaSolucao= _entryTitulo.Text;
        ModelOportunidade.AspectosPositivos = _editor1.Text;
        ModelOportunidade.AspectosNegativos = _editor2.Text;

        ViewModelOportunidade.SalvarOportunidade(ModelOportunidade);

        await DisplayAlert("", "Oportunidade Registrada", "Fechar");
        await Shell.Current.GoToAsync("..");
    }
}