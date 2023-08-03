namespace CentralInovacao.Views;

public partial class ViewInicio : ContentPage
{
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

    [Obsolete]
    public ViewInicio()
    {
        InitializeComponent();

        // Exemplo de dados
        LastInteractions = new List<InteractionItem>
            {
                new InteractionItem { Title = "Edem Fernando", Description = "Alterou a foto de perfil" },
                new InteractionItem { Title = "Danilo Ferreira", Description = "Adicionou uma nova oportunidade" },
                new InteractionItem { Title = "Bruce Dickson", Description = "Iniciou um projeto" },
                new InteractionItem { Title = "Fernando Gregório", Description = "Finalizou um projeto" },
                new InteractionItem { Title = "Arthur Carvalho", Description = "Subiu no Ranking Geral" }
            };

        // Inicia um timer para atualizar automaticamente os itens do CarouselView
        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            // Roda os itens automaticamente
            RotateItems();

            // Retorna true para continuar a execução do timer
            return true;
        });
    }
    // Método para rotacionar os itens do CarouselView
    private void RotateItems()
    {
        // Remove o primeiro item e adiciona no final da lista
        var firstItem = LastInteractions[0];
        LastInteractions.RemoveAt(0);
        LastInteractions.Add(firstItem);

        // Atualiza o BindingContext para atualizar o CarouselView
        carouselView.BindingContext = null;
        carouselView.BindingContext = this;
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
    public void Btn_Animation(Button button)
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
        //Navegar para uma Página Específica
        // Os dois "//" servem para fazer navegação de rota absoluta
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
    private async void Btn_MeusProjetos(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration/ 2);

        //await Navigation.PushModalAsync(new ViewMeusProjetos());
        //await Shell.Current.GoToAsync($"{nameof(ViewMeusProjetos)}");
        await Shell.Current.GoToAsync($"//{nameof(ViewMeusProjetos)}");
    }
    private async void Btn_MinhasOp(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushModalAsync(new ViewMinhasOportunidades());
        //await Shell.Current.GoToAsync($"{nameof(ViewMinhasOportunidades)}");
        await Shell.Current.GoToAsync($"//{nameof(ViewMinhasOportunidades)}");
    }
    private async void Btn_RankingGeral(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushModalAsync(new ViewRankingGeral());
        //await Shell.Current.GoToAsync($"{nameof(ViewRankingGeral)}");
        await Shell.Current.GoToAsync($"//{nameof(ViewRankingGeral)}");
    }
    private async void Btn_NovaOp(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushAsync(new ViewNovaOportunidade());
        await Shell.Current.GoToAsync($"{nameof(ViewNovaOportunidade)}");
    }
    private async void Btn_Chamado(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int animationDuration = 100;

        Btn_Animation(button);
        await Task.Delay(animationDuration / 2);

        //await Navigation.PushAsync(new ViewChamado());
        await Shell.Current.GoToAsync($"{nameof(ViewChamado)}");
    }
    private async void OnImageTapped(object sender, EventArgs e)
    {
        // URL do site
        string websiteUrl = "https://academia.ceapebrasil.org.br/university/";

        // Abra o link do site no navegador
        await Launcher.OpenAsync(new Uri(websiteUrl));
    }
}

// Classe para representar os dados da "última interação"
public class InteractionItem
{
    public string Title { get; set; }
    public string Description { get; set; }
}
