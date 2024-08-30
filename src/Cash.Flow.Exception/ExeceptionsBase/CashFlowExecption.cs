namespace Cash.Flow.Exception.ExeceptionsBase;
public abstract class CashFlowExecption : SystemException {
    protected CashFlowExecption(string message) : base(message) 
    {
        
    }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
