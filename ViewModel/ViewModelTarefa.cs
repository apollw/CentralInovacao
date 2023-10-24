using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CentralInovacao.ViewModel
{    
    public partial class ViewModelTarefa : ObservableObject
    {
        [ObservableProperty]
        private Tarefa             _tarefa;
        [ObservableProperty]
        private Oportunidade       _oportunidade;
        [ObservableProperty]
        private List<Tarefa>       _listaDeTarefas;
        [ObservableProperty]
        private List<Oportunidade> _listaDeOportunidades;
        [ObservableProperty]
        private bool               _isRefreshing;

        public ViewModelTarefa()
        {
            Tarefa               = new Tarefa();
            Oportunidade         = new Oportunidade();
            ListaDeTarefas       = new List<Tarefa>();
        }

        public int GerarNovoId(int id,Oportunidade oportunidade)
        {
            if (id != 0)
            {
                return id; // Retorna a ID existente da Tarefa
            }
            else
            {
                if (oportunidade.ListaDeTarefas.Count == 0)
                {
                    return 1; // Se a lista está vazia, retorna 1 como o novo ID
                }
                else
                {
                    int ultimoIdUtilizado = oportunidade.ListaDeTarefas.Max(tarefa => tarefa.Id);
                    int novoId = ultimoIdUtilizado + 1;
                    return novoId;
                }
            }
        }

        public int GerarNovoIdItem(int id, Oportunidade oportunidade, Tarefa tarefa)
        {
            int index = 0;

            //Pesquisando tarefa específica
            foreach (Tarefa element in oportunidade.ListaDeTarefas)
            {
                //Encontrou a tarefa específica dessa oportunidade
                if (element.Id == tarefa.Id)
                {
                    index = oportunidade.ListaDeTarefas.IndexOf(element);
                }
            }

            //Achou o Index da Tarefa procurada dentro da lista
            if (oportunidade.ListaDeTarefas[index].ListaDeItems.Count == 0)
            {
                return 1; // Se a lista está vazia, retorna 1 como o novo ID
            }
            else
            {
                int ultimoIdUtilizado = oportunidade.ListaDeTarefas[index].ListaDeItems.Max(item => item.id);
                int novoId = ultimoIdUtilizado + 1;
                return novoId;
            }
        }

        public void SalvarTarefa(Oportunidade oportunidade,Tarefa tarefa)
        {
            //Gera o Id da Tarefa 
            tarefa.Id = GerarNovoId(tarefa.Id,oportunidade);

            //Carrega todas as oportunidades do usuário
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

        public void SalvarItemTarefa(Oportunidade oportunidade, Tarefa tarefa)
        {
            //Verificar index correto da tarefa, pois aqui está errado
            int    IndexTarefa = tarefa.Id;
            Tarefa TarefaTemp  = tarefa;

            //Adiciona o novo item à tarefa específica
            oportunidade.ListaDeTarefas[IndexTarefa].ListaDeItems.Add(TarefaTemp.ItemNovo);

        } 
    }
}
