using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelProject : ObservableObject
    {
        [ObservableProperty]
        private bool            _isRefreshing;
        [ObservableProperty]
        private Project         _project;
        [ObservableProperty]
        private RESTProject     _rESTProject;
        [ObservableProperty]
        private List<ModelArea> _ListAreaGeneral;
        [ObservableProperty]
        private ObservableCollection<Project> _projectList;      

        public ViewModelProject()
        {
            Project     = new Project(); 
            RESTProject = new RESTProject();
            ProjectList = new ObservableCollection<Project>();
        }
        public ViewModelProject(Project project)
        {
            Project     = project;
            ProjectList = new ObservableCollection<Project>();
        }
        public async void SaveProject(Project project)
        {
            await RESTProject.CreateProject(project);
        }

    }
}
