using CentralInovacao.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Oportunidade
    {
        private int                     _id;
        private int                     _usuario;
        private int                     _status;
        private int                     _analista;
        private int                     _estagioAtual;
        private int                     _motivoDeclinio;

        private DateTime                _data;
        private DateTime                _dataFim;
        private DateTime                _dataAnalise;
        private DateTime                _dataSquad;
        private DateTime                _dataPlanejamento;
        
        private string                  _nome;
        private string                  _descricaoPositiva;
        private string                  _descricaoNegativa;
        private string                  _descricaoAnalise;
        
        private Dictionary<string, int> _setores;
        private ObservableCollection<Tarefa> _listaDeTarefas;
        private ObservableCollection<Tarefa> _listaDeTarefasBacklog;
        private ObservableCollection<Tarefa> _listaDeTarefasExecucao;
        private ObservableCollection<Tarefa> _listaDeTarefasFinalizadas;

        public Oportunidade()
        {
            ListaDeTarefas            = new ObservableCollection<Tarefa>();
            ListaDeTarefasBacklog     = new ObservableCollection<Tarefa>();
            ListaDeTarefasExecucao    = new ObservableCollection<Tarefa>();
            ListaDeTarefasFinalizadas = new ObservableCollection<Tarefa>();

            Setores = new Dictionary<string, int>
            {
                { "Administrativo", 0 },
                { "Análise de Crédito", 0 },
                { "Auditoria", 0 },
                { "Contabilidade", 0 },
                { "Creli", 0 },
                { "Financeiro", 0 },
                { "Gestão de Pessoas", 0 },
                { "Infraestrutura Civil", 0 },
                { "Recebimentos", 0 },
                { "Renovação Automática", 0 },
                { "Seguros", 0 },
                { "T.I. Inovação", 0 },
                { "Tecnologia da Informação", 0 }
            };
        }

        public int Id { get => _id; set => _id = value; }
        public int Usuario { get => _usuario; set => _usuario = value; }
        public int Status { get => _status; set => _status = value; }
        public int Analista { get => _analista; set => _analista = value; }
        public int EstagioAtual { get => _estagioAtual; set => _estagioAtual = value; }
        public int MotivoDeclinio { get => _motivoDeclinio; set => _motivoDeclinio = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public DateTime DataFim { get => _dataFim; set => _dataFim = value; }
        public DateTime DataAnalise { get => _dataAnalise; set => _dataAnalise = value; }
        public DateTime DataSquad { get => _dataSquad; set => _dataSquad = value; }
        public DateTime DataPlanejamento { get => _dataPlanejamento; set => _dataPlanejamento = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string DescricaoPositiva { get => _descricaoPositiva; set => _descricaoPositiva = value; }
        public string DescricaoNegativa { get => _descricaoNegativa; set => _descricaoNegativa = value; }
        public string DescricaoAnalise { get => _descricaoAnalise; set => _descricaoAnalise = value; }
        public Dictionary<string, int> Setores { get => _setores; set => _setores = value; }
        public ObservableCollection<Tarefa> ListaDeTarefas { get => _listaDeTarefas; set => _listaDeTarefas = value; }
        public ObservableCollection<Tarefa> ListaDeTarefasBacklog { get => _listaDeTarefasBacklog; set => _listaDeTarefasBacklog = value; }
        public ObservableCollection<Tarefa> ListaDeTarefasExecucao { get => _listaDeTarefasExecucao; set => _listaDeTarefasExecucao = value; }
        public ObservableCollection<Tarefa> ListaDeTarefasFinalizadas { get => _listaDeTarefasFinalizadas; set => _listaDeTarefasFinalizadas = value; }

        public class Setor
        {
            public string Nome { get; set; }
            public int    Selecionado { get; set; }
        }
    }    
}



