using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.MiddlewareApi
{
    public class ModelAuthToken
    {
        private string _empresa  = "";
        private string _tokenApi = "";

        public string Empresa { get => _empresa; set => _empresa = value; }
        public string TokenApi { get => _tokenApi; set => _tokenApi = value; }
    }
}
