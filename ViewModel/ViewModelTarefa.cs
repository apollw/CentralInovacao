using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.ViewModel
{    
    public partial class ViewModelTarefa : ObservableObject
    {
        [ObservableProperty]
        private Tarefa             _tarefa;
        [ObservableProperty]
        private List<Tarefa>       _listaDeTarefas;
        [ObservableProperty]
        private List<Oportunidade> _listaDeOportunidades;

        public ViewModelTarefa()
        {
            Tarefa               = new Tarefa();
            ListaDeTarefas       = new List<Tarefa>();
            ListaDeOportunidades = new List<Oportunidade>();    
        }

        public void NovaTarefa(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
               if (json != string.Empty)
                    ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }

            //Adicionar Novo Item à Oportunidade específica

            Tarefa.Id          = 0;
            Tarefa.DataInicio  = DateTime.Now;
            Tarefa.Titulo      = "NULL";
            Tarefa.Status      = "Em execução";
            Tarefa.Responsavel = "NULL";
            Tarefa.Comentarios = "NULL";
            Tarefa.Descricao   = "NULL";
            
            oportunidade.ListaDeTarefas = new List<Tarefa> { Tarefa };
            //Adiciona tarefa à oportunidade
            oportunidade.ListaDeTarefas.Add(Tarefa);

            //foreach(Oportunidade element in ListaDeOportunidades)
            //{
            //    //atualizar oportunidade
            //    if (element.Id == oportunidade.Id)
            //    {
            //        oportunidade = element; //VAZIO
            //    }
            //}            
            ListaDeOportunidades.Add(oportunidade);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }

        public void NovoItem(int id)
        {
            //Estaremos alterando uma oportunidade específica

            //Se Oportunidade.Id = true
            // Adiciona item à oportunidade
            // Update Lista de Oportunidades

        }

        public List<Tarefa> CarregarTarefas(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }

            foreach(Oportunidade element in ListaDeOportunidades)
            {
                if(element.Id == oportunidade.Id) 
                {
                    ListaDeTarefas = oportunidade.ListaDeTarefas;
                }
            }

            return ListaDeTarefas;
        }
    }
}
