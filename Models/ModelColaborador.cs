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

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
