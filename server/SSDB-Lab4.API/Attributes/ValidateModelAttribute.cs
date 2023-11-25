using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SSDB_Lab4.API.Attributes;

public class ValidateModelAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result =
                new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}