using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditBenchmarkController : ControllerBase   //Port 44386
    {        
        private readonly log4net.ILog _log4net;
        private readonly IBenchmarkProvider obj;
        public AuditBenchmarkController(IBenchmarkProvider _obj)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            obj = _obj;
        }
        /// <summary>
        /// GET: api/AuditBenchmark 
        /// Input - nothing ; 
        /// Output - List of Benchmark
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {            
            List<AuditBenchmark> ls = new List<AuditBenchmark>();
            _log4net.Info(" Http GET request");
            try
            {                
                ls= obj.GetBenchmark();
                if (ls == null)
                    return BadRequest();
                return Ok(ls);
            }
            catch(Exception e)
            {
                _log4net.Error(" Exception here" + e.Message);
                return StatusCode(500);
            }
        }     
    }   
}


