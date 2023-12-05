using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Usuario
    {
        private int                 _id;
        private string              _nome;

        private int                _posicaoNoRanking;
        private List<Oportunidade> _listaDeOportunidades;        

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public int PosicaoNoRanking { get => _posicaoNoRanking; set => _posicaoNoRanking = value; }
        public List<Oportunidade> ListaDeOportunidades { get => _listaDeOportunidades; set => _listaDeOportunidades = value; }
    }
}
