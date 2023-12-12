using Business.Inovacao;
using CentralInovacao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Repositories
{
    public class RESTResources
    {
        private readonly HttpClient _httpClient;

        public RESTResources()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("TokenApi", Preferences.Get("AuthToken", "", ""));
        }

        //Carregar Lista de Áreas
        public async Task<List<ModelArea>> GetListAreas()
        {
            List<ModelArea> ListaAreas = new List<ModelArea>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + "/resources/areas");

                if (response.IsSuccessful)
                {
                    ListaAreas = JsonConvert.DeserializeObject<List<ModelArea>>(response.Content);
                    return ListaAreas;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }
            return ListaAreas;
        }

        //Carregar Lista de Usuários
        public async Task<List<ModelUser>> GetListUsers(string nome)
        {
            List<ModelUser> ListaUsuarios = new List<ModelUser>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/users?username={nome}");

                if (response.IsSuccessful)
                {
                    ListaUsuarios = JsonConvert.DeserializeObject<List<ModelUser>>(response.Content);
                    return ListaUsuarios;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaUsuarios;
        }

        //Carregar Lista de Status
        public async Task<List<ModelGenericLocal>> GetListStatus()
        {
            List<ModelGenericLocal> ListaStatus = new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/status");

                if (response.IsSuccessful)
                {
                    ListaStatus = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaStatus;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaStatus;
        }

        //Carregar Lista de Funções
        public async Task<List<ModelGenericLocal>> GetListFunctions()
        {
            List<ModelGenericLocal> ListaFuncoes = new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/functions");

                if (response.IsSuccessful)
                {
                    ListaFuncoes = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaFuncoes;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaFuncoes;
        }

        //Carregar Lista de Estágios
        public async Task<List<ModelGenericLocal>> GetListStages()
        {
            List<ModelGenericLocal> ListaEstagios = new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/stages");

                if (response.IsSuccessful)
                {
                    ListaEstagios = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaEstagios;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaEstagios;
        }

        //Carregar Lista de Classificações
        public async Task<List<ModelGenericLocal>> GetListClassifications()
        {
            List<ModelGenericLocal> ListaClassificacoes = new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/classifications");

                if (response.IsSuccessful)
                {
                    ListaClassificacoes = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaClassificacoes;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaClassificacoes;
        }

        //Carregar Lista de Tipos de Documento
        public async Task<List<ModelGenericLocal>> GetListDocumentTypes()
        {
            List<ModelGenericLocal> ListaDocumentos= new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/types-document");

                if (response.IsSuccessful)
                {
                    ListaDocumentos = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaDocumentos;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaDocumentos;
        }

        //Carregar Lista de Razões de Declínio
        public async Task<List<ModelGenericLocal>> GetListReasons()
        {
            List<ModelGenericLocal> ListaRazoes = new List<ModelGenericLocal>();

            try
            {
                var response = CommonApi.DoGetWithJson(ModelAuthApi.UrlApi + $"/resources/reasons");

                if (response.IsSuccessful)
                {
                    ListaRazoes = JsonConvert.DeserializeObject<List<ModelGenericLocal>>(response.Content);
                    return ListaRazoes;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
            }

            return ListaRazoes;
        }

    }
}
