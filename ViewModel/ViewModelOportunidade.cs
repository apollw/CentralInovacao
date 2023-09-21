using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelOportunidade : ObservableObject
    {
        [ObservableProperty]
        private ModelOportunidade _modelOportunidade;
        [ObservableProperty]
        private List<ModelOportunidade> _listaDeOportunidades;
        [ObservableProperty]
        private List<Setor> _setoresDisponiveis;
        [ObservableProperty]
        private ObservableCollection<Setor> _setoresSelecionados;

        public ViewModelOportunidade()
        {
           _modelOportunidade = new ModelOportunidade();
           _listaDeOportunidades = new List<ModelOportunidade>();

           //SetoresDisponiveis = Enum.GetValues(typeof(Setor)).Cast<Setor>().ToList();
           //SetoresSelecionados = new ObservableCollection<Setor>();
        }

        public void SalvarOportunidade(ModelOportunidade modelOportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<ModelOportunidade>>(json);
            }
            ListaDeOportunidades.Add(modelOportunidade);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));

        }
        public List<ModelOportunidade> CarregarOportunidades()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<ModelOportunidade>>(json);
            }
            return ListaDeOportunidades;
        }
    }
}
