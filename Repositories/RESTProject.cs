using Business.Inovacao;
using CentralInovacao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Repositories
{
    public class RESTProject
    {
        private readonly HttpClient _httpClient;
        public RESTProject()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("TokenApi", Preferences.Get("AuthToken", "", ""));
        }

        //Criar Projeto
        public async Task<bool> CreateProject(Project project)
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

            try
            {
                IRestResponse request = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi+"/projects", body);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
        }
        //Carregar Lista de Áreas ---ALTERAR PARA USAR COMMON API
        public async Task<List<ModelArea>> GetListAreas()
        {
            List<ModelArea> ListaAreas = new List<ModelArea>();            

            try
            {
                var request = await _httpClient.GetAsync(ModelAuthApi.UrlApi+"/resources/areas");
                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();
                    ListaAreas = JsonConvert.DeserializeObject<List<ModelArea>>(response);
                    return ListaAreas;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaAreas;
        }
    }
}
