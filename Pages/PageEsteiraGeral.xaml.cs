using CentralInovacao.Pages;
using System.Windows.Input;

namespace CentralInovacao.Pages;

public partial class PageEsteiraGeral : ContentPage
{
	public PageEsteiraGeral()
	{
		InitializeComponent();
        BindingContext = new ButtonViewModel();



    }
    public class ButtonViewModel
    {
        public List<string> Buttons { get; set; }

        public ButtonViewModel()
        {
            Buttons = new List<string> { "Button 1", "Button 2", "Button 3", "Button 4", "Button 5" };
        }
    }



}

