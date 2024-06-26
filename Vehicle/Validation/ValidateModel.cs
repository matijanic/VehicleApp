﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.WebAPI.Validation
{
    public class ValidateModel : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }

        }
    }
}
