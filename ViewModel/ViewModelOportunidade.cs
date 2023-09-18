using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

    }
}
