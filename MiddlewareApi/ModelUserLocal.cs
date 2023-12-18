using CentralInovacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.MiddlewareApi
{
    public class ModelUserLocal
    {
        private int    _id   = 0;
        private string _name = " ";

        public Usuario ConvertToObject()
        {
            Usuario usuario = new Usuario();

            usuario.Id   = _id;
            usuario.Name = _name;

            return usuario;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }

    public class ModelLogin
    {
        private string    _message = String.Empty;
        private Boolean   _success = false;
        private ModelUserLocal _user    = new ModelUserLocal();
        public string Message { get => _message; set => _message = value; }
        public bool Success { get => _success; set => _success = value; }
        public ModelUserLocal User { get => _user; set => _user = value; }
    }
}

