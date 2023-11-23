using Microsoft.Extensions.Localization;
using SchoolProject.Helper.Resources;

namespace SchoolProject.Helper.ResponseHelper;

public class ResponseHandler
{
    private readonly IStringLocalizer<ShareResources> _localizer;

    public ResponseHandler() { }
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
            Message = Message == null ? _localizer[ShareResourcesKey.Deleted_Successfully] : Message
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null!)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = _localizer[ShareResourcesKey.Successfully],
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = _localizer[ShareResourcesKey.UnAuthorized]
        };
    }
    public Response<T> BadRequest<T>(string Message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? _localizer[ShareResourcesKey.Bad_Request] : Message
        };
    }
    public Response<T> Failed<T>(string Message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.ExpectationFailed,
            Succeeded = false,
            Message = Message == null ? _localizer[ShareResourcesKey.Failed] : Message
        };
    }


    public Response<T> NotFound<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? _localizer[ShareResourcesKey.NotFound] : message
        };
    }

    public Response<T> UnprocessableEntity<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = message == null ? _localizer[ShareResourcesKey.Unprocessab_leEntity]: message
        };
    }

    public Response<T> Created<T>(T entity, object Meta = null!, string message = null!)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = message==null?_localizer[ShareResourcesKey.Created]:message,
            //Message = message, //_localizer[SharedResourcesKeys.Created],
            Meta = Meta
        };
    }
}
