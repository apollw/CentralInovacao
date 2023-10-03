using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelProjeto:ObservableObject
    {
        [ObservableProperty]
        private Projeto       _projeto;
        [ObservableProperty]
        private List<Projeto> _listaDeProjetos; 

        public ViewModelProjeto()
        {
            Projeto         = new Projeto();
            ListaDeProjetos = new List<Projeto>(); 
        }

        public void CriarProjeto(Oportunidade oportunidade)
        {
            //Uma Oportunidade Aprovada vira um projeto

            Projeto.Id                = oportunidade.Id;
            Projeto.Titulo            = oportunidade.Titulo;
            Projeto.AspectosPositivos = oportunidade.AspectosPositivos;
            Projeto.AspectosNegativos = oportunidade.AspectosNegativos;
            Projeto.StatusDoProjeto   = new StatusDoProjeto();
           
            ListaDeProjetos.Add(Projeto);   
        }
    }
}
