using AuditManagementPortalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Repository
{
    public interface ISeverityRepo
    {
        public AuditResponse GetInternalResponse(InternalQuestions questions, string Token);
        public AuditResponse GetSOXResponse(SOXQuestions questions, string Token);
    }
}
