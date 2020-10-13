using AuditManagementPortalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Repository
{
    public interface IChecklistRepo
    {
        public List<ChecklistQuestions> Index(string auditType, string Token);
    }
}
