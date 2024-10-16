using LocalizationLanguage;
using Microsoft.Extensions.Localization;


namespace SchoolProject.Core.Base.ApiResponse
{
    public class ApiResponseHandler
    {
        private readonly IStringLocalizer<ApiResponseHandler> _localizer;

        // public ResponseHandler() { }
        public ApiResponseHandler(IStringLocalizer<ApiResponseHandler> localizer)
        {
            this._localizer = localizer;
        }
        public ApiResponse<T> Deleted<T>(string Message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message == null ? _localizer[ShareResourcesKey.Deleted_Successfully] : Message
            };
        }
        public ApiResponse<T> Success<T>(T entity, object Meta = null!)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[ShareResourcesKey.Successfully],
                Meta = Meta
            };
        }
        public ApiResponse<T> Unauthorized<T>(string Message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = Message == null ? _localizer[ShareResourcesKey.UnAuthorized] : Message
            };
        }
        public ApiResponse<T> BadRequest<T>(string Message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? _localizer[ShareResourcesKey.Bad_Request] : Message
            };
        }
        public ApiResponse<T> Failed<T>(string Message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.ExpectationFailed,
                Succeeded = false,
                Message = Message == null ? _localizer[ShareResourcesKey.Failed] : Message
            };
        }
        public ApiResponse<T> NotFound<T>(string message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _localizer[ShareResourcesKey.NotFound] : message
            };
        }
        public ApiResponse<T> UnprocessableEntity<T>(string message = null!)
        {
            return new ApiResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? _localizer[ShareResourcesKey.Unprocessab_leEntity] : message
            };
        }
        public ApiResponse<T> Created<T>(T entity, object Meta = null!, string message = null!)
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = message == null ? _localizer[ShareResourcesKey.Created] : message,
                //Message = message, //_localizer[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }
    }
}
