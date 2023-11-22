using CentralInovacao.Models;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageEsteiraSolicitacao : ContentPage
{
    Project               Projeto        = new Project();
    Oportunidade          Oportunidade   = new Oportunidade();
    ViewModelProject      VMProject      = new ViewModelProject();  
    ViewModelOportunidade VMOportunidade = new ViewModelOportunidade();
    public PageEsteiraSolicitacao(Oportunidade oportunidade)
    {
        InitializeComponent();
        Oportunidade   = oportunidade;
        BindingContext = VMOportunidade;
        FillPage();
    }
    public PageEsteiraSolicitacao(Project projeto)
    {
        InitializeComponent();
        Projeto = projeto;
        BindingContext = VMProject;
        FillPage();
    }
    public void FillPage()
    {
        _entryColaborador.Text = "Nome do Usuário";
        _entryTitulo.Text      = Oportunidade.Nome;
        _editor1.Text          = Oportunidade.DescricaoPositiva;
        _editor2.Text          = Oportunidade.DescricaoNegativa;

        //Atualizar Checkboxes
        _checkBox1.IsChecked  = Oportunidade.Setores.TryGetValue("Administrativo", out int valor1) && valor1 == 1;
        _checkBox2.IsChecked  = Oportunidade.Setores.TryGetValue("Análise de Crédito", out int valor2) && valor2 == 1;
        _checkBox3.IsChecked  = Oportunidade.Setores.TryGetValue("Auditoria", out int valor3) && valor3 == 1;
        _checkBox4.IsChecked  = Oportunidade.Setores.TryGetValue("Contabilidade", out int valor4) && valor4 == 1;
        _checkBox5.IsChecked  = Oportunidade.Setores.TryGetValue("Creli", out int valor5) && valor5 == 1;
        _checkBox6.IsChecked  = Oportunidade.Setores.TryGetValue("Financeiro", out int valor6) && valor6 == 1;
        _checkBox7.IsChecked  = Oportunidade.Setores.TryGetValue("Gestão de Pessoas", out int valor7) && valor7 == 1;
        _checkBox8.IsChecked  = Oportunidade.Setores.TryGetValue("Infraestrutura Civil", out int valor8) && valor8 == 1;
        _checkBox9.IsChecked  = Oportunidade.Setores.TryGetValue("Recebimentos", out int valor9) && valor9 == 1;
        _checkBox10.IsChecked = Oportunidade.Setores.TryGetValue("Renovação Automática", out int valor10) && valor10 == 1;
        _checkBox11.IsChecked = Oportunidade.Setores.TryGetValue("Seguros", out int valor11) && valor11 == 1;
        _checkBox12.IsChecked = Oportunidade.Setores.TryGetValue("T.I. Inovação", out int valor12) && valor12 == 1;
        _checkBox13.IsChecked = Oportunidade.Setores.TryGetValue("Tecnologia da Informação", out int valor13) && valor13 == 1;
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
    private async void Btn_EnviarAnalise(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await DisplayAlert("Alerta", "Solicitação Enviada para Análise", "Fechar");
        btn.IsEnabled = true;        
    }

    private async void Btn_Solicitacao(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;
        await DisplayAlert("Alerta", "Edição Completa", "Fechar");
        await Shell.Current.GoToAsync("..");
        btn.IsEnabled = true;
    }
}