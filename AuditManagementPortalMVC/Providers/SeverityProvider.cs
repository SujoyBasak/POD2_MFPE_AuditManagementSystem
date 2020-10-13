using AuditManagementPortalMVC.Models;
using AuditManagementPortalMVC.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Providers
{
    public class SeverityProvider : ISeverityProvider
    {
        IConfiguration config;
        SeverityRepo severityRepo;
        public SeverityProvider(IConfiguration _config)
        {
            config = _config;
            severityRepo = new SeverityRepo(config);
        }
        public AuditResponse GetResponseforInternal(InternalQuestions questions, string Token)
        {
            AuditResponse auditResponse = new AuditResponse();
            auditResponse= severityRepo.GetInternalResponse(questions, Token);
            return auditResponse;
        }

        public AuditResponse GetResponseforSOX(SOXQuestions questions, string Token)
        {
            AuditResponse auditResponse = new AuditResponse();
            auditResponse = severityRepo.GetSOXResponse(questions, Token);
            return auditResponse;
        }
    }
}
