using MobileV1.Models.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileV1.Services
{
    class UserAccountService : IUserAccountService
    {
        private readonly string ROOT_URL = Configuration.Settings["API:Server"];
        private readonly HttpClient _client = new HttpClient();

        public async Task<UserLogined> Login(LoginModel loginF)
        {
            try
            {

                var json = JsonConvert.SerializeObject(loginF);
                // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                StringContent loginHttpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); 
                var login = await _client.PostAsync(ROOT_URL + "/api/account/login", loginHttpContent);
                login.EnsureSuccessStatusCode();
                string categoryContentResponseBody = await login.Content.ReadAsStringAsync();
                UserLogined user = JsonConvert.DeserializeObject<UserLogined>(categoryContentResponseBody);
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR In Service: " + ex.Message);
                return null;
            }
        }


    }
}
