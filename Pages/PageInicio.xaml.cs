using CentralInovacao.Models;
using CentralInovacao.Services;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageInicio : ContentPage
{
    private readonly AuthService _authService;
    Oportunidade     Oportunidade = new Oportunidade();
    ViewModelUsuario VMUsuario    = new ViewModelUsuario();

    //private List<InteractionItem> lastInteractions;
    //public List<InteractionItem> LastInteractions
    //{
    //    get => lastInteractions;
    //    set
    //    {
    //        lastInteractions = value;
    //        OnPropertyChanged();
    //    }
    //}
    
    public PageInicio(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
        // Recupera os dados do Usu�rio
        if (Preferences.ContainsKey("AuthUserId") && Preferences.ContainsKey("AuthUserName"))
        {
            // 0 � um valor padr�o
            VMUsuario.Usuario.Id = Preferences.Get("AuthUserId", 0);
            // string.Empty � um valor padr�o caso n�o exista
            VMUsuario.Usuario.Nome = Preferences.Get("AuthUserName", string.Empty);
        }
        BindingContext = VMUsuario;              

        //// Exemplo de dados
        //LastInteractions = new List<InteractionItem>
        //{   
        //    new InteractionItem { Title = "Edem Fernando", Description = "Alterou a foto de perfil" },
        //    new InteractionItem { Title = "Danilo Ferreira", Description = "Adicionou uma nova oportunidade" },
        //    new InteractionItem { Title = "Bruce Dickson", Description = "Iniciou um projeto" },
        //    new InteractionItem { Title = "Fernando Greg�rio", Description = "Finalizou um projeto" },
        //    new InteractionItem { Title = "Arthur Carvalho", Description = "Subiu no Ranking Geral" }
        //};
    }

    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
        // Abre a galeria para selecionar uma imagem
        var result = await MediaPicker.PickPhotoAsync();

        if (result != null)
        {
            // L� a imagem selecionada e converte em bytes
            using (var stream = await result.OpenReadAsync())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    byte[] imageBytes = ms.ToArray();

                    // Salva a imagem em algum armazenamento, como o banco de dados ou um servi�o de armazenamento em nuvem

                    // Exemplo: Atualiza a imagem exibida na tela
                    _fotoPerfil.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }
            }
        }
    }
    public void Btn_Animation(ImageButton button)
    {
        // Define a escala inicial do bot�o
        button.Scale = 1;
        // Cria a anima��o de escalonamento
        var scaleAnimation = new Animation(v => button.Scale = v, 1, 0.8);
        // Define a dura��o da anima��o (em milissegundos)
        scaleAnimation.Commit(button, "PressingButtonAnimation", length: 250, easing: Easing.SinOut, finished: (v, c) => button.Scale = 1);
    }
    private async void Btn_Logout(object sender, EventArgs e)
    {   
        _authService.Logout();

        //Ao deslogar, apaga os dados que est�o na ViewModel
        VMUsuario.Usuario.Id = 0;
        VMUsuario.Usuario.Nome = String.Empty;
        
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
    private async void OnImageTapped(object sender, EventArgs e)
    {
        // URL do site
        string websiteUrl = "https://academia.ceapebrasil.org.br/university/";

        // Abre o link do site no navegador
        await Launcher.OpenAsync(new Uri(websiteUrl));
    }
    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int animationDuration = 100;

        //Executa Anima��o
        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);
      
        button.IsEnabled = false;

        await Shell.Current.GoToAsync($"{nameof(PageNovaOportunidade)}");

        //Reativa o bot�o ap�s o fim da tarefa
        button.IsEnabled = true;
       
    }
}

//// Classe para representar os dados da "�ltima intera��o"
//public class InteractionItem
//{
//    public string Title { get; set; }
//    public string Description { get; set; }
//}
