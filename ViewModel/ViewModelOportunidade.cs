using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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
        private Oportunidade _oportunidade;
        [ObservableProperty]
        private List<Oportunidade> _listaDeOportunidades;

        public ViewModelOportunidade()
        {
            _oportunidade         = new Oportunidade();
            _listaDeOportunidades = new List<Oportunidade>();            
        }

        public void SalvarOportunidade(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }
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
    }
}
