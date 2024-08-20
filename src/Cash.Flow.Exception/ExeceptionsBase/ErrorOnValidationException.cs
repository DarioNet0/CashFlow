namespace Cash.Flow.Exception.ExeceptionsBase;
public class ErrorOnValidationException : CashFlowExecption {
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorsMessages)
    {
        Errors = errorsMessages ?? new List<string>();
    }
    public override string Message => string.Join("; ", Errors);
}
