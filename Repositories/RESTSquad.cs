using CentralInovacao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CentralInovacao.Repositories
{
    public class RESTSquad
    {
        //Carregar Squad
        public async static Task<List<Squad>> GetSquadProject(int project_id, int user_id)
        {
            List<Squad> ListaDaSquad = new List<Squad>();
            string _parametros = $"/projects/{project_id}/squad?user={user_id}";

            IRestResponse response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + _parametros);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaDaSquad;
            }

            ListaDaSquad = JsonConvert.DeserializeObject<List<Squad>>(response.Content);
            return ListaDaSquad;
        }

        //Adicionar Usuário
        public async static Task<bool> AddUserInSquad(Squad squadUser,int project_id, int user_id)
        {
            var squadUserJSON = new JObject(
            new JProperty("User", squadUser.User),
            new JProperty("Function", squadUser.Function),
            new JProperty("Status", squadUser.Status)
            );

            string _parametros = $"/projects/{project_id}/squad?user={user_id}";

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(squadUserJSON);

            IRestResponse response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + _parametros, body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

        //Atualizar Usuário
        public async static Task<bool> UpdateUserInSquad(int project_id, int user_updated, int user_id, int codigo)
        {
            string _parametros = $"/projects/{project_id}/squad/{user_updated}?user={user_id}";

            var genericJSON = new JObject(
            new JProperty("Id", codigo)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(genericJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + _parametros, body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

        //Deletar Usuário
        public async static Task<bool> DeleteUserInSquad(int project_id, int deleted_user_id, int user_id)
        {
            string _parametros = $"/projects/{project_id}/squad/{deleted_user_id}?user={user_id}";

            var body = "";

            IRestResponse response = CommonApi.DoDeleteWithJson(ModelAuthApi.UrlApi + _parametros, body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }
    }
}
