using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CentralInovacao.ViewModel
{    
    public partial class ViewModelTask : ObservableObject
    {
        [ObservableProperty]
        private bool         _isRefreshing;
        [ObservableProperty]
        private Project      _objProject;
        [ObservableProperty]
        private ProjectTask  _objProjectTask;
        [ObservableProperty]
        private ObservableCollection<ProjectTask> _taskListGeneral;

        public ViewModelTask()
        {
            //Inicializar todas as Task nas suas respectivas listas
        }

        //public void SalvarTarefaBacklog(Oportunidade oportunidade,Tarefa tarefa)
        //{
        //    //Gera o Id da Tarefa 
        //    tarefa.Id = GerarNovoId(tarefa.Id,oportunidade);

        //    oportunidade.ListaDeTarefasBacklog.Add(tarefa);

        //    //Carrega todas as oportunidades do usuário
        //    //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    //if (File.Exists(filePath))
        //    //{
        //    //    string json = File.ReadAllText(filePath);
        //    //   if (json != string.Empty)
        //    //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    //}

        //    // Lógica de adicionar tarefa à oportunidade específica (Usando LINQ)
        //    //Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);
        //    //op.ListaDeTarefas.Add(tarefa);

        //    //Atualiza a lista
        //    //File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        //}

        //public void SalvarTarefaExecucao(Oportunidade oportunidade, Tarefa tarefa)
        //{
        //    //Gera o Id da Tarefa 
        //    tarefa.Id = GerarNovoId(tarefa.Id, oportunidade);

        //    oportunidade.ListaDeTarefasExecucao.Add(tarefa);

        //    //Carrega todas as oportunidades do usuário
        //    //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    //if (File.Exists(filePath))
        //    //{
        //    //    string json = File.ReadAllText(filePath);
        //    //   if (json != string.Empty)
        //    //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    //}

        //    // Lógica de adicionar tarefa à oportunidade específica (Usando LINQ)
        //    //Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);
        //    //op.ListaDeTarefas.Add(tarefa);

        //    //Atualiza a lista
        //    //File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        //}

        //public void SalvarTarefaFinalizadas(Oportunidade oportunidade, Tarefa tarefa)
        //{
        //    //Gera o Id da Tarefa 
        //    tarefa.Id = GerarNovoId(tarefa.Id, oportunidade);

        //    oportunidade.ListaDeTarefasFinalizadas.Add(tarefa);

        //    //Carrega todas as oportunidades do usuário
        //    //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    //if (File.Exists(filePath))
        //    //{
        //    //    string json = File.ReadAllText(filePath);
        //    //   if (json != string.Empty)
        //    //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    //}

        //    // Lógica de adicionar tarefa à oportunidade específica (Usando LINQ)
        //    //Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);
        //    //op.ListaDeTarefas.Add(tarefa);

        //    //Atualiza a lista
        //    //File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        //}

        //public void SalvarItemTarefa(Oportunidade oportunidade, Tarefa tarefa, Tarefa.Item item)
        //{
        //    int index = 0;

        //    foreach(Tarefa element in oportunidade.ListaDeTarefas)
        //    {
        //        if(element.Id == tarefa.Id)
        //        {
        //            //Tarefa encontrada
        //            break; // Sair do loop quando a tarefa for encontrada
        //        }

        //        index++; // Incrementar o índice a cada iteração
        //    }

        //    Tarefa TarefaTemp = oportunidade.ListaDeTarefas[index];

        //    TarefaTemp.ListaDeItems.Add(item);

        //    //Usando LINQ para encontrar Tarefa
        //    //int IndexTarefa = oportunidade.ListaDeTarefas.FindIndex(element => element.Id == tarefa.Id);
            
            
        //    //Adiciona o novo item à tarefa específica
        //    //oportunidade.ListaDeTarefas[IndexTarefa].ListaDeItems.Add(TarefaTemp.ItemNovo);

        //}
        
        //public void ExcluirTarefa(Oportunidade oportunidade, Tarefa tarefa)
        //{

        //    //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    //if (File.Exists(filePath))
        //    //{
        //    //    string json = File.ReadAllText(filePath);
        //    //    if (json != string.Empty)
        //    //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    //}

        //    //Encontrando a oportunidade específica no JSON
        //    //Oportunidade op = ListaDeOportunidades.FirstOrDefault(element => element.Id == oportunidade.Id);

        //    ////Removendo a tarefa da oportunidade no JSON(usando LINQ)
        //    //var tarefaParaRemover = op.ListaDeTarefas.FirstOrDefault(t => t.Id == tarefa.Id);
        //    //if (tarefaParaRemover != null)
        //    //{
        //    //    op.ListaDeTarefas.Remove(tarefaParaRemover);
        //    //}

        //    // Salvando o JSON atualizado no arquivo
        //    //File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));

        //    oportunidade.ListaDeTarefas.Remove(tarefa);
        //}

        //private async void ExecuteRefresh()
        //{
        //    await CarregarTarefasAsync(Oportunidade);
        //    IsRefreshing = false;
        //}

        //public async Task<Oportunidade> CarregarTarefasAsync(Oportunidade oportunidade)
        //{
        //    await Task.Delay(200);
        //    var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    if (File.Exists(filePath))
        //    {
        //        string json = File.ReadAllText(filePath);
        //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    }
        //    int index = 0;

        //    //Procurar oportunidade específica dentro da lista
        //    foreach(Oportunidade element in ListaDeOportunidades)
        //    {
        //        if(element.Id == oportunidade.Id)
        //        {
        //            index  = ListaDeOportunidades.IndexOf(element);
        //        }
        //    }
        //    return ListaDeOportunidades[index];
        //}

        //public Oportunidade CarregarTarefas(Oportunidade oportunidade)
        //{
        //    var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
        //    if (File.Exists(filePath))
        //    {
        //        string json = File.ReadAllText(filePath);
        //        ListaDeOportunidades = JsonConvert.DeserializeObject<List<Oportunidade>>(json);
        //    }
        //    int index = 0;

        //    //Procurar oportunidade específica dentro da lista
        //    foreach (Oportunidade element in ListaDeOportunidades)
        //    {
        //        if (element.Id == oportunidade.Id)
        //        {
        //            index = ListaDeOportunidades.IndexOf(element);
        //        }
        //    }
        //    return ListaDeOportunidades[index];
        //}
    }
}
