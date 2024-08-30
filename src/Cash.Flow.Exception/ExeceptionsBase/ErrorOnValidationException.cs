using System.Net;

namespace Cash.Flow.Exception.ExeceptionsBase;
public class ErrorOnValidationException : CashFlowExecption {
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public ErrorOnValidationException(List<string> errorsMessages) : base(string.Empty)
    {
        _errors = errorsMessages;
    }
    public override List<string> GetErrors()
    {
        return _errors;
    }
}