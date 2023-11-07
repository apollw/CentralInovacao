using CentralInovacao.Models;
using CentralInovacao.ViewModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageNovaOportunidade : ContentPage
{
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    public PageNovaOportunidade()
	{
		InitializeComponent();
        BindingContext = VMOportunidade;       
    }
    public PageNovaOportunidade(Oportunidade oportunidade)
    {
        InitializeComponent();
        VMOportunidade.Oportunidade = oportunidade;
        BindingContext = VMOportunidade;
        //FillPage();
    }
    //public void FillPage()
    //{
    //    _entryColaborador.Text = "Nome do Usuário";
    //    _entryTitulo.Text = Oportunidade.Nome;
    //    _editor1.Text = Oportunidade.DescricaoPositiva;
    //    _editor2.Text = Oportunidade.DescricaoNegativa;

    //    //Atualizar Checkboxes
    //    _checkBox1.IsChecked = Oportunidade.Setores.TryGetValue("Administrativo", out int valor1) && valor1 == 1;
    //    _checkBox2.IsChecked = Oportunidade.Setores.TryGetValue("Análise de Crédito", out int valor2) && valor2 == 1;
    //    _checkBox3.IsChecked = Oportunidade.Setores.TryGetValue("Auditoria", out int valor3) && valor3 == 1;
    //    _checkBox4.IsChecked = Oportunidade.Setores.TryGetValue("Contabilidade", out int valor4) && valor4 == 1;
    //    _checkBox5.IsChecked = Oportunidade.Setores.TryGetValue("Creli", out int valor5) && valor5 == 1;
    //    _checkBox6.IsChecked = Oportunidade.Setores.TryGetValue("Financeiro", out int valor6) && valor6 == 1;
    //    _checkBox7.IsChecked = Oportunidade.Setores.TryGetValue("Gestão de Pessoas", out int valor7) && valor7 == 1;
    //    _checkBox8.IsChecked = Oportunidade.Setores.TryGetValue("Infraestrutura Civil", out int valor8) && valor8 == 1;
    //    _checkBox9.IsChecked = Oportunidade.Setores.TryGetValue("Recebimentos", out int valor9) && valor9 == 1;
    //    _checkBox10.IsChecked = Oportunidade.Setores.TryGetValue("Renovação Automática", out int valor10) && valor10 == 1;
    //    _checkBox11.IsChecked = Oportunidade.Setores.TryGetValue("Seguros", out int valor11) && valor11 == 1;
    //    _checkBox12.IsChecked = Oportunidade.Setores.TryGetValue("T.I. Inovação", out int valor12) && valor12 == 1;
    //    _checkBox13.IsChecked = Oportunidade.Setores.TryGetValue("Tecnologia da Informação", out int valor13) && valor13 == 1;
    //}

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

        Oportunidade.Id                = VMOportunidade.GerarNovoId(Oportunidade.Id);
        Oportunidade.Nome              = _entryTitulo.Text;
        Oportunidade.DescricaoPositiva = _editor1.Text;
        Oportunidade.DescricaoNegativa = _editor2.Text;
        Oportunidade.Status            = 0;
        Oportunidade.Data              = DateTime.Now;
        Oportunidade.Analista          = 2507;
        
        VMOportunidade.SalvarOportunidadeLocal(Oportunidade);

        await DisplayAlert("Aviso", "Oportunidade Registrada!", "Voltar");
        await Shell.Current.GoToAsync("..");

        btn.IsEnabled = true;
    }
    public void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;

        // Recuperar o nome do setor associado a esta CheckBox
        var nomeSetor = checkBox.AutomationId; // AutomationId associa o nome do setor

        if (!string.IsNullOrEmpty(nomeSetor))
        {
            if (Oportunidade.Setores.ContainsKey(nomeSetor))
            {
                Oportunidade.Setores[nomeSetor] = checkBox.IsChecked ? 1 : 0;
            }
        }
    }
}
