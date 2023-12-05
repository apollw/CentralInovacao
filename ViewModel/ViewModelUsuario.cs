using CentralInovacao.MiddlewareApi;
using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelUsuario:ObservableObject
    {
        [ObservableProperty]
        private ModelUserLocal _usuario;

        public ViewModelUsuario()
        {
            Usuario = new ModelUserLocal();    
        }
    }
}
