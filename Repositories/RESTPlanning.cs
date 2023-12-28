using Business.Inovacao;
using CentralInovacao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CentralInovacao.Repositories
{
    public class RESTPlanning
    {
        //Criar Tarefa
        public async static Task<bool> CreateTask(string title, string description, int project_id)
        {
            int    user_id    = Preferences.Get("AuthUserId", 0);
            string parametros = $"/projects/{project_id}/task?user={user_id}";
                
            var projetoJSON = new JObject(
            new JProperty("Title", title),
            new JProperty("Description", description)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + parametros, body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

        //Carregar Lista de Tarefas ----------------------------------- TESTAR/CORRIGIR
        public async static Task<List<ModelProjectTaskGroup>> GetListProjectTasks(Project project)
        {
            List<ModelProjectTaskGroup> ListaTarefasDoProjeto = new List<ModelProjectTaskGroup>();
            int user_id        = Preferences.Get("AuthUserId", 0);
            string parametros  = $"/projects/{project.Id}/tasks?user={user_id}";

            var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + parametros);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaTarefasDoProjeto;
            }

            ListaTarefasDoProjeto = JsonConvert.DeserializeObject<List<ModelProjectTaskGroup>>(response.Content);
            return ListaTarefasDoProjeto;
        }

        //Carregar Detalhes da Tarefa
        
        //Criar Subtarefa

        //Atualizar Status da Subtarefa

        //Deletar Subtarefa
    }
}
