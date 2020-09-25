using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
using AuditChecklistModule.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditChecklistController : ControllerBase
    {
        private readonly IChecklistProvider obj;
        readonly log4net.ILog _log4net;
                 
        public AuditChecklistController(IChecklistProvider _obj)
        {
            obj = _obj;
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        }

        // GET: api/AuditChecklist
        [HttpGet("{auditType}")]
        public IActionResult GetQuestions(string auditType)
        {
            _log4net.Info("AuditChecklistController Http GET request called");
            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            try
            {
                var list = obj.QuestionsProvider(auditType);

                if (list != null)
                    return Ok(list);
                else
                    return BadRequest("Wrong Input");
            }
            catch(Exception e)
            {
                _log4net.Error("Exception from AuditChecklist" +e.Message);
                return StatusCode(500);
            }
        }        
    }
}
