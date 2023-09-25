using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    [Table ("Oportunidades")]
    public class Oportunidade
    {
        private int    _id;
        private string _tituloDaSolucao;
        private string _aspectosPositivos;
        private string _aspectosNegativos;

        [PrimaryKey, AutoIncrement]
        public int Id { get => _id; set => _id = value; }
        [MaxLength(50)]
        public string TituloDaSolucao { get => _tituloDaSolucao; set => _tituloDaSolucao = value; }
        [MaxLength(50)]
        public string AspectosPositivos { get => _aspectosPositivos; set => _aspectosPositivos = value;}
        [MaxLength(50)]
        public string AspectosNegativos { get => _aspectosNegativos; set => _aspectosNegativos = value; }
    }
    
}



