using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Models
{
    public class AuditRequest
    {
        [Required]
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }
        [Required]
        [Display(Name = "Project Manager Name")]
        public string ProjectManagerName { get; set; }
        [Required]
        [Display(Name = "Application Owner Name")]
        public string ApplicationOwnerName { get; set; }        
        public AuditDetail Auditdetails { get; set; }
    }
}
