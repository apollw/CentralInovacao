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

        //Carregar Projeto Específico do Usuário
        public async Task<Project> GetProject(int project_id,int user_id)
        {
            Project Projeto = new Project();
            string _parametros = $"/projects/{project_id}?user={user_id}";

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + _parametros);

                if (response.IsSuccessful)
                {
                    Projeto = JsonConvert.DeserializeObject<Project>(response.Content);
                    return Projeto;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return Projeto;
        }

        //Carregar Lista Geral de Projetos
        public async Task<List<Project>> GetListProjects()
        {
            List<Project> ListaProjetos = new List<Project>();

            var projetoJSON = new JObject(
            new JProperty("Name", ""),
            new JProperty("OnlyMyProjects", false)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            try
            {
                var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", body);

                if (response.IsSuccessful)
                {
                    ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
                    return ListaProjetos;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaProjetos;
        }

        //Carregar Lista de Projetos Geral por Filtro de Data
        public async Task<List<Project>> GetListProjects(string filtro)
        {
            List<Project> ListaProjetos = new List<Project>();

            try
            {
                var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", filtro);

                if (response.IsSuccessful)
                {
                    ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
                    return ListaProjetos;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaProjetos;
        }

        //Carregar Lista de Projetos do Usuário
        public async Task<List<Project>> GetListProjectsUser()
        {
            List<Project> ListaProjetos = new List<Project>();

            var projetoJSON = new JObject(
            new JProperty("DateIni", "2023-10-01"),
            new JProperty("DateEnd", "2023-11-30"),
            new JProperty("Name",""),
            new JProperty("OnlyMyProjects",true),
            new JProperty("User",3068)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            try
            {
                var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list",body);

                if (response.IsSuccessful)
                {
                    ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
                    return ListaProjetos;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaProjetos;
        }

        //Carregar Lista de Projetos do Usuário por Filtro de Data
        public async Task<List<Project>> GetListProjectsUser(string filtro)
        {
            List<Project> ListaProjetos = new List<Project>();
            
            try
            {
                var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", filtro);

                if (response.IsSuccessful)
                {
                    ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
                    return ListaProjetos;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaProjetos;
        }

        //Checa o Estágio Atual do Projeto
        public async Task<bool> GetCheckOpenStage(int user_id, int project_id, int stage)
        {
            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + 
                    $"/projects/{project_id}/check-open-stage/{stage}?user={user_id}");

                if (response.IsSuccessful)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
        }

    }
}
