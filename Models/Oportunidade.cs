using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Oportunidade
    {
        private int         _id;
        private string      _titulo;
        private string      _status;
        private string      _responsavel;
        private string      _aspectosPositivos;
        private string      _aspectosNegativos;
        private DateTime    _dataRegistro;
        private List<Setor> _setores;

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string AspectosPositivos { get => _aspectosPositivos; set => _aspectosPositivos = value;}
        public string AspectosNegativos { get => _aspectosNegativos; set => _aspectosNegativos = value; }
        public DateTime DataRegistro { get => _dataRegistro; set => _dataRegistro = value; }
        public string Responsavel { get => _responsavel; set => _responsavel = value; }
        public string Status { get => _status; set => _status = value; }
        public List<Setor> Setores { get => _setores; set => _setores = value; }

        public Oportunidade()
        {
            Setores = new List<Setor>
            {
                new Setor { Nome = "Administrativo"           , Selecionado = 0 },
                new Setor { Nome = "Análise de Crédito"       , Selecionado = 0 },
                new Setor { Nome = "Auditoria"                , Selecionado = 0 },
                new Setor { Nome = "Contabilidade"            , Selecionado = 0 },
                new Setor { Nome = "Creli"                    , Selecionado = 0 },
                new Setor { Nome = "Financeiro"               , Selecionado = 0 },
                new Setor { Nome = "Gestão de Pessoas"        , Selecionado = 0 },
                new Setor { Nome = "Infraestrutura Civil"     , Selecionado = 0 },
                new Setor { Nome = "Recebimentos"             , Selecionado = 0 },
                new Setor { Nome = "Renovação Automática"     , Selecionado = 0 },
                new Setor { Nome = "Seguros"                  , Selecionado = 0 },
                new Setor { Nome = "T.I. Inovação"            , Selecionado = 0 },
                new Setor { Nome = "Tecnologia da Informação" , Selecionado = 0 }               
            };
        }

        public class Setor
        {
            public string Nome { get; set; }
            public int    Selecionado { get; set; }
        }
    }
    
}



