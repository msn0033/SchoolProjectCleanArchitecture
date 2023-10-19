﻿namespace SchoolProject.Helper.ResponseHelper
{
    public class ResponseHandler
    {

        public ResponseHandler()
        {

        }
        public Response<T> Deleted<T>(string Message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message == null ? "Deleted Successfully" : Message
            };
        }
        public Response<T> Success<T>(T entity, object Meta = null!)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Successfully",
                Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }


        public Response<T> NotFound<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "Unprocessab leEntity" : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null!, string message = null!)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = message, //_localizer[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }
    }
}
