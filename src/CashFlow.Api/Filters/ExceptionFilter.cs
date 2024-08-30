using Cash.Flow.Exception;
using Cash.Flow.Exception.ExeceptionsBase;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter {
    public void OnException(ExceptionContext context) {
        if (context.Exception is CashFlowExecption) {
            HandleProjectExeception(context);
        }
    }
    private void HandleProjectExeception(ExceptionContext context) {
        var cashFlowException = context.Exception as CashFlowExecption;
        var errorResponse = new ResponseErrorJson(cashFlowException!.GetErrors());
        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new BadRequestObjectResult(errorResponse);
    }
    private void ThrowUnknowError(ExceptionContext context) {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessage.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
     }
}