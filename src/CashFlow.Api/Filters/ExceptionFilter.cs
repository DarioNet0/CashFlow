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
        else {
            ThrowUnknowError(context);
        }
    }
    private void HandleProjectExeception(ExceptionContext context) {
        if (context.Exception is ErrorOnValidationException) {
            var ex = (ErrorOnValidationException)context.Exception ;
            var errorResponse = new ResponseErrorJson(ex.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
    private void ThrowUnknowError(ExceptionContext context) {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessage.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
     }
}