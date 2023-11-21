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
        private bool _isRefreshing;
        [ObservableProperty]
        private Oportunidade _oportunidade;
        [ObservableProperty]
        private ObservableCollection<Oportunidade> _listaDeOportunidades;

        //Comandos
        public ICommand RefreshCommand => new Command(ExecuteRefresh);
        public ViewModelOportunidade()
        {
            //Oportunidade         = new Oportunidade();
            //ListaDeOportunidades = CarregarOportunidadesLocal();
        }
        public ViewModelOportunidade(Oportunidade oportunidade)
        {
            //Oportunidade         = oportunidade;
            //ListaDeOportunidades = new ObservableCollection<Oportunidade>();
        }
        private async void ExecuteRefresh()
        {
            await CarregarOportunidadesAsyncLocal();
            //IsRefreshing = false;
        }
        public int GerarNovoId(int id)
        {
            if (id != 0)
            {
                return id; // Retorna a ID existente da Oportunidade
            }
            else
            {
                if (ListaDeOportunidades.Count == 0)
                {
                    return 1; // Se a lista está vazia, retorna 1 como o novo ID
                }
                else
                {
                    int ultimoIdUtilizado = ListaDeOportunidades.Max(oportunidade => oportunidade.Id);
                    int novoId = ultimoIdUtilizado + 1;
                    return novoId;
                }
            }
        }
        public void SalvarOportunidadeLocal(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (json != string.Empty)
                    ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            }

            ListaDeOportunidades.Add(oportunidade);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }

        public ObservableCollection<Oportunidade> CarregarOportunidadesLocal()
        {
            ListaDeOportunidades = new ObservableCollection<Oportunidade>();
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            }
            return ListaDeOportunidades;
        }

        public async Task<ObservableCollection<Oportunidade>> CarregarOportunidadesAsyncLocal()
        {
            await Task.Delay(500);

            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            }
            return ListaDeOportunidades;
        }
    }
}
