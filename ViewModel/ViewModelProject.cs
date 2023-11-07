using CentralInovacao.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private bool _isRefreshing;
        [ObservableProperty]
        private Project _project;
        [ObservableProperty]
        private ObservableCollection<Project> _projectList;
        
        //Comandos
        public ICommand RefreshCommand => new Command(ExecuteRefresh);
        public ViewModelProject()
        {
            Project     = new Project();
            ProjectList = LoadProjects();
        }
        public ViewModelProject(Project project)
        {
            Project     = project;
            ProjectList = new ObservableCollection<Project>();
        }
        private async void ExecuteRefresh()
        {
            await LoadProjectsAsync();
            IsRefreshing = false;
        }
        public int GenerateId(int id)
        {
            if (id != 0)
            {
                return id; // Retorna a ID existente da Oportunidade
            }
            else
            {
                if (ProjectList.Count == 0)
                {
                    return 1; // Se a lista está vazia, retorna 1 como o novo ID
                }
                else
                {
                    int ultimoIdUtilizado = ProjectList.Max(project => project.Id);
                    int novoId = ultimoIdUtilizado + 1;
                    return novoId;
                }
            }
        }
        public void SaveProject(Project project)
        {
            //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");

            //if (File.Exists(filePath))
            //{
            //    string json = File.ReadAllText(filePath);
            //    if (json != string.Empty)
            //        ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            //}

            ProjectList.Add(project);
            //File.WriteAllText(filePath, JsonConvert.SerializeObject(ListaDeOportunidades));
        }

        public ObservableCollection<Project> LoadProjects()
        {
            ProjectList = new ObservableCollection<Project>();
            //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            //if (File.Exists(filePath))
            // {
            //    string json = File.ReadAllText(filePath);
            //    ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            //}
            return ProjectList;
        }

        public async Task<ObservableCollection<Project>> LoadProjectsAsync()
        {
            await Task.Delay(500);
            ProjectList = new ObservableCollection<Project>();
            //var filePath = Path.Combine(FileSystem.AppDataDirectory, "oportunidades.json");
            //if (File.Exists(filePath))
            //{
            //    string json = File.ReadAllText(filePath);
            //    ListaDeOportunidades = JsonConvert.DeserializeObject<ObservableCollection<Oportunidade>>(json);
            //}            
            return ProjectList;
        }
    }
}
