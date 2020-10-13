using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using AuditManagementPortalMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AuditManagementPortalMVC.Repository
{
    public class SeverityRepo:ISeverityRepo 
    {
        Uri baseAddress;   //44398
        HttpClient client;
        IConfiguration config;
        

        public SeverityRepo(IConfiguration _config)
        {
            config = _config;
            baseAddress = new Uri(config["Links:Severity"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }

        public AuditResponse GetInternalResponse(InternalQuestions questions,string Token)
        {
            AuditResponse auditResponse = new AuditResponse();

            AuditRequest auditRequest = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type="Internal",
                    questions = new Questions()
                    {
                        Question1 = questions.Question1,
                        Question2 = questions.Question2,
                        Question3 = questions.Question3,
                        Question4 = questions.Question4,
                        Question5 = questions.Question5                        
                    }
                }
            };
            

            string data = JsonConvert.SerializeObject(auditRequest);            
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AuditSeverity",content).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                auditResponse = JsonConvert.DeserializeObject<AuditResponse>(result);
            }
            return auditResponse;
            
        }

        public AuditResponse GetSOXResponse(SOXQuestions questions,string Token)
        {
            AuditResponse auditResponse = new AuditResponse();

            AuditRequest auditRequest = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "SOX",
                    questions = new Questions()
                    {
                        Question1 = questions.Question1,
                        Question2 = questions.Question2,
                        Question3 = questions.Question3,
                        Question4 = questions.Question4,
                        Question5 = questions.Question5
                    }
                }
            };


            string data = JsonConvert.SerializeObject(auditRequest);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AuditSeverity", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                auditResponse = JsonConvert.DeserializeObject<AuditResponse>(result);
            }
            return auditResponse;

        }
    }
}