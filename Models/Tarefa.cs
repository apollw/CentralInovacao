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
        private int        _idProjeto;
        private int        _idUsuario;
        private int        _status;
        private int        _ordem;
        private DateTime   _data;
        private string     _titulo;
        private string     _descricao;
        private Item       _itemNovo;
        private List<Item> _listaDeItems;

        public Tarefa()
        {
            ItemNovo     = new Item();
            ListaDeItems = new List<Item>();
        }

        //Item de Tarefa
        public class Item
        {
            public int      id          { get; set; }
            public int      Status      { get; set; }
            public int      Responsavel { get; set; }    
            public string   Nome        { get; set; }
            public string   Descricao   { get; set; }
            public DateTime Data        { get; set; }
            public DateTime DataFim     { get; set; }
        }

        public int Id { get => _id; set => _id = value; }
        public int IdProjeto { get => _idProjeto; set => _idProjeto = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int Status { get => _status; set => _status = value; }
        public int Ordem { get => _ordem; set => _ordem = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public List<Item> ListaDeItems { get => _listaDeItems; set => _listaDeItems = value; }
        public Item ItemNovo { get => _itemNovo; set => _itemNovo = value; }
    }
}
