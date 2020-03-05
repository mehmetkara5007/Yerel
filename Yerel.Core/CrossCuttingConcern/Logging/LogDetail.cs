using System.Collections.Generic;
using Yerel.Core.Aspects.LogAspects;

namespace Yerel.Core.CrossCuttingConcern.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}