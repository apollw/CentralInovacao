using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Tarefa
    {
        private int        _id;
        private DateTime   _dataInicio;
        private DateTime   _dataTermino;
        private string     _titulo;
        private string     _descricao;
        private string     _status;
        private string     _responsavel;
        private string     _comentarios;
        private List<Item> _listaDeItens;

        public int Id { get => _id; set => _id = value; }
        public DateTime DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public DateTime DataTermino { get => _dataTermino; set => _dataTermino = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public string Status { get => _status; set => _status = value; }        
        public string Responsavel { get => _responsavel; set => _responsavel = value; }
        public List<Item> ListaDeItens { get => _listaDeItens; set => _listaDeItens = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }

        public class Item
        {
            public DateTime Date   { get; set; }
            public int      Status { get; set; }
            //Status 0 = Em andamento, 1 = finalizado 
            public string   Titulo { get; set; }
        }
    }
}
