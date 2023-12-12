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

            try
            {
                IRestResponse request =
                CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + $"/projects/{project_id}/analysis?user={user_id}",body);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
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

            try
            {
                IRestResponse request =
                CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + $"/projects/{project_id}/active?user={user_id}",body);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
        }

        //Declinar Projeto
        public async Task<bool> DeclineProject(int project_id, int decline_reason)
        {
            var projetoJSON = new JObject(
                new JProperty(" ", " ")
            );

            int user_id = Preferences.Get("AuthUserId", 0);

            //{{url}}/projects/{{project}}/1/decline?user={{user}}

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            try
            {
                IRestResponse request =
                CommonApi.DoDeleteWithJson(ModelAuthApi.UrlApi + $"/projects/{project_id}/{decline_reason}/decline?user={user_id}", body);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
        }
    }
}