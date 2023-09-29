using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Projeto : Oportunidade
    {
        private string          _titulo;
        private StatusDoProjeto _statusDoProjeto;

        public string Titulo { get => _titulo; set => _titulo = value; }
        public StatusDoProjeto StatusDoProjeto { get => _statusDoProjeto; set => _statusDoProjeto = value; }
    }
}
