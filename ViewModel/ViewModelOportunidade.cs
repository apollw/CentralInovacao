using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelOportunidade : ObservableObject
    {
        [ObservableProperty]
        private Oportunidade       _oportunidade;
        [ObservableProperty]
        private List<Oportunidade> _listaDeOportunidades;
        [ObservableProperty]
        private bool               _isRefreshing;

        /*------------------------DECLARAÇÃO DE COMANDOS-----------------------*/
        public ICommand RefreshCommand => new Command(ExecuteRefresh);

        public ViewModelOportunidade()
        {
            Oportunidade         = new Oportunidade();
            ListaDeOportunidades = new List<Oportunidade>();            
        }
        private async void ExecuteRefresh()
        {
            await CarregarOportunidadesAsync();
            IsRefreshing = false;
        }

        public void SalvarOportunidade(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (json != string.Empty)
                    ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
                              
            }
            if (ListaDeOportunidades == null)
                ListaDeOportunidades = new List<Oportunidade>();

            ListaDeOportunidades.Add(oportunidade);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));

        }
        public List<Oportunidade> CarregarOportunidades()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);                
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }            
            return ListaDeOportunidades;
        }

        public async Task<List<Oportunidade>> CarregarOportunidadesAsync()
        {
            await Task.Delay(500);
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }            
            return ListaDeOportunidades;
        }
    }
}
