
using System.Net;

namespace Cliente.ConsultaAPI.Client.Exceptions
{
    public sealed class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, APIErrorCode? apiErrorCode, string? message)
            : this(statusCode, apiErrorCode, message ?? "Error no identificado", null)
        {
        }

        private ApiException(
            HttpStatusCode statusCode,
            APIErrorCode? APIErrorCode,
            string message,
            Exception innerException) : base(message, innerException)
        {
            this.APIErrorCode = APIErrorCode;
            this.StatusCode = statusCode;

            Data.Add("StatusCode", StatusCode);
            Data.Add("APIErrorCode", APIErrorCode);
        }

        public APIErrorCode? APIErrorCode { get; }

        public HttpStatusCode StatusCode { get; }
    }
}
