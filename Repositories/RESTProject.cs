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
            
            IRestResponse request = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi+"/projects", body);

            if (!(request.StatusCode == System.Net.HttpStatusCode.OK))
            {
                await Shell.Current.DisplayAlert(" ", $"Erro: {request.Content}", "Retornar");
                return false;
            }
            return true;
        }

        //Editar Projeto
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

            try
            {
                IRestResponse request =
                CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + $"/projects/{project_id}/solicitation?user={user_id}", body);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return false;
        }

        //Classificar Projeto
        public async Task<bool> ClassifyProject(int project_id, int classification_id)
        {
            var projetoJSON = new JObject(new JProperty("Id", classification_id));
            int user_id = Preferences.Get("AuthUserId", 0);

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + 
                $"/projects/{project_id}/classify?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Enviar para Análise
        public async Task<bool> SendToStage(int project_id, int stage)
        {
            int user_id = Preferences.Get("AuthUserId", 0);
            var projetoJSON = new JObject(new JProperty(" ", " "));

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + 
                $"/projects/{project_id}/sendto/{stage}?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
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
            new JProperty("DateIni", ""),
            new JProperty("DateEnd", ""),
            new JProperty("Name",""),
            new JProperty("OnlyMyProjects",true),
            new JProperty("User", Preferences.Get("AuthUserId", 0))
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

        public async Task<bool> GetCheckOpenStage(int user_id, int project_id, int stage)
        {
            var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi +
                           $"/projects/{project_id}/check-open-stage/{stage}?user={user_id}");

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Adicionar Capa do Projeto
        public async Task<bool> AddProjectImage(Project project,string body)
        {
            string _parametros = $"/projects/{project.Id}/add-image?user={project.User}";

            try
            {
                var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + _parametros,body);

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
                return "Ocorreu um erro ao processar a resposta.";
            }
        }
    }
}
