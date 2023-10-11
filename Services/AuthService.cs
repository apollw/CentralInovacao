//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace CentralInovacao.Services
//{
//    public class AuthService
//    {

//        private const string AuthStateKey = "AuthState";
//        public async Task<bool> IsAuthenticatedAsync()
//        {
//            await Task.Delay(2000);

//            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

//            return authState;
//        }
//        public void Login()
//        {
//            Preferences.Default.Set<bool>(AuthStateKey, true);
//        }
//        public void Logout()
//        {
//            Preferences.Default.Remove(AuthStateKey);
//        }


//    }

//}

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
            await Task.Delay(2000);
            var authState = Preferences.Get(AuthStateKey, true);
            return authState;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            string apiUrl = "https://apisandbox.ceapebrasil.org.br/authentication";

            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Usuario", username),
                new KeyValuePair<string, string>("Senha", password)
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
                await Shell.Current.DisplayAlert(" ",ex.Message,"Retornar");
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
