using System.Net;
using System.Runtime.CompilerServices;

namespace Cash.Flow.Exception.ExeceptionsBase
{
    public class NotFoundException : CashFlowExecption
    {
        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return new List<string>() { Message };
        }
    }
}
