using AuditManagementPortalMVC.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Providers
{
    public class AuthorizationProvider
    {
        IConfiguration config;
        readonly log4net.ILog _log4net;
        AuthorizationRepo authorizationRepo;
        public AuthorizationProvider(IConfiguration _config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationProvider));
            config = _config;
             authorizationRepo= new AuthorizationRepo(config);
        }
        public string GetToken(Authenticate user)
        {
            try
            {
                _log4net.Info(nameof(AuthorizationProvider)+" invoked");
                string Token;
                Token = authorizationRepo.GetTokenRepo(user);
                return Token;
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from "+nameof(AuthorizationProvider)+"Error Message :"+e.Message);
                return null;
            }
            
        }
    }
}
