using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Oportunidade
    {
        private int    _id;
        private string _tituloDaSolucao;
        private string _aspectosPositivos;
        private string _aspectosNegativos;

        public int Id { get => _id; set => _id = value; }
        public string TituloDaSolucao { get => _tituloDaSolucao; set => _tituloDaSolucao = value; }
        public string AspectosPositivos { get => _aspectosPositivos; set => _aspectosPositivos = value;}
        public string AspectosNegativos { get => _aspectosNegativos; set => _aspectosNegativos = value; }
    }
    
}



