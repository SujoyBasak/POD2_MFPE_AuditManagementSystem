using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Models
{
    public class AuditContext: DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options) : base(options)
        {

        }
        public AuditContext()
        {

        }
        public virtual DbSet<AuditResponse> AuditResponse { get; set; }
    }
}
