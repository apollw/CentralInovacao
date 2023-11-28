using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Repositories
{
    public class RESTSolicitation
    {
        private readonly HttpClient _httpClient;

        public RESTSolicitation()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("TokenApi", Preferences.Get("AuthToken", "", ""));
        }

        //Atualizar Solicitação

        //Classificar Projeto

    }
}
