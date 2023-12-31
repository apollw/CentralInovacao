﻿using CentralInovacao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CentralInovacao.Repositories
{
    public class RESTProject
    {   
        //Criar Projeto
        public async static Task<bool> CreateProject(Project project)
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
            
            IRestResponse response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi+"/projects", body);
         
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;

        }

        //Editar Projeto
        public async static Task<bool> EditProject(Project project, int project_id, int user_id)
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
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Classificar Projeto
        public async static Task<bool> ClassifyProject(int project_id, int classification_id)
        {
            var projetoJSON = new JObject(new JProperty("Id", classification_id));
            int user_id = Preferences.Get("AuthUserId", 0);

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + 
                $"/projects/{project_id}/classify?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Enviar para Análise
        public async static Task<bool> SendToStage(int project_id, int stage)
        {
            int user_id = Preferences.Get("AuthUserId", 0);
            var projetoJSON = new JObject(new JProperty(" ", " "));

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            IRestResponse response = CommonApi.DoPutWithJson(ModelAuthApi.UrlApi + 
                $"/projects/{project_id}/sendto/{stage}?user={user_id}", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Carregar Projeto Específico do Usuário
        public async static Task<Project> GetProject(int project_id,int user_id)
        {
            Project Projeto = new Project();
            string _parametros = $"/projects/{project_id}?user={user_id}";

            IRestResponse response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + _parametros);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return Projeto;
            }

            Projeto = JsonConvert.DeserializeObject<Project>(response.Content);
            return Projeto;
            
        }

        //Carregar Lista Geral de Projetos
        public async static Task<List<Project>> GetListProjects()
        {
            List<Project> ListaProjetos = new List<Project>();

            var projetoJSON = new JObject(
            new JProperty("Name", ""),
            new JProperty("OnlyMyProjects", false)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);
            
            var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaProjetos;
            }
            
            ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
            return ListaProjetos;
        }

        //Carregar Lista de Projetos Geral por Filtro de Data
        public async static Task<List<Project>> GetListProjects(string filtro)
        {
            List<Project> ListaProjetos = new List<Project>();

            var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", filtro);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaProjetos;
            }

            ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
            return ListaProjetos;
        }

        //Carregar Lista de Projetos do Usuário
        public async static Task<List<Project>> GetListProjectsUser()
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

            var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", body);

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaProjetos;
            }

            ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
            return ListaProjetos;           
        }

        //Carregar Lista de Projetos do Usuário por Filtro de Data
        public async static Task<List<Project>> GetListProjectsUser(string filtro)
        {
            List<Project> ListaProjetos = new List<Project>();
            
            var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + "/projects/list", filtro);
            
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);
                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");
                return ListaProjetos;
            }
            
            ListaProjetos = JsonConvert.DeserializeObject<List<Project>>(response.Content);
            return ListaProjetos;
        }

        //Verificar Estágio do Projeto
        public async static Task<bool> GetCheckOpenStage(int user_id, int project_id, int stage)
        {
            var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi +
                           $"/projects/{project_id}/check-open-stage/{stage}?user={user_id}");

            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            return true;
        }

        //Adicionar Capa do Projeto
        public async static Task<bool> AddProjectImage(Project project,string body)
        {
            string _parametros = $"/projects/{project.Id}/add-image?user={project.User}";
            
            var response = CommonApi.DoPostWithJson(ModelAuthApi.UrlApi + _parametros,body);
            
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                string errorMessage = Utilities.FormatErrorMessage(response.Content);

                await Shell.Current.DisplayAlert("Erro", errorMessage, "Retornar");

                return false;
            }
            await Shell.Current.DisplayAlert("Aviso", "Capa do Projeto alterada com Sucesso!", "Fechar");
            return true;
        }
    }
}
