using CentralInovacao.Models;
using CentralInovacao.Pages;
using System.Windows.Input;

namespace CentralInovacao.Pages;

public partial class PageEsteiraGeral : ContentPage
{
	public PageEsteiraGeral(Oportunidade oportunidade)
	{
		InitializeComponent();
        BindingContext = new ViewModelButton(oportunidade);
    }
    public class ViewModelButton
    {
        public Oportunidade      Oportunidade { get; set; }
        public List<ButtonModel> Buttons { get; set; }

        public ViewModelButton(Oportunidade oportunidade)
        {
            Oportunidade = oportunidade;
            Buttons      = new List<ButtonModel>
            {
                new ButtonModel("Solicita��o"    , "imgbutton_request.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("An�lise"        , "imgbutton_analysis.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Squad"          , "imgbutton_group.png",
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Planejamento"   , "imgbutton_planning.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Acompanhamento" , "imgbutton_project.png", 
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
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Oportunidade));
                    break;
                case "An�lise":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraBriefing(Oportunidade));
                    break;
                case "Squad":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraSquad(Oportunidade));
                    break;
                case "Planejamento":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraPlanejamento(Oportunidade));
                    break;
                case "Acompanhamento":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraAcompanhamento());
                    break;
                default:
                    break;
            }

            // Ap�s a a��o ser conclu�da, reativa o bot�o
            _buttonClicked = false;
        }
    }
    public class ButtonModel
    {
        public string   Text { get; set; }
        public string   ImagePath { get; set; }
        public ICommand Command { get; set; }

        public ButtonModel(string text, string imagePath, ICommand command)
        {
            Text      = text;
            ImagePath = imagePath;
            Command   = command;
        }
    }

}

