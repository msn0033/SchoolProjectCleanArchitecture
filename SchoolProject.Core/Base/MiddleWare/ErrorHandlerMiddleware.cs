using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using Serilog;
using System;
using System.Net;
using System.Text.Json;

namespace SchoolProject.Core.Base.MiddleWare
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<ErrorHandlerMiddleware> _localizer;


        public ErrorHandlerMiddleware(RequestDelegate next, IStringLocalizer<ErrorHandlerMiddleware> localizer)
        {
            _next = next;
            _localizer = localizer;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);

            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;

            response.ContentType = "application/json";

            var responseModel = new ApiResponse<string>() { Succeeded = false, Message = error?.Message };

            //TODO:: cover all validation errors
            switch (error)
            {
                case UnauthorizedAccessException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    responseModel.Message = error.Message;
                    responseModel.Message += e.InnerException == null ? "" : "\n " + e.InnerException.Message;
                    // responseModel.StatusCode = HttpStatusCode.Unauthorized;

                    break;

                case ValidationException validationEx:
                    // custom validation error
                    response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    responseModel.Message = error.Message;
                    responseModel.Message += validationEx.InnerException == null ? "" : "\n " + validationEx.InnerException.Message;
                    //responseModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                    responseModel.Errors = validationEx.Errors.Select(x => _localizer[x.PropertyName] + " : " + _localizer[x.ErrorMessage]).ToList();

                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = error?.Message;
                    responseModel.Message += e.InnerException == null ? "" : "\n " + e.InnerException.Message;
                    //  responseModel.StatusCode = HttpStatusCode.NotFound;

                    break;

                case DbUpdateException e:
                    // can't update error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = e.Message;
                    responseModel.Message += e.InnerException == null ? "" : "\n " + e.InnerException.Message;
                    //  responseModel.StatusCode = HttpStatusCode.BadRequest;

                    break;

                default:
                    // unhandled error
                    {
                        responseModel.Message = error.Message;
                        responseModel.Message += error.InnerException == null ? "" : "\n " + error.InnerException.Message;

                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        // responseModel.Errors.Add(error.Message);
                        responseModel.Data = DateTime.UtcNow.ToString();


                        Log.Error(error, "An unhandled exception has occurred.");

                    }
                    break;

            }

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }


}
