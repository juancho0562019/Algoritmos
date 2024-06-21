using Newtonsoft.Json;

namespace Cliente.ConsultaAPI.Client
{
    public interface IRestClient
    {
        Task<T?> GetAsync<T>(
            string uri,
            IDictionary<string, string>? queryParams = null,
            IDictionary<string, string>? headers = null,
            JsonSerializerSettings? serializerSettings = null,
            CancellationToken cancellationToken = default);
       
        Task<T?> PostAsync<T>(
            string uri,
            object body,
            IDictionary<string, string>? queryParams = null,
            IDictionary<string, string>? headers = null,
            JsonSerializerSettings? serializerSettings = null,
            CancellationToken cancellationToken = default);

       
    }

}
