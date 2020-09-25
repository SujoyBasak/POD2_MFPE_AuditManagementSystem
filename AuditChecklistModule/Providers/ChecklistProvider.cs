using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public class ChecklistProvider:IChecklistProvider
    {
        private readonly IChecklistRepo obj;
        public ChecklistProvider(IChecklistRepo _obj)
        {
            obj = _obj;
        }
        List<Questions> list = new List<Questions>();

        public dynamic QuestionsProvider(string type)
        {
            if (string.IsNullOrEmpty(type))
                return null;

            else if (!type.Contains("Internal") && !type.Contains("SOX"))
                return null;
            
            try
            {
                list = obj.GetQuestions(type);
                return list;
            }
            catch(Exception)
            {
                return null;
            }
            
            
        }
    }
}
