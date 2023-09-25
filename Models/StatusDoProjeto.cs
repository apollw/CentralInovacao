using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class StatusDoProjeto:Projeto
    {
        private int               _idDoProjeto;
        private List<Tarefa> _listaDeBacklog;
        private List<Tarefa> _listaEmExecucao;
        private List<Tarefa> _listaFinalizadas;

        public int IdDoProjeto { get => _idDoProjeto; set => _idDoProjeto = value; }
        public List<Tarefa> ListaDeBacklog { get => _listaDeBacklog; set => _listaDeBacklog = value; }
        public List<Tarefa> ListaEmExecucao { get => _listaEmExecucao; set => _listaEmExecucao = value; }
        public List<Tarefa> ListaFinalizadas { get => _listaFinalizadas; set => _listaFinalizadas = value; }
    }
}
