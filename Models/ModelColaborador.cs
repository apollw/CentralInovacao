using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class ModelColaborador
    {
        private int    _id;
        private string _nome;
        private string _sobrenome;
        private string _email;
        private string _password;

        private int                     _posicaoNoRanking;
        private List<ModelProjeto>      _listaDeProjetos;
        private List<ModelMedalha>      _listaDeMedalhas;
        private List<ModelOportunidade> _listaDeOportunidades;
        

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public int PosicaoNoRanking { get => _posicaoNoRanking; set => _posicaoNoRanking = value; }
        public List<ModelProjeto> ListaDeProjetos { get => _listaDeProjetos; set => _listaDeProjetos = value; }
        public List<ModelMedalha> ListaDeMedalhas { get => _listaDeMedalhas; set => _listaDeMedalhas = value; }
        public List<ModelOportunidade> ListaDeOportunidades { get => _listaDeOportunidades; set => _listaDeOportunidades = value; }
    }
}
