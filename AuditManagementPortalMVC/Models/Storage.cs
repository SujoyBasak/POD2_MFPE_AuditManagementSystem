using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Models
{
    public class Storage
    {
        public static List<AuditResponse> ls = new List<AuditResponse>();
        public void add(AuditResponse audits)
        {
            ls.Add(audits);
            
        }
        public List<AuditResponse> returnBack()
        {
            return ls;
        }
    }
}
