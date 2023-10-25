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

        /*Comandos*/
        public ICommand RefreshCommand => new Command(ExecuteRefresh);

        public ViewModelTarefa()
        {
            Tarefa              = new Tarefa();
            Oportunidade        = new Oportunidade();
            ListaDeTarefas      = new List<Tarefa>();
        }

        public ViewModelTarefa(Oportunidade oportunidade)
        {
            Tarefa              = new Tarefa();
            Oportunidade        = oportunidade;
            ListaDeTarefas      = new List<Tarefa>();
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
            //Usando LINQ para encontrar Tarefa
            int index = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);

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

            ////Lógica de adicionar tarefa à oportunidade específica
            //foreach(Oportunidade element in ListaDeOportunidades)
            //{
            //    List<Oportunidade> ListaTemp = ListaDeOportunidades;

            //    if(element.Id == oportunidade.Id)
            //    {
            //        ListaTemp[ListaDeOportunidades.IndexOf(element)].ListaDeTarefas.Add(tarefa);
            //        ListaDeOportunidades=ListaTemp;
            //        break;
            //    }
            //}

            // Lógica de adicionar tarefa à oportunidade específica (Usando LINQ)
            Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);
            op.ListaDeTarefas.Add(tarefa);            

            //Atualiza a lista
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }

        public void SalvarItemTarefa(Oportunidade oportunidade, Tarefa tarefa)
        {
            //Usando LINQ para encontrar Tarefa
            int IndexTarefa = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);
            Tarefa TarefaTemp  = tarefa;
            
            //Adiciona o novo item à tarefa específica
            oportunidade.ListaDeTarefas[IndexTarefa].ListaDeItems.Add(TarefaTemp.ItemNovo);

        }
        //public void ExcluirTarefa(Oportunidade oportunidade, Tarefa tarefa)
        //{
        //    //Usando LINQ para encontrar Tarefa a ser excluída
        //    int IndexTarefa = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);

        //    //Excluir Tarefa específica
        //    oportunidade.ListaDeTarefas.RemoveAt(IndexTarefa);

        //    var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    if (File.Exists(filePath))
        //    {
        //        string json = File.ReadAllText(filePath);
        //        if (json != string.Empty)
        //            ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    }

        //    // Lógica de adicionar tarefa à oportunidade específica (Usando LINQ)
        //    Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);
        //    op.ListaDeTarefas.Add(tarefa);


        //    File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));

        //}

        public void ExcluirTarefa(Oportunidade oportunidade, Tarefa tarefa)
        {
            // Usando LINQ para encontrar Tarefa a ser excluída
            //int IndexTarefa = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);

            // Excluir Tarefa específica da oportunidade
            //oportunidade.ListaDeTarefas.RemoveAt(IndexTarefa);

            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (json != string.Empty)
                    ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }

            //Encontrando a oportunidade específica no JSON
            Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);

            //Removendo a tarefa da oportunidade no JSON(usando LINQ)
            var tarefaParaRemover = op.ListaDeTarefas.FirstOrDefault(t => t.Id == tarefa.Id);
            if (tarefaParaRemover != null)
            {
                op.ListaDeTarefas.Remove(tarefaParaRemover);
            }

            //int IndexTarefa = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);
            // Excluir Tarefa específica da oportunidade
            //oportunidade.ListaDeTarefas.RemoveAt(IndexTarefa);

            // Salvando o JSON atualizado no arquivo
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }


        private async void ExecuteRefresh()
        {
            await CarregarTarefasAsync(Oportunidade);
            IsRefreshing = false;
        }

        public async Task<Oportunidade> CarregarTarefasAsync(Oportunidade oportunidade)
        {
            await Task.Delay(200);
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }
            int index = 0;

            //Procurar oportunidade específica dentro da lista
            foreach(Oportunidade element in ListaDeOportunidades)
            {
                if(element.Id == oportunidade.Id)
                {
                    index  = ListaDeOportunidades.IndexOf(element);
                }
            }
            return ListaDeOportunidades[index];                     
            
        }

        public Oportunidade CarregarTarefas(Oportunidade oportunidade)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
            }
            int index = 0;

            //Procurar oportunidade específica dentro da lista
            foreach (Oportunidade element in ListaDeOportunidades)
            {
                if (element.Id == oportunidade.Id)
                {
                    index = ListaDeOportunidades.IndexOf(element);
                }
            }
            return ListaDeOportunidades[index];
        }
    }
}
