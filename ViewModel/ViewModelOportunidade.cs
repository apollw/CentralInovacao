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
        public ViewModelOportunidade()
        {
           _modelOportunidade = new ModelOportunidade();
        }

        public void SalvarOportunidade(ModelOportunidade modelOportunidade)
        {
            //ModelOportunidade com "M" maiúsculo já é a propriedade gerada
            //em ObservableProperty
            ModelOportunidade = modelOportunidade;

            //Salvar alterações no JSON Local
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidade.json");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ModelOportunidade));

        }
        public ModelOportunidade CarregarOportunidade()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidade.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ModelOportunidade = JsonConvert.DeserializeObject<ModelOportunidade>(json);
            }

            return ModelOportunidade;
        }
    }
}
