using DvdStore.Communication.Responses;
using DvdStore.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DvdStore.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DvdStoreException dvdStoreException)
            HandleProjectException(dvdStoreException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(DvdStoreException dvdStoreException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)dvdStoreException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(dvdStoreException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido"));
    }
}
