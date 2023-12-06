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

        //Declinar Projeto
    }
}