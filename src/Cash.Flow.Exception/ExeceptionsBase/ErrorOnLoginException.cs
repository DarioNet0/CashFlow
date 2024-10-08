
using System.Net;

namespace Cash.Flow.Exception.ExeceptionsBase
{
    public class ErrorOnLoginException : CashFlowExecption
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
        public ErrorOnLoginException() : base("Credenciais inválidas")
        {

        }
        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
