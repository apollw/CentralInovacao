using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelColaborador:ObservableObject
    {
        [ObservableProperty]
        private Usuario _colaborador;

        public ViewModelColaborador()
        {
            Colaborador = new Usuario();    
        }
    }
}
