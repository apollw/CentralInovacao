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

        public void SalvarTarefa(Oportunidade oportunidade,Tarefa tarefa)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
               if (json != string.Empty)
                    ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }

            //Lógica de adicionar tarefa à oportunidade específica
            foreach(Oportunidade element in ListaDeOportunidades)
            {
                List<Oportunidade> ListaTemp = ListaDeOportunidades;

                if(element.Id == oportunidade.Id)
                {
                    ListaTemp[ListaDeOportunidades.IndexOf(element)].ListaDeTarefas.Add(tarefa);
                    ListaDeOportunidades=ListaTemp;
                    break;
                }
            }

            //Atualiza a lista
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }

        public void SalvarTarefaItem(Oportunidade oportunidade, List<Oportunidade> listaDeOportunidades)
        {
            List<Tarefa> ListaTempTarefa = oportunidade.ListaDeTarefas;
            
            Tarefa TarefaTemp = new Tarefa();

            TarefaTemp.ItemNovo.Nome = "Item 1";
            TarefaTemp.ItemNovo.Data = DateTime.Now;

            //Como cada tarefa tem sua própria Id, através dessa Id pode-se adicionar um item à
            //lista de itens dessa tarefa

            //Adiciona o novo item à tarefa específica
            ListaTempTarefa[0].ListaDeItems.Add(TarefaTemp.ItemNovo);

            //Atualiza a Lista de Tarefas da Oportunidade Específica
            oportunidade.ListaDeTarefas = ListaTempTarefa;

            //Atualiza a Lista de Oportunidades do Usuário
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");

            //Lógica de atualizar oportunidade específica da lista de oportunidades do usuário
            foreach (Oportunidade element in listaDeOportunidades)
            {
                if (element.Id == oportunidade.Id)
                {
                    List<Oportunidade> ListaTemp = listaDeOportunidades;

                    //Sobreescrever a oportunidade específica
                    ListaTemp[listaDeOportunidades.IndexOf(element)] = oportunidade;

                    listaDeOportunidades = ListaTemp;

                    break;
                }
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(listaDeOportunidades));

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
                    //ListaDeTarefas = oportunidade.ListaDeTarefas;
                }
            }

            return ListaDeTarefas;
        }
    }
}
