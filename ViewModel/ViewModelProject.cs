using Business.Inovacao;
using CentralInovacao.MiddlewareApi;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private List<ModelArea> _listAreaGeneral;
        [ObservableProperty]
        private ObservableCollection<Project> _projectList;
        [ObservableProperty]
        private ObservableCollection<Project> _projectListGeneral;

        public ViewModelProject()
        {
            Project     = new Project(); 
            RESTProject = new RESTProject();
        }

        public ViewModelProject(Project project)
        {
            Project     = project;
            RESTProject = new RESTProject();
        }

        public async Task<bool> SalvarProjeto(Project project)
        {
            return await RESTProject.CreateProject(project);
        }

        public async void EditarProjeto(Project project, List<ModelArea> ProjectAreas)
        {
            project.ListArea = ProjectAreas;
            await RESTProject.EditProject(project,project.Id,project.User);
        }

        public async void GetProjeto(int project_id,int user_id)
        {
            //Popula o objeto Project da ViewModelProject
            Project = await RESTProject.GetProject(project_id,user_id);
        }

        public async void GetListaProjetosGeral()
        {
            List<Project> ListaCarregada = new List<Project>();

            ListaCarregada = await RESTProject.GetListProjects();

            //Popular a Lista de Projetos do Usuário
            ProjectListGeneral = new ObservableCollection<Project>(ListaCarregada);
        }

        public async void GetListaProjetosFiltroPorData(DateTime DateIni, DateTime DateEnd)
        {
            List<Project> ListaCarregada = new List<Project>();

            var projetoJSON = new JObject(
            new JProperty("DateIni", DateIni),
            new JProperty("DateEnd", DateEnd),
            new JProperty("OnlyMyProjects", false)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            ListaCarregada = await RESTProject.GetListProjectsUser(body);

            //Popular a Lista de Projetos do Usuário
            ProjectListGeneral = new ObservableCollection<Project>(ListaCarregada);
        }

        public async void GetListaProjetosUsuario()
        {
            List<Project> ListaCarregada = new List<Project>();

            ListaCarregada = await RESTProject.GetListProjectsUser();

            //Popular a Lista de Projetos do Usuário
            ProjectList = new ObservableCollection<Project>(ListaCarregada);

        }

        public async void GetListaProjetosUsuarioFiltroPorData(DateTime DateIni, DateTime DateEnd)
        {
            List<Project> ListaCarregada = new List<Project>();

            var projetoJSON = new JObject(
            new JProperty("DateIni", DateIni),
            new JProperty("DateEnd", DateEnd),
            new JProperty("OnlyMyProjects", true),
            new JProperty("User", Preferences.Get("AuthUserId",0))
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(projetoJSON);

            ListaCarregada = await RESTProject.GetListProjectsUser(body);

            //Popular a Lista de Projetos do Usuário
            ProjectList = new ObservableCollection<Project>(ListaCarregada);

        }

        public async void SalvarImagemProjeto(Project project, FileInfo fileInfo, string file)
        {

            var objJSON = new JObject(
            new JProperty("Project", project.Id),
            new JProperty("User", project.User),
            new JProperty("Type", 1),
            new JProperty("Name", fileInfo.Name),
            new JProperty("Extension", fileInfo.Extension),
            new JProperty("Document",file)
            );

            //Serializa o objeto JSON
            var body = JsonConvert.SerializeObject(objJSON);

            //Popular a Lista de Projetos do Usuário
            await RESTProject.AddProjectImage(project, body);
        }
    }
}
