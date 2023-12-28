using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace CentralInovacao.ViewModel
{
    public partial class ViewModelProject : ObservableObject
    {
        [ObservableProperty]
        private bool    _isBusy;
        [ObservableProperty]
        private bool    _isRefreshing;
        [ObservableProperty]
        private int     _statusActivated;
        [ObservableProperty]
        private int     _statusDeactivated;
        [ObservableProperty]
        private Project _objProject;

        //Listas Gerais
        [ObservableProperty]
        private List<ModelArea>                   _listAreaGeneral;
        [ObservableProperty]
        private ObservableCollection<Squad>       _squadProject;
        [ObservableProperty]
        private ObservableCollection<Project>     _projectList;
        [ObservableProperty]
        private ObservableCollection<Project>     _projectListGeneral;

        //Lista de Tarefas
        [ObservableProperty]
        private ObservableCollection<ProjectTask> _taskListBacklog;
        [ObservableProperty]
        private ObservableCollection<ProjectTask> _taskListOngoing;
        [ObservableProperty]
        private ObservableCollection<ProjectTask> _taskListFinished;
        [ObservableProperty]
        private ObservableCollection<ProjectTask> _taskListGeneral;

        public ViewModelProject()
        {
            ObjProject = new Project();
            GetListaProjetosUsuario();
        }

        public ViewModelProject(Project project)
        {
            ObjProject = project;
        }

        public async Task<bool> SalvarProjeto(Project project)
        {
            return await RESTProject.CreateProject(project);
        }

        public async Task<bool> EditarProjeto(Project project, List<ModelArea> ProjectAreas)
        {
            project.ListArea = ProjectAreas;
            return await RESTProject.EditProject(project,project.Id,project.User);
        }

        public async void GetProjeto(int project_id,int user_id)
        {
            ObjProject = await RESTProject.GetProject(project_id,user_id);
        }

        public async void GetListaProjetosGeral()
        {
            List<Project> ListaCarregada = new List<Project>();
            ListaCarregada     = await RESTProject.GetListProjects();
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
            var body           = JsonConvert.SerializeObject(projetoJSON);
            ListaCarregada     = await RESTProject.GetListProjectsUser(body);
            ProjectListGeneral = new ObservableCollection<Project>(ListaCarregada);
        }

        public async void GetListaProjetosUsuario()
        {
            List<Project> ListaCarregada = new List<Project>();
            ListaCarregada = await RESTProject.GetListProjectsUser();
            ProjectList    = new ObservableCollection<Project>(ListaCarregada);
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
            var body       = JsonConvert.SerializeObject(projetoJSON);
            ListaCarregada = await RESTProject.GetListProjectsUser(body);
            ProjectList    = new ObservableCollection<Project>(ListaCarregada);

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
            await RESTProject.AddProjectImage(project, body);
        } 
    }
}
