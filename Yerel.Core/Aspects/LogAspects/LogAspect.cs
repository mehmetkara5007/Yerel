using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Yerel.Core.CrossCuttingConcern.Logging;
using Yerel.Core.CrossCuttingConcern.Security.Web;
using log4net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System.Security.Principal;

namespace Yerel.Core.Aspects.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage( MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof (LoggerService))
                throw new Exception("Wrong Logger Type");

            _loggerService = (LoggerService) Activator.CreateInstance(_loggerType, Type.EmptyTypes);

            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsDebugEnabled)
            {
                return;
            }

            try
            {
                var logParametreleri = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParametreleri
                };

                ThreadContext.Properties["sessionId"] = ((MyIdentity)Thread.CurrentPrincipal.Identity).SessionId;
                ThreadContext.Properties["page"] = ((MyIdentity)Thread.CurrentPrincipal.Identity).Url;

                _loggerService.Debug(logDetail);
            }
            catch (Exception)
            {
            }
        }
    }
}
