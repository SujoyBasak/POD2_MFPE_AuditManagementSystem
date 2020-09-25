using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public interface IChecklistProvider
    {
        public dynamic QuestionsProvider(string type);
    }
}
