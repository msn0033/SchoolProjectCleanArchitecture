using Microsoft.Extensions.Localization;
using SchoolProject.Helper.Resources;

namespace SchoolProject.Helper.ResponseHelper;

public class ResponseHandler
{
    private readonly IStringLocalizer<ShareResources> _localizer;

    public ResponseHandler( IStringLocalizer<ShareResources> localizer)
    {
        this._localizer = localizer;
    }
    public Response<T> Deleted<T>(string Message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = Message == null ? _localizer["Deleted Successfully"] : Message
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null!)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = _localizer["Successfully"],
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = _localizer["UnAuthorized"]
        };
    }
    public Response<T> BadRequest<T>(string Message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? _localizer["Bad Request"] : Message
        };
    }
    public Response<T> Failed<T>(string Message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.ExpectationFailed,
            Succeeded = false,
            Message = Message == null ? _localizer["Failed"] : Message
        };
    }


    public Response<T> NotFound<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? _localizer["Not Found"] : message
        };
    }

    public Response<T> UnprocessableEntity<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = message == null ? _localizer["Unprocessab leEntity"]: message
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
