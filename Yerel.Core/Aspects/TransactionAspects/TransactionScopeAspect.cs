using System;
using System.Transactions;
using PostSharp.Aspects;

namespace Yerel.Core.Aspects.TransactionAspects
{
    [Serializable]
    public sealed class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private readonly TransactionScopeOption _option;

        public TransactionScopeAspect()
        {
        }

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
    } 
}
