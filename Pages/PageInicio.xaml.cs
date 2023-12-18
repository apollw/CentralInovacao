using CentralInovacao.MiddlewareApi;
using CentralInovacao.Models;
using CentralInovacao.Services;
using CentralInovacao.ViewModel;
using Microsoft.Maui.Controls;

namespace CentralInovacao.Pages;

public partial class PageInicio : ContentPage
{
    private readonly AuthService _authService;
    
    public PageInicio(AuthService authService)
    {
        InitializeComponent();
        _authService   = authService;
    }

    private async void OnProfileImageTapped(object sender, EventArgs e)
    {
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
        string websiteUrl = "https://academia.ceapebrasil.org.br/university/";
        await Launcher.OpenAsync(new Uri(websiteUrl));
    }

    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);
      
        button.IsEnabled = false;
        await Shell.Current.GoToAsync($"{nameof(PageNovaOportunidade)}");
        button.IsEnabled = true;
       
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (Preferences.ContainsKey("AuthUserId") && Preferences.ContainsKey("AuthUserName"))
        {
            string NomeCompleto = Preferences.Get("AuthUserName", string.Empty);
            string[] partes = NomeCompleto.Split(' ');

            if (partes.Length > 0)
            {
                string primeiroNome = partes[0].Substring(0, 1).ToUpper() + partes[0].Substring(1).ToLower();

                _lblUsername.Text = "Bem vindo, " + primeiroNome + "!";
            }
        }
    }
}
