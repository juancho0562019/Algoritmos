using Cliente.ConsultaAPI.Client.Api.Algoritmos;

namespace Cliente.ConsultaAPI.Client
{
    public interface IApiClient
    {

        IAlgoritmoClient AlgoritmoClient { get; }
    }

    public class ApiClient : IApiClient
    {
        public ApiClient(
            IRestClient restClient,
            IAlgoritmoClient algoritmoClient
            )
        {
            RestClient = restClient;
            AlgoritmoClient = algoritmoClient;
        }
        public IAlgoritmoClient AlgoritmoClient { get; }
        public IRestClient RestClient { get; }
    }
}
