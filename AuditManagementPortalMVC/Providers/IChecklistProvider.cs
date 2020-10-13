using AuditManagementPortalMVC.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Providers
{
    public interface IChecklistProvider
    {
        public List<ChecklistQuestions> GetQuestions(string auditType, string Token);
    }
}
