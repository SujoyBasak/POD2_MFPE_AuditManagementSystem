using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using AuditManagementPortalMVC.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AuditManagementPortalMVC.Controllers
{
    public class PortalController : Controller
    {        
        AuditContext context;
        IConfiguration config;
        readonly log4net.ILog _log4net;
        public PortalController(AuditContext _context,IConfiguration _config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(PortalController));  
            config = _config;            
            context = _context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(Login) + " method called");
                HttpContext.Response.Cookies.Delete("Token");
                return View();
            }
            catch(Exception e)
            {
                _log4net.Error("Error From GET " + nameof(Login) +" Error Message: "+e.Message);
                return View("Error");
            }
            
        }
        
        [HttpPost]
        public IActionResult Login(Authenticate user)
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(Login) + " method called");

                AuthorizationProvider authorizationProvider = new AuthorizationProvider(config);
                string Token = authorizationProvider.GetToken(user);
                if (!string.IsNullOrEmpty(Token))
                {
                    HttpContext.Response.Cookies.Append("Token", Token);
                    return View("Home");
                }

                ViewBag.Message = "Invalid Name or Password";
                return View("Login");
            }
            catch (Exception e)
            {
                _log4net.Error("Error From POST " + nameof(Login) + " Error Message: " + e.Message);
                return View("Error");
            }


        }

        [HttpGet]
        public IActionResult Home()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(Home) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(Home) + " Error Message: " + e.Message);
                return View("Error");
            }

        }
        [HttpPost]
        public IActionResult Checklist(AuditDetail audittype)
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(Checklist) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                List<ChecklistQuestions> listOfQuestions = new List<ChecklistQuestions>();
                ChecklistProvider checklistProvider = new ChecklistProvider(config);
                listOfQuestions = checklistProvider.GetQuestions(audittype.Type, Token);
                return View(listOfQuestions);
            }
            catch (Exception e)
            {
                _log4net.Error("Error From POST " + nameof(Checklist) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        [HttpPost]
        public IActionResult AuditForm()
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(AuditForm) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error("Error From POST " + nameof(AuditForm) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        [HttpPost]
        public IActionResult Severity(AuditRequest request)
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(Severity) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                if (request.Auditdetails.Type == "Internal")
                    return RedirectToAction("Internal");
                else if (request.Auditdetails.Type == "SOX")
                    return RedirectToAction("SOX");
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error("Error From POST " + nameof(Severity) + " Error Message: " + e.Message);
                return View("Error");
            }



        }
        [HttpGet]
        public IActionResult Internal()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(Internal) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(Severity) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        [HttpPost]
        public IActionResult AuditResponseInternalView(InternalQuestions questions)
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(AuditResponseInternalView) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                AuditResponse auditResponse = new AuditResponse();
                SeverityProvider severityProvider = new SeverityProvider(config);
                auditResponse = severityProvider.GetResponseforInternal(questions, Token);

                Storage obj = new Storage();
                obj.add(auditResponse);
                context.AuditResponse.Add(auditResponse);
                context.SaveChanges();

                return View(auditResponse);
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(AuditResponseInternalView) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        public IActionResult History()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(History) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                Storage objOfStorage = new Storage();
                List<AuditResponse> listOfResponse = new List<AuditResponse>();
                listOfResponse = objOfStorage.returnBack();
                return View(listOfResponse);
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(History) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        

        [HttpGet]
        public IActionResult SOX()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(SOX) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(SOX) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        [HttpPost]
        public IActionResult AuditResponseSOXView(SOXQuestions questions)
        {
            try
            {
                _log4net.Info(" Http POST request " + nameof(AuditResponseSOXView) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }

                AuditResponse auditResponse = new AuditResponse();
                SeverityProvider severityProvider = new SeverityProvider(config);
                auditResponse = severityProvider.GetResponseforSOX(questions, Token);

                Storage objOfStorage = new Storage();
                objOfStorage.add(auditResponse);
                context.AuditResponse.Add(auditResponse);
                context.SaveChanges();

                return View(auditResponse);
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(AuditResponseSOXView) + " Error Message: " + e.Message);
                return View("Error");
            }


        }
        [HttpGet]
        public IActionResult SignOut()
        {
            try
            {
                _log4net.Info(" Http GET request " + nameof(SignOut) + " method called");
                string Token = HttpContext.Request.Cookies["Token"];
                if (string.IsNullOrEmpty(Token))
                {
                    ViewBag.Message = "Please Login";
                    return View("Login");
                }
                HttpContext.Response.Cookies.Delete("Token");
                return View("Login");
            }
            catch (Exception e)
            {
                _log4net.Error("Error From GET " + nameof(SignOut) + " Error Message: " + e.Message);
                return View("Error");
            }

        }
        [HttpGet]
        public IActionResult Error()
        {            
            return View();
        }
    }
}