using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class ModelStatusDoProjeto:ModelProjeto
    {
        private int               _idDoProjeto;
        private List<ModelTarefa> _listaDeBacklog;
        private List<ModelTarefa> _listaEmExecucao;
        private List<ModelTarefa> _listaFinalizadas;

        public int IdDoProjeto { get => _idDoProjeto; set => _idDoProjeto = value; }
        public List<ModelTarefa> ListaDeBacklog { get => _listaDeBacklog; set => _listaDeBacklog = value; }
        public List<ModelTarefa> ListaEmExecucao { get => _listaEmExecucao; set => _listaEmExecucao = value; }
        public List<ModelTarefa> ListaFinalizadas { get => _listaFinalizadas; set => _listaFinalizadas = value; }
    }
}
