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
        public List<ButtonModel> Buttons { get; set; }
        public Oportunidade Oportunidade { get; set; }

        public ViewModelButton(Oportunidade oportunidade)
        {
            Oportunidade = oportunidade;

            Buttons = new List<ButtonModel>
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
        private async void NavigateToPage(string buttonName)
        {
            switch (buttonName)
            {
                case "Solicitação":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraSolicitacao(Oportunidade));
                    break;
                case "Análise":
                    await Shell.Current.Navigation.PushAsync(new PageEsteiraBriefing(Oportunidade));
                    break;
                case "Squad":
                    await Shell.Current.GoToAsync($"{nameof(PageEsteiraSquad)}");
                    break;
                case "Planejamento":
                    await Shell.Current.GoToAsync($"{nameof(PageEsteiraPlanejamento)}");
                    break;
                case "Acompanhamento":
                    await Shell.Current.GoToAsync($"{nameof(PageEsteiraAcompanhamento)}");
                    break;
                default:
                    break;
            }
        }

    }
    public class ButtonModel
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public ICommand Command { get; set; }

        public ButtonModel(string text, string imagePath, ICommand command)
        {
            Text      = text;
            ImagePath = imagePath;
            Command   = command;
        }
    }

}

