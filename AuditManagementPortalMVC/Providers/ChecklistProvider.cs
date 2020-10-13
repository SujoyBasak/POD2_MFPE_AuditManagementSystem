using AuditManagementPortalMVC.Models;
using AuditManagementPortalMVC.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Providers
{
    public class ChecklistProvider : IChecklistProvider
    {
        
        IConfiguration config;
        readonly log4net.ILog _log4net;
        ChecklistRepo checklistRepo;
        public ChecklistProvider(IConfiguration _config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(ChecklistProvider));
            config = _config;
            checklistRepo = new ChecklistRepo(config);
        }
        
        public List<ChecklistQuestions> GetQuestions(string auditType, string Token)
        {
            try
            {
                _log4net.Info(nameof(ChecklistProvider) + " invoked");
                List<ChecklistQuestions> questions = new List<ChecklistQuestions>();
                questions = checklistRepo.Index(auditType, Token);
                return questions;
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(ChecklistProvider) + "Error Message :" + e.Message);
                return null;
            }
            
        }
    }
}
