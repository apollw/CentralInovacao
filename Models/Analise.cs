using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Analise
    {
        //Dentro da classe Oportunidade encontramos o campo de aspectos positivos da solução

        private Colaborador  _analista;
        private Oportunidade _oportunidade;

        public Colaborador Analista { get => _analista; set => _analista = value; }
        public Oportunidade Oportunidade { get => _oportunidade; set => _oportunidade = value; }

    }
}
