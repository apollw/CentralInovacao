using CentralInovacao.Models;
using CentralInovacao.Services;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageInicio : ContentPage
{
    private readonly AuthService _authService;
    Oportunidade Oportunidade = new Oportunidade();

    private List<InteractionItem> lastInteractions;
    public List<InteractionItem> LastInteractions
    {
        get => lastInteractions;
        set
        {
            lastInteractions = value;
            OnPropertyChanged();
        }
    }
    public PageInicio(AuthService authService)
    {
        InitializeComponent();
        _authService   = authService;
        BindingContext = this;

        // Exemplo de dados
        LastInteractions = new List<InteractionItem>
            {
                new InteractionItem { Title = "Edem Fernando", Description = "Alterou a foto de perfil" },
                new InteractionItem { Title = "Danilo Ferreira", Description = "Adicionou uma nova oportunidade" },
                new InteractionItem { Title = "Bruce Dickson", Description = "Iniciou um projeto" },
                new InteractionItem { Title = "Fernando Gregório", Description = "Finalizou um projeto" },
                new InteractionItem { Title = "Arthur Carvalho", Description = "Subiu no Ranking Geral" }
            };

        List<string> imagens = new List<string>
        {
            "img_medalha1.png",
            "img_medalha2.png",
            "img_medalha3.png"
        };

        //_carouselView.ItemsSource = imagens;
    }

    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
        // Abre a galeria para selecionar uma imagem
        var result = await MediaPicker.PickPhotoAsync();

        if (result != null)
        {
            // Lê a imagem selecionada e converte em bytes
            using (var stream = await result.OpenReadAsync())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    byte[] imageBytes = ms.ToArray();

                    // Salva a imagem em algum armazenamento, como o banco de dados ou um serviço de armazenamento em nuvem

                    // Exemplo: Atualiza a imagem exibida na tela
                    _fotoPerfil.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }
            }
        }
    }
    /*BOTÕES*/
    public void Btn_Animation(ImageButton button)
    {
        // Define a escala inicial do botão
        button.Scale = 1;
        // Cria a animação de escalonamento
        var scaleAnimation = new Animation(v => button.Scale = v, 1, 0.8);
        // Define a duração da animação (em milissegundos)
        scaleAnimation.Commit(button, "PressingButtonAnimation", length: 250, easing: Easing.SinOut, finished: (v, c) => button.Scale = 1);
    }
    private async void Btn_Logout(object sender, EventArgs e)
    {        
        _authService.Logout();
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

        //Executa Animação
        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);
      
        button.IsEnabled = false;

        await Shell.Current.GoToAsync($"{nameof(PageNovaOportunidade)}");

        //Reativa o botão após o fim da tarefa
        button.IsEnabled = true;
       
    }
}

// Classe para representar os dados da "última interação"
public class InteractionItem
{
    public string Title { get; set; }
    public string Description { get; set; }
}
