using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Repository
{
    public class AuthorizationRepo:IAuthorizationRepo
    {
        Uri baseAddress;
        HttpClient client;        
        IConfiguration config;
        readonly log4net.ILog _log4net;
        public AuthorizationRepo(IConfiguration _config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationRepo));
            config = _config;
            baseAddress = new Uri(config["Links:Auth"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;            

        }
        public string GetTokenRepo(Authenticate user)
        {
            try
            {
                _log4net.Info(nameof(AuthorizationRepo) + " invoked");
                string data = JsonConvert.SerializeObject(user);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Token/", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string Token = response.Content.ReadAsStringAsync().Result;                    
                    return Token;

                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(AuthorizationRepo) + "Error Message :" + e.Message);
                return null;
            }

        }
    }
}
