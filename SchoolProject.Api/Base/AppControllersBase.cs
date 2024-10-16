﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Base.ApiResponse;
using System.Net;

namespace SchoolProject.Api.Base
{

    [ApiController]
    public class AppControllersBase : ControllerBase
    {
        private IMediator? _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext?.RequestServices.GetService<IMediator>()!;

        #region Actions
        // List يعمل مع جميع الحالات ماعدا
        // يعمل مع اي شي يرجع قيمة وحدة -  
        public ObjectResult NewResult<T>(ApiResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
        #endregion
    }
}
