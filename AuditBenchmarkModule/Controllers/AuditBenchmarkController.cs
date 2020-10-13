using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< HEAD
    [Authorize]
    public class AuditBenchmarkController : ControllerBase   //Port 44386
    {        
=======
    public class AuditBenchmarkController : ControllerBase
    {
>>>>>>> 94b51e972d6ac2d9917bd87ba83b98ef7d82ddc4
        private readonly log4net.ILog _log4net;
        private readonly IBenchmarkProvider objProvider;
        public AuditBenchmarkController(IBenchmarkProvider _objProvider)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            objProvider = _objProvider;
        }
        /// <summary>
        /// GET: api/AuditBenchmark 
        /// Input - nothing ; 
        /// Output - List of Benchmark
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
<<<<<<< HEAD
        {            
            List<AuditBenchmark> ls = new List<AuditBenchmark>();
            _log4net.Info(" Http GET request");
            try
            {                
                ls= obj.GetBenchmark();
                if (ls == null)
                    return BadRequest();
                return Ok(ls);
=======
        {
            List<AuditBenchmark> listOfProvider = new List<AuditBenchmark>();
            _log4net.Info(" Http GET request "+ nameof(AuditBenchmarkController));
            try
            {                
                listOfProvider = objProvider.GetBenchmark();
                return Ok(listOfProvider);
>>>>>>> 94b51e972d6ac2d9917bd87ba83b98ef7d82ddc4
            }
            catch(Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " "+ nameof(AuditBenchmarkController));
                return StatusCode(500);
            }
        }     
    }   
}


