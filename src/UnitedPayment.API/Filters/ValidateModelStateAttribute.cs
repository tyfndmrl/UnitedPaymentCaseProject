using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UnitedPayment.DTO.Models.Results;

namespace UnitedPayment.API.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            var field = context.ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid).Select(x => new FieldModel
            {
                Field = x.Key,
                Message = x.Value.Errors.Select(y => y.ErrorMessage).ToArray()
            });
            var result = new ResponseModel()
            {
                Error = new ErrorModel()
                {
                    Fields = field
                }
            };
            context.Result = new BadRequestObjectResult(result);
        }
    }
}
