using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using Business.Inovacao;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelSquad : ObservableObject
    {
        [ObservableProperty]
        private bool          _isRefreshing;
        [ObservableProperty]
        private List<ModelGenericLocal> _functionList;
        [ObservableProperty]
        private ObservableCollection<ModelUser> _userList;

        public ViewModelSquad()
        {
            FunctionList     = new List<ModelGenericLocal>();
            UserList         = new ObservableCollection<ModelUser>();
        }
        
        public async void CarregarListaDeUsuarios()
        {
            List<ModelUser> ListaDeUsuarios = new List<ModelUser>();
            ListaDeUsuarios = await RESTResources.GetListUsers(" ");
            UserList = new ObservableCollection<ModelUser>(ListaDeUsuarios);
        }

        public async void CarregarListaDeFuncoes()
        {
            FunctionList = await RESTResources.GetListFunctions();
        }
    }
}
