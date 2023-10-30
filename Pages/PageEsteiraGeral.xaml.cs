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
                new ButtonModel("Solicitação"    , "imgbutton_request.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Análise"        , "imgbutton_analysis.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Squad"          , "imgbutton_group.png",
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Planejamento"   , "imgbutton_planning.png", 
                                new Command<string>(NavigateToPage)),
                new ButtonModel("Acompanhamento" , "imgbutton_project.png", 
                                new Command<string>(NavigateToPage))
             };
        }

        //Variável de Controle de Clique
        private bool _buttonClicked = false;
        private async void NavigateToPage(string buttonName)
        {
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
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Oportunidade));
                    break;
                case "Análise":
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

            // Após a ação ser concluída, reativa o botão
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

