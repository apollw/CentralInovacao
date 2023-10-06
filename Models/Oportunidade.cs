using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Oportunidade
    {
        private int                     _id;
        private string                  _titulo;
        private string                  _status;
        private string                  _responsavel;
        private string                  _aspectosPositivos;
        private string                  _aspectosNegativos;
        private DateTime                _dataRegistro;
        private Dictionary<string, int> _setores;
        private List<Colaborador>       _squad;
        private List<Tarefa>            _listaDeTarefas;

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string AspectosPositivos { get => _aspectosPositivos; set => _aspectosPositivos = value;}
        public string AspectosNegativos { get => _aspectosNegativos; set => _aspectosNegativos = value; }
        public DateTime DataRegistro { get => _dataRegistro; set => _dataRegistro = value; }
        public string Responsavel { get => _responsavel; set => _responsavel = value; }
        public string Status { get => _status; set => _status = value; }
        public Dictionary<string, int> Setores { get => _setores; set => _setores = value; }
        public List<Colaborador> Squad { get => _squad; set => _squad = value; }
        public List<Tarefa> ListaDeTarefas { get => _listaDeTarefas; set => _listaDeTarefas = value; }

        public Oportunidade()
        {
            Setores = new Dictionary<string, int>
            {
                { "Administrativo", 0 },
                { "Análise de Crédito", 0 },
                { "Auditoria", 0 },
                { "Contabilidade", 0 },
                { "Creli", 0 },
                { "Financeiro", 0 },
                { "Gestão de Pessoas", 0 },
                { "Infraestrutura Civil", 0 },
                { "Recebimentos", 0 },
                { "Renovação Automática", 0 },
                { "Seguros", 0 },
                { "T.I. Inovação", 0 },
                { "Tecnologia da Informação", 0 }
            };
        }
        public class Setor
        {
            public string Nome { get; set; }
            public int    Selecionado { get; set; }
        }
    }
    
}



