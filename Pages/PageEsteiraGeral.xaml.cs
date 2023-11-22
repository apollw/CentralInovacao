using CentralInovacao.Models;
using CentralInovacao.Pages;
using System.Reflection;
using System.Windows.Input;

namespace CentralInovacao.Pages;

public partial class PageEsteiraGeral : ContentPage
{    
	//public PageEsteiraGeral(Oportunidade oportunidade)
	//{
	//	InitializeComponent();
 //       ViewModelButton VMButton = new ViewModelButton(oportunidade);
 //       VMButton.ActivityIndicatorLocal = activityIndicator;
 //       BindingContext  = VMButton;        
 //   }
    public PageEsteiraGeral(Project project)
    {
        InitializeComponent();
        ViewModelButton VMButton = new ViewModelButton(project);
        VMButton.ActivityIndicatorLocal = activityIndicator;
        BindingContext = VMButton;
    }
    public class ViewModelButton
    {
        //public Oportunidade      Oportunidade { get; set; }
        public Project           Projeto { get; set; }
        public List<ButtonModel> Buttons { get; set; }
        public ActivityIndicator ActivityIndicatorLocal { get; set; }

        //public ViewModelButton(Oportunidade oportunidade)
        //{
        //    Oportunidade = oportunidade;

        //    Buttons = new List<ButtonModel>
        //    {
        //        new ButtonModel(
        //            "Solicita��o",
        //            "Clique para ver mais detalhes sobre a oportunidade registrada",
        //            "btn_request.png",
        //            new Command<string>(NavigateToPage)),
        //        new ButtonModel(
        //            "An�lise",
        //            "Acompanhe o status da An�lise da oportunidade registrada",
        //            "btn_analysis.png",
        //            new Command<string>(NavigateToPage)),
        //        new ButtonModel(
        //            "Squad",
        //            "Visualize os integrantes da Squad respons�vel pelo projeto",
        //            "btn_group.png",
        //            new Command<string>(NavigateToPage)),
        //        new ButtonModel(
        //            "Planejamento",
        //            "Visualize a etapa de planejamento do projeto",
        //            "btn_planning.png",
        //            new Command<string>(NavigateToPage)),
        //        new ButtonModel(
        //            "Acompanhamento",
        //            "Visualize estat�sticas, gr�ficos e atualiza��es do projeto",
        //            "btn_project.png",
        //            new Command<string>(NavigateToPage))
        //     };
        //}

        public ViewModelButton(Project projeto)
        {
            Projeto = projeto;

            Buttons = new List<ButtonModel>
            {
                new ButtonModel(
                    "Solicita��o",
                    "Clique para ver mais detalhes sobre a oportunidade registrada",
                    "btn_request.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "An�lise",
                    "Acompanhe o status da An�lise da oportunidade registrada",
                    "btn_analysis.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Squad",
                    "Visualize os integrantes da Squad respons�vel pelo projeto",
                    "btn_group.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Planejamento",
                    "Visualize a etapa de planejamento do projeto",
                    "btn_planning.png",
                    new Command<string>(NavigateToPage)),
                new ButtonModel(
                    "Acompanhamento",
                    "Visualize estat�sticas, gr�ficos e atualiza��es do projeto",
                    "btn_project.png",
                    new Command<string>(NavigateToPage))
             };
        }

        //Vari�vel de Controle de Clique
        private bool _buttonClicked = false;
        
        private async void NavigateToPage(string buttonName)
        {
            // Se o bot�o j� foi clicado, sai do m�todo
            if (_buttonClicked)
            {
                return;
            }

            // Marcando o bot�o como clicado
            _buttonClicked = true;
            
            switch (buttonName)
            {
                case "Solicita��o":
                    //await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Oportunidade)));
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Projeto)));
                    //await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageNovaOportunidade(Oportunidade)));
                    break;
                case "An�lise":
                    //await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraBriefing(Oportunidade)));
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraBriefing(Projeto)));
                    break;
                case "Squad":
                    //await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSquad(Oportunidade)));
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraSquad(Projeto)));
                    break;
                case "Planejamento":
                    //await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraPlanejamento(Oportunidade)));
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraPlanejamento(Projeto)));
                    break;
                case "Acompanhamento":
                    await HandleNavigationAsync(async () => await Shell.Current.Navigation.PushAsync(new PageEsteiraAcompanhamento()));
                    break;
                default:
                    break;
            }

            // Ap�s a a��o ser conclu�da, reativa o bot�o
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

