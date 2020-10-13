using AuditManagementPortalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Providers
{
    public interface ISeverityProvider
    {
        public AuditResponse GetResponseforInternal(InternalQuestions questions, string Token);
        public AuditResponse GetResponseforSOX(SOXQuestions questions, string Token);
    }
}
