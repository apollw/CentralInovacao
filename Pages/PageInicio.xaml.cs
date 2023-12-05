using CentralInovacao.MiddlewareApi;
using CentralInovacao.Models;
using CentralInovacao.Services;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageInicio : ContentPage
{
    private readonly AuthService _authService;
    ModelUserLocal Usuario = new ModelUserLocal();
    
    public PageInicio(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;

        // Recupera os dados do Usu�rio
        if (Preferences.ContainsKey("AuthUserId") && Preferences.ContainsKey("AuthUserName"))
        {
            // 0 � um valor padr�o
            Usuario.Id = Preferences.Get("AuthUserId", 0);
            // string.Empty � um valor padr�o caso n�o exista
            string NomeCompleto = Preferences.Get("AuthUserName", string.Empty);

            // Divide a string em partes usando espa�os como delimitador
            string[] partes = NomeCompleto.Split(' ');

            // Verifica se h� pelo menos um nome
            if (partes.Length > 0)
            {
                // Pega o primeiro nome e transforma em caixa baixa, exceto a primeira letra
                string primeiroNome = partes[0].Substring(0, 1).ToUpper() + partes[0].Substring(1).ToLower();

                Usuario.Name = primeiroNome;
            }
        }

        BindingContext = Usuario;              

    }

    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
        // Abre a galeria para selecionar uma imagem
        var result = await MediaPicker.PickPhotoAsync();

        if (result != null)
        {
            FileInfo f = new FileInfo(result.FullPath);

            byte[] imageByte = File.ReadAllBytes(f.FullName);
            string file = Convert.ToBase64String(imageByte);            
            
            _fotoPerfil.Source = ImageSource.FromStream(() => new MemoryStream(imageByte));
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
        Usuario.Id = 0;
        Usuario.Name = String.Empty;
        
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
