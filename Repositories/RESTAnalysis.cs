using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralInovacao.Models;

namespace CentralInovacao.Repositories
{
    public class RESTAnalysis
    {
        //Atualizar Análise
        public async Task<bool> UpdateAnalysis(int project_id, string descricao)
        {
            var projetoJSON = new JObject(
                new JProperty("DescriptionAnalyst", descricao)
            );
            
            int user_id = Preferences.Get("AuthUserId", 0);

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);
            
            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi +
                                    $"/projects/{project_id}/analysis?user={user_id}",body);
            
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

        //Ativar Projeto
        public async Task<bool> ActivateProject(int project_id)
        {
            var projetoJSON = new JObject(
                new JProperty(" ", " ")
            );

            int user_id = Preferences.Get("AuthUserId", 0);

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi +
                    $"/projects/{project_id}/active?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

        //Declinar Projeto
        public async Task<bool> DeclineProject(int project_id, int decline_reason)
        {
            var projetoJSON = new JObject(
                new JProperty(" ", " ")
            );

            int user_id = Preferences.Get("AuthUserId", 0);
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoDeleteWithJson(ModelAuthApi.UrlApi +
                    $"/projects/{project_id}/{decline_reason}/decline?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return false;
            }
            return true;
        }

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