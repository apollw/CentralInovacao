using Business.Inovacao;
using CentralInovacao.Models;
using Newtonsoft.Json;

namespace CentralInovacao.Repositories
{
    public class RESTResources
    {
        //Carregar Lista de Áreas
        public async static Task<List<ModelArea>> GetListAreas()
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
        public async static Task<List<ModelUser>> GetListUsers(string nome)
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
        public async static Task<List<ModelGenericLocal>> GetListStatus()
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
        public async static Task<List<ModelGenericLocal>> GetListFunctions()
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
        public async static Task<List<ModelGenericLocal>> GetListStages()
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
        public async static Task<List<ModelGenericLocal>> GetListClassifications()
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
        public async static Task<List<ModelGenericLocal>> GetListDocumentTypes()
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
        public async static Task<List<ModelGenericLocal>> GetListReasons()
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
