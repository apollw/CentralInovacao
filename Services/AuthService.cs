using CentralInovacao.MiddlewareApi;
using CentralInovacao.Models;
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
        private const string AuthStateKey   = "AuthState";
        private const string AuthUserStatus = "AuthUserStatus";
        private const string AuthUserId     = "AuthUserId";
        private const string AuthUserName   = "AuthUserName";

        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(100);

            var currentNetwork = Connectivity.NetworkAccess;
            if (currentNetwork != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Aviso", "Verifique a conexão com a internet", "Retornar");
                return false;
            }

            //if (Preferences.ContainsKey(AuthStateKey))
            //{
            //    return Preferences.Get(AuthStateKey, false);
            //}

            if (Preferences.ContainsKey(AuthUserStatus))
            {
                return Preferences.Get(AuthUserStatus, false);
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            await GetTokenAsync();

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("TokenApi", Preferences.Get("AuthToken", "", ""));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("User", username),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("Application", "2")
            });
            
            try
            {
                var request = await httpClient.PostAsync(ModelAuthApi.UrlAuthUser, content);

                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    ModelLogin modelLogin = JsonConvert.DeserializeObject<ModelLogin>(response);

                    if (modelLogin.Success)
                    { 
                        //Login Bem Sucedido
                        Preferences.Set(AuthUserStatus, true);
                        Preferences.Set(AuthUserId, modelLogin.User.Id);
                        Preferences.Set(AuthUserName, modelLogin.User.Name);
                    }

                    return true;
                }
                else
                {
                    Preferences.Set(AuthUserStatus, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(" ", ex.Message, "Retornar");
                return false;
            }
        }

        public async Task<bool> GetTokenAsync()
        {
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Usuario", ModelAuthApi.User),
                new KeyValuePair<string, string>("Senha"  , ModelAuthApi.Password)
            });

            try
            {
                var request = await httpClient.PostAsync(ModelAuthApi.UrlToken, content);                

                if (request.IsSuccessStatusCode)
                {
                    var json = await request.Content.ReadAsStringAsync();

                    ModelAuthToken objResponse = JsonConvert.DeserializeObject<ModelAuthToken>(json);

                    Preferences.Set("AuthToken",objResponse.TokenApi);
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
            Preferences.Remove("AuthUserStatus");
            Preferences.Remove("AuthUserId");
            Preferences.Remove("AuthUserName");
            
            Preferences.Remove("AuthToken");
            Preferences.Remove(AuthStateKey);
        }
    }
}