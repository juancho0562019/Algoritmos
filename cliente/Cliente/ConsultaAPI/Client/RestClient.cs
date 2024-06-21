using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Cliente.ConsultaAPI.Client.Exceptions;
using Cliente.ConsultaAPI.Client.Helpers;

namespace Cliente.ConsultaAPI.Client
{
    public class RestClient : IRestClient
    {
        private readonly ClientOptions? _options;

        protected readonly JsonSerializerSettings DefaultSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
        };

        private HttpClient? _httpClient;

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
        }

        public async Task<T?> GetAsync<T>(
            string uri,
            IDictionary<string, string>? queryParams = null,
            IDictionary<string, string>? headers = null,
            JsonSerializerSettings? serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            var response = await SendAsync(uri, HttpMethod.Get, queryParams, headers,
                cancellationToken: cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }
       
        public async Task<T?> PostAsync<T>(
            string uri,
            object body,
            IDictionary<string, string>? queryParams = null,
            IDictionary<string, string>? headers = null,
            JsonSerializerSettings? serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body, DefaultSerializerSettings),
                    Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(uri, HttpMethod.Post, queryParams, headers, AttachContent,
                cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);

        }

     

        private static ClientOptions MergeOptions(ClientOptions options)
        {
            return new ClientOptions
            {
                AuthToken = options.AuthToken,
                BaseUrl = options.BaseUrl ?? Constantes.BaseUrl,
                ApiVersion = options.ApiVersion ?? Constantes.DefaultVersion
            };
        }

        private static async Task<Exception> BuildException(HttpResponseMessage response)
        {
            var errorBody = await response.Content.ReadAsStringAsync();

            ProblemDetails? errorResponse = null;

            if (!string.IsNullOrWhiteSpace(errorBody) && response.StatusCode != System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    errorResponse = JsonConvert.DeserializeObject<ProblemDetails>(errorBody);
                }
                catch (Exception ex)
                {
                    throw new CustomException("Error when parsing the api response.");
                }
            }
            else if(!string.IsNullOrWhiteSpace(errorBody)) 
            {
                throw new CustomException(errorBody);
            }

            return new ApiException(response.StatusCode, APIErrorCode.InternalServerError, errorResponse?.Detail);
        }

        private async Task<HttpResponseMessage> SendAsync(
            string requestUri,
            HttpMethod httpMethod,
            IDictionary<string, string>? queryParams = null,
            IDictionary<string, string>? headers = null,
            Action<HttpRequestMessage>? attachContent = null,
            CancellationToken cancellationToken = default)
        {
            EnsureHttpClient();

            requestUri = AddQueryString(requestUri, queryParams);

            using var httpRequest = new HttpRequestMessage(httpMethod, requestUri);
           
            httpRequest.Headers.Add("Api-Version", _options?.ApiVersion);

            if (headers != null)
            {
                AddHeaders(httpRequest, headers);
            }

            attachContent?.Invoke(httpRequest);

            if (_httpClient is null)
                throw new ArgumentException("Instancia http no valida");


            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw await BuildException(response);
            }

            return response;
        }

        private static void AddHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        private void EnsureHttpClient()
        {
            if (_httpClient != null)
            {
                return;
            }

            var pipeline = new LoggingHandler { InnerHandler = new HttpClientHandler() };

            _httpClient = new HttpClient(pipeline);
            _httpClient.BaseAddress = new Uri(_options?.BaseUrl ?? "");
        }

        private static string AddQueryString(string uri, IDictionary<string, string>? queryParams)
        {
            return queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);
        }
    }

}
