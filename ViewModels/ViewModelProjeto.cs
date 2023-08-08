using CentralInovacao.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CentralInovacao.ViewModels
{
    public class ViewModelProjeto:INotifyPropertyChanged
    {
        public ObservableCollection<CarouselProjeto> CarouselItems { get; set; }
        public ICommand ButtonClickedCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelProjeto()
        {
            CarouselItems = new ObservableCollection<CarouselProjeto>
            {
            new CarouselProjeto { Source = "imgbutton_request",  Text = "Solicitação" },
            new CarouselProjeto { Source = "imgbutton_analysis", Text = "Análise e Briefing" },
            new CarouselProjeto { Source = "imgbutton_group",    Text = "Definição de Squad" },
            new CarouselProjeto { Source = "imgbutton_planning", Text = "Planejamento" },
            new CarouselProjeto { Source = "imgbutton_project",  Text = "Acompanhamento" }
            };

            ButtonClickedCommand = new Command<string>(OnButtonClicked);

        }
        private async void OnButtonClicked(string source)
        {
            // Aqui você pode lidar com o evento do botão com base no source
            await Application.Current.MainPage.DisplayAlert("oi", "oi", "oi");
        }
    } 
}
