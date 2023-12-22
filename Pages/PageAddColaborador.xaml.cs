using Business.Inovacao;
using CentralInovacao.Models;
using CentralInovacao.Repositories;
using CentralInovacao.ViewModel;

namespace CentralInovacao.Pages;

public partial class PageAddColaborador : ContentPage
{
    int             _user_id      = Preferences.Get("AuthUserId", 0);
    ModelUser       _userFiltered = new ModelUser();
    Project         _objProjeto   = new Project();
	ViewModelSquad  VMSquad       = new ViewModelSquad();

    public PageAddColaborador(Project projeto)
	{
		InitializeComponent();

        VMSquad.CarregarListaDeFuncoes();
        VMSquad.CarregarListaDeUsuarios();
        _objProjeto = projeto;
        _picker.ItemsSource = VMSquad.FunctionList;

        BindingContext = VMSquad;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _searchBar.Text = string.Empty;
    }    

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        //var usuarios = new ObservableCollection<ModelUser>(SearchUsers(((SearchBar)sender).Text));
        _listView.ItemsSource = SearchUsers(((SearchBar)sender).Text);
    }

    private List<ModelUser> SearchUsers(string textoFiltro)
    {
        var usuarios = VMSquad.UserList.Where(
                            x=>!string.IsNullOrWhiteSpace(x.Name) &&
                            x.Name.StartsWith(textoFiltro, StringComparison.OrdinalIgnoreCase)
                        )?.ToList();

        // Se houver apenas um usuário filtrado, armazene-o
        _userFiltered = (usuarios.Count == 1) ? usuarios[0] : null;

        return usuarios;
    }

    private void OnUserTapped(object sender, ItemTappedEventArgs e)
    {
        var clickedUser = e.Item as ModelUser;
        _userFiltered   = clickedUser;

        _listView.ItemsSource   = new List<ModelUser>();
        _searchBar.TextChanged -= SearchBar_TextChanged;
        _searchBar.Text         = clickedUser.Name;
        _searchBar.TextChanged += SearchBar_TextChanged;

        ((ListView)sender).SelectedItem = null;
    }

    private async void Button_Add_Colaborador(object sender, EventArgs e)
    {
        if (_userFiltered != null)
        {
            Squad squadUser = new Squad
            {
                User = _userFiltered.Id,
                Function = (_picker.SelectedItem as ModelGenericLocal)?.Id ?? 0,
                Status = 1
            };

            if (await RESTSquad.AddUserInSquad(squadUser, _objProjeto.Id, _user_id))
            {
                await DisplayAlert("Aviso", "Usuário adicionado à Squad com sucesso!", "Retornar");
                await Shell.Current.Navigation.PopModalAsync();
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Por favor, selecione um usuário.", "OK");
        }
    }

}