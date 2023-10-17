using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Services
{
    public class ConnectivityService
    {
        public NetworkAccess GetNetworkAccess()
        {
            return Connectivity.NetworkAccess;
        }
    }
}
