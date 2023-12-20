using CentralInovacao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Repositories
{
    public class RESTSquad
    {
        //Carregar Squad
        public async Task<List<Squad>> GetSquadProject(int project_id, int user_id)
        {
            List<Squad> ListaDaSquad = new List<Squad>();
            string _parametros = $"/projects/{project_id}/squad?user={user_id}";

            IRestResponse response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + _parametros);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaDaSquad;
            }

            ListaDaSquad = JsonConvert.DeserializeObject<List<Squad>>(response.Content);
            return ListaDaSquad;
        }

        //Adicionar Usuário
        public async Task<bool> AddUserInSquad(Squad squadUser,int project_id, int user_id)
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
                string errorMessage = FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Atualizar Usuário -----PENDENTE
        public async Task<bool> EditProject(Project project, int project_id, int user_id)
        {
            var projetoJSON = new JObject(
            new JProperty("User", project.User),
            new JProperty("Name", project.Name),
            new JProperty("DescriptionPositive", project.DescriptionPositive),
            new JProperty("DescriptionNegative", project.DescriptionNegative),
            new JProperty("ListArea",
                new JArray(
                    project.ListArea.Select(area =>
                        new JObject(
                            new JProperty("Id", area.Id),
                            new JProperty("Name", area.Name)
                        )
                    )
                )
            )
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi +
                $"/projects/{project_id}/solicitation?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Deletar Usuário -------PENDENTE

        //Formatar Mensagem de Erro
        private string FormatErrorMessage(string rawErrorMessage)
        {
            try
            {
                // Encontra a posição do início da mensagem JSON
                int startIndex = rawErrorMessage.IndexOf("{\"Message\":\"");

                // Se encontrar o início da mensagem JSON, extrai apenas a mensagem
                if (startIndex >= 0)
                {
                    // Remove a parte inicial indesejada
                    rawErrorMessage = rawErrorMessage.Substring(startIndex + "{\"Message\":\"".Length);

                    // Encontra o final da mensagem JSON
                    int endIndex = rawErrorMessage.IndexOf("\"}");

                    // Se encontrar o final da mensagem JSON, extrai apenas a mensagem
                    if (endIndex >= 0)
                    {
                        rawErrorMessage = rawErrorMessage.Substring(0, endIndex);
                    }
                }

                return rawErrorMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
