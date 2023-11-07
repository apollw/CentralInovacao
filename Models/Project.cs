using CentralInovacao.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Project
    {
        private int id            = 0;
        private int user          = 0;
        private int analyst       = 0;
        private int status        = 0;
        private int currentStage  = 0;
        private int reasonDecline = 0;

        private DateTime dateIni      = new DateTime();
        private DateTime dateEnd      = new DateTime();
        private DateTime dateAnalisys = new DateTime();
        private DateTime dateSquad    = new DateTime();
        private DateTime datePlanning = new DateTime();

        private string name                = string.Empty;
        private string descriptionPositve  = string.Empty;
        private string descriptionNegative = string.Empty;
        private string descriptionAnalyst  = string.Empty;

        private string lkpUser          = string.Empty;
        private string lkpAnalyst       = string.Empty;
        private string lkpStatus        = string.Empty;
        private string lkpCurrentStage  = string.Empty;
        private string lkpReasonDecline = string.Empty;

        //private List<ModelArea> listArea = new List<ModelArea>();

        public Project() { }

        public Project(Project objProject)
        {
            this.id            = objProject.Id;
            this.user          = objProject.User;
            this.analyst       = objProject.Analyst;
            this.status        = objProject.Status;
            this.currentStage  = objProject.CurrentStage;
            this.reasonDecline = objProject.ReasonDecline;

            this.dateIni      = objProject.DateIni;
            this.dateEnd      = objProject.DateEnd;
            this.DateSquad    = objProject.DateSquad;
            this.dateAnalisys = objProject.DateAnalisys;
            this.datePlanning = objProject.DatePlanning;

            this.name                = objProject.Name;
            this.descriptionPositve  = objProject.DescriptionPositve;
            this.descriptionNegative = objProject.DescriptionNegative;
            this.descriptionAnalyst  = objProject.DescriptionAnalyst;

            this.lkpUser          = objProject.LkpUser;
            this.lkpAnalyst       = objProject.LkpAnalyst;
            this.lkpStatus        = objProject.LkpStatus;
            this.lkpCurrentStage  = objProject.LkpCurrentStage;
            this.lkpReasonDecline = objProject.LkpReasonDecline;

            //foreach (ProjetoSetor obj in objProjeto.ListaSetor)
              //  this.listArea.Add(new ModelArea(obj.ObjSetor));
        }

        public Project ConvertToObject()
        {
            Project objProject = new Project();

            objProject.Id             = this.id;
            objProject.User           = this.user;
            objProject.Analyst        = this.analyst;
            objProject.Status         = this.status;
            objProject.CurrentStage   = this.currentStage;
            objProject.ReasonDecline  = this.reasonDecline;

            objProject.DateIni      = this.dateIni;
            objProject.DateEnd      = this.dateEnd;
            objProject.DateSquad    = this.dateSquad;
            objProject.DateAnalisys = this.dateAnalisys;
            objProject.DatePlanning = this.datePlanning;

            objProject.Name                = this.name;
            objProject.DescriptionPositve  = this.descriptionPositve;
            objProject.DescriptionNegative = this.descriptionNegative;
            objProject.DescriptionAnalyst  = this.descriptionAnalyst;

            return objProject;
        }
       
        //private Dictionary<string, int> _setores;
        //private List<Tarefa>            _listaDeTarefas;
        //private List<Tarefa>            _listaDeTarefasBacklog;
        //private List<Tarefa>            _listaDeTarefasExecucao;
        //private List<Tarefa>            _listaDeTarefasFinalizadas;

        public int Id { get => id; set => id = value; }
        public int User { get => user; set => user = value; }
        public int Analyst { get => analyst; set => analyst = value; }
        public int Status { get => status; set => status = value; }
        public int CurrentStage { get => currentStage; set => currentStage = value; }
        public int ReasonDecline { get => reasonDecline; set => reasonDecline = value; }
        public DateTime DateIni { get => dateIni; set => dateIni = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }
        public DateTime DateAnalisys { get => dateAnalisys; set => dateAnalisys = value; }
        public DateTime DateSquad { get => dateSquad; set => dateSquad = value; }
        public DateTime DatePlanning { get => datePlanning; set => datePlanning = value; }
        public string Name { get => name; set => name = value; }
        public string DescriptionPositve { get => descriptionPositve; set => descriptionPositve = value; }
        public string DescriptionNegative { get => descriptionNegative; set => descriptionNegative = value; }
        public string DescriptionAnalyst { get => descriptionAnalyst; set => descriptionAnalyst = value; }
        public string LkpUser { get => lkpUser; set => lkpUser = value; }
        public string LkpAnalyst { get => lkpAnalyst; set => lkpAnalyst = value; }
        public string LkpStatus { get => lkpStatus; set => lkpStatus = value; }
        public string LkpCurrentStage { get => lkpCurrentStage; set => lkpCurrentStage = value; }
        public string LkpReasonDecline { get => lkpReasonDecline; set => lkpReasonDecline = value; }

        //public Project()
        //{
        //    ListaDeTarefas = new List<Tarefa>();            

        //    Setores = new Dictionary<string, int>
        //    {
        //        { "Administrativo", 0 },
        //        { "Análise de Crédito", 0 },
        //        { "Auditoria", 0 },
        //        { "Contabilidade", 0 },
        //        { "Creli", 0 },
        //        { "Financeiro", 0 },
        //        { "Gestão de Pessoas", 0 },
        //        { "Infraestrutura Civil", 0 },
        //        { "Recebimentos", 0 },
        //        { "Renovação Automática", 0 },
        //        { "Seguros", 0 },
        //        { "T.I. Inovação", 0 },
        //        { "Tecnologia da Informação", 0 }
        //    };
        //}

        //    public class Setor
        //    {
        //        public string Nome { get; set; }
        //        public int    Selecionado { get; set; }
        //    }


    }    
}



