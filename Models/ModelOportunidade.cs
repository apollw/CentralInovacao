using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public enum Setor
    {
        Administrativo         = 1,
        AnaliseDeCredito       = 2,
        Auditoria              = 3,
        Contabilidade          = 4,
        Creli                  = 5,
        Financeiro             = 6,
        GestaoDePessoas        = 7,
        InfraestruturaCivil    = 8,
        Inovacao               = 9,
        Recebimentos           = 10,
        RenovacaoAutomatica    = 11,
        Seguros                = 12,
        TecnologiaDaInformacao = 13
    }

    public class ModelOportunidade
    {
        private int     _id;
        private string  _tituloDaSolucao;
        private string  _aspectosPositivos;
        private string  _aspectosNegativos;
        private Setor[] _setores;

        public int Id { get => _id; set => _id = value; }
        public string TituloDaSolucao { get => _tituloDaSolucao; set => _tituloDaSolucao = value; }
        public string AspectosPositivos { get => _aspectosPositivos; set => _aspectosPositivos = value; }
        public string AspectosNegativos { get => _aspectosNegativos; set => _aspectosNegativos = value; }
        public Setor[] Setores { get => _setores; set => _setores = value; }
    }
}



