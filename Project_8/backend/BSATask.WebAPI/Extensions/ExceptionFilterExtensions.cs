using BSATask.DAL.Entities;
using BSATask.Domain.Exceptions;
using System.Net;

namespace BSATask.WebAPI.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
        {
            return exception switch
            {
                NotFoundException _ => (HttpStatusCode.NotFound, ErrorCode.NotFound),
                DateEarlierException _ => (HttpStatusCode.BadRequest, ErrorCode.BadRequest),
                _ => (HttpStatusCode.InternalServerError, ErrorCode.General),
            };
        }
    }
}
