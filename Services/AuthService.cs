using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Services
{
    public class AuthService
    {
        private const string AuthStateKey = "AuthState";

        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(100);

            var currentNetwork = Connectivity.NetworkAccess;
            if (currentNetwork != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Aviso", "Verifique a conexão com a internet", "Retornar");
                return false;
            }

            if (Preferences.ContainsKey(AuthStateKey))
            {
                return Preferences.Get(AuthStateKey, false);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            string apiUrl = "https://apisandbox.ceapebrasil.org.br/authentication";
            
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Usuario", username),
                new KeyValuePair<string, string>("Senha"  , password)
            });
            
            try
            {
                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    Preferences.Set("AuthToken", token);

                    Preferences.Set(AuthStateKey, true);
                    return true;
                }
                else
                {
                    Preferences.Set(AuthStateKey, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
                return false;
            }
        }

        public void Logout()
        {
            Preferences.Remove("AuthToken");
            Preferences.Remove(AuthStateKey);
        }
    }
}