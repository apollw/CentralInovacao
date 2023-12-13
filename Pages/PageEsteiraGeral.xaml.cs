using CentralInovacao.Models;
using CentralInovacao.Pages;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;
using System.Reflection;
using System.Windows.Input;

namespace CentralInovacao.Pages;

public partial class PageEsteiraGeral : ContentPage
{    
    public PageEsteiraGeral(Project project)
    {
        InitializeComponent();
        ViewModelButton VMButton = new ViewModelButton(project);
        VMButton.ActivityIndicatorLocal = activityIndicator;
        BindingContext = VMButton;
    }

    public class ViewModelButton
    {
        public Project           Projeto { get; set; }
        public List<ButtonModel> Buttons { get; set; }
        public ActivityIndicator ActivityIndicatorLocal { get; set; }

        public ViewModelButton(Project projeto)
        {
            Projeto = projeto;

            Buttons = new List<ButtonModel>
            {
                new ButtonModel(
                    "Solicitação",
                    "Clique para ver mais detalhes sobre a oportunidade registrada",
                    "btn_request.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Análise",
                    "Acompanhe o status da Análise da oportunidade registrada",
                    "btn_analysis.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Squad",
                    "Visualize os integrantes da Squad responsável pelo projeto",
                    "btn_group.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Planejamento",
                    "Visualize a etapa de planejamento do projeto",
                    "btn_planning.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Acompanhamento",
                    "Visualize estatísticas, gráficos e atualizações do projeto",
                    "btn_project.png",
                    new Command<string>(NavigateToPage))
             };
        }

        //Variável de Controle de Clique
        private bool _buttonClicked = false;
        
        private async void NavigateToPage(string buttonName)
        {
            bool response = false;

            // Se o botão já foi clicado, sai do método
            if (_buttonClicked)
            {
                return;
            }

            // Marcando o botão como clicado
            _buttonClicked = true;
            
            switch (buttonName)
            {
                case "Solicitação":                    
                    if(response = await CheckStage(Projeto, 1))
                        await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Projeto)));
                    break;
                case "Análise":
                    if(response = await CheckStage(Projeto, 2))
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraBriefing(Projeto)));
                    break;
                case "Squad":
                    if (response = await CheckStage(Projeto, 3))
                        await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSquad(Projeto)));
                    break;
                case "Planejamento":
                    if (response = await CheckStage(Projeto, 4))
                        await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraPlanejamento(Projeto)));
                    break;
                case "Acompanhamento":
                    if (response = await CheckStage(Projeto, 5))
                        await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraAcompanhamento()));
                    break;
                default:
                    break;
            }

            // Após a ação ser concluída, reativa o botão
            _buttonClicked = false;
        }

        private async Task HandleNavigationAsync(Func<Task> navigationAction)
        {
            ActivityIndicatorLocal.IsRunning = true;
            ActivityIndicatorLocal.IsVisible = true;

            try
            {
                await navigationAction();
            }
            finally
            {
                ActivityIndicatorLocal.IsRunning = false;
                ActivityIndicatorLocal.IsVisible = false;
            }
        }

        public async Task<bool> CheckStage(Project project, int stage)
        {
            bool Resposta           = new bool();
            RESTProject RESTProject = new RESTProject();

            int User_Id    = Preferences.Get("AuthUserId", 0); ;
            int Project_Id = project.Id;
            int Stage      = stage;            

            return Resposta = await RESTProject.GetCheckOpenStage(User_Id, Project_Id, Stage);
        }
    }

    public class ButtonModel
    {
        public string   Text { get; set; }
        public string   Description { get; set; }
        public string   ImagePath { get; set; }
        public ICommand Command { get; set; }

        public ButtonModel(string text, string description, string imagePath, ICommand command)
        {
            Text        = text;
            Description = description;
            ImagePath   = imagePath;
            Command     = command;
        }
    }

}

