using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Projeto : Oportunidade
    {
        private int             _id;
        private string          _titulo;
        private StatusDoProjeto _statusDoProjeto;
    }
}
