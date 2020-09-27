using AuditBenchmarkModule.Models;

using System.Collections.Generic;

namespace AuditBenchmarkModule.Repository
{
    public interface IBenchmarkRepo
    {
        public List<AuditBenchmark> GetNolist();
       
    }
}
