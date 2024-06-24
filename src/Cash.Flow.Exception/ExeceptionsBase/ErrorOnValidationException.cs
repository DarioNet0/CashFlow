namespace Cash.Flow.Exception.ExeceptionsBase;
public class ErrorOnValidationException : CashFlowExecption {
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
