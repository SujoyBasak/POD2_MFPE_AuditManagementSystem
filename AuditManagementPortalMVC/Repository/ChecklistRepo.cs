using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using AuditManagementPortalMVC.Repository;

namespace AuditManagementPortalMVC.Repository
{
    public class ChecklistRepo: IChecklistRepo
    {
        Uri baseAddress;   //44344
        HttpClient client;
        readonly log4net.ILog _log4net;
        IConfiguration config;       
        
        public ChecklistRepo(IConfiguration _config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(ChecklistRepo));
            config = _config;
            baseAddress = new Uri(config["Links:Checklist"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public List<ChecklistQuestions> Index(string auditType,string Token) 
        {
            try
            {
                _log4net.Info(nameof(ChecklistRepo) + " invoked");
                List<ChecklistQuestions> listOfQuestions = new List<ChecklistQuestions>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AuditChecklist/" + auditType).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    listOfQuestions = JsonConvert.DeserializeObject<List<ChecklistQuestions>>(data);
                }
                return listOfQuestions;
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(ChecklistRepo) + "Error Message :" + e.Message);
                return null;
            }
            
        }
    }
}