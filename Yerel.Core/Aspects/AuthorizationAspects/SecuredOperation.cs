using System;
using PostSharp.Aspects;

namespace Yerel.Core.Aspects.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation:OnMethodBoundaryAspect
    {
        private string _roles;
        //AuthorizationService _authorizationService;
        public SecuredOperation(string roles)
        {
            _roles = roles;
        }


        public override void OnEntry(MethodExecutionArgs args)
        {
            
        }
    }
}
