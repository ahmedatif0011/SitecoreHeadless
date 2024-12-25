using Microsoft.Extensions.Localization;
using SitecoreHeadless.Data.Resources;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Core.Bases
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>(T entity, string message)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message

            };
        }
        public Response<T> Success<T>(T entity, object meta = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Data = entity,
                Meta = meta,
                
            };
        }
        public Response<T> Unauthorized<T>(T? entity,string  message)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message
            };
        }
        public Response<T> BadRequest<T>(T Entity,string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message
            };
        }
        public Response<T> NotFound<T>(T entity,string message = null)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message
            };
        }
        public Response<T> Created<T>(T entity, object Meta = null, string Message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = Message,
                Meta = Meta
            };
        }
        public Response<T> UnProcessableEntity<T>(T entity, string message)
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message.ToString()
            };
        }

        public Response<T> Build<T>(T data,Response response)
        {
            switch (response)
            {
                case Response.Failed:
                    return UnProcessableEntity(data, SharedResourcesKeys.UnProcessableEntity);
                case Response.Success:
                    return Success(data);
                case Response.Unauthorized:
                    return Unauthorized(data, SharedResourcesKeys.UnAuthorized);
                case Response.NoContent:
                    return Success(data);
                case Response.TooManyRequests:
                    return UnProcessableEntity(data,SharedResourcesKeys.TooManyRequests);
                case Response.Created:
                    return Success(data);
                case Response.Accepted:
                    return Success(data);
                case Response.NotFound:
                    return NotFound(data);
                case Response.InternalServerError:
                    return UnProcessableEntity(data, SharedResourcesKeys.UnProcessableEntity);
                default:
                    break;
            }
            return NotFound(data,SharedResourcesKeys.NotFound);
        }
    }
}
