using Cliente.ConsultaAPI.Client.Api.Algoritmos.Auth.Request;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Auth.Response;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Solucion.Request;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Solucion.Response;


namespace Cliente.ConsultaAPI.Client.Api.Algoritmos
{
    public partial class AlgoritmoClient : IAlgoritmoClient
    {
        private readonly IRestClient _client;

        public AlgoritmoClient(IRestClient restClient)
        {
            _client = restClient;
        }
        public async Task<ConsultarPatronResponse?> ConsultarPatronAsync(ConsultarPatronRequest request)
        {
            var queryParams = new Dictionary<string, string>
                                {
                                    { "cadena", request.Cadena }
                                };

            var headers = new Dictionary<string, string>
                                {
                                            { "Authorization", $"Bearer {request.Token}" } 
                                };
            return await _client.GetAsync<ConsultarPatronResponse>(
                ApiEndpoints.AlgoritmoApiUrls.ConsultaAlgoritmo(),
                queryParams,
                headers
            );
        }

        public async Task<AuthResponse?> Auth(AuthRequest request)
        {
     
            return await _client.PostAsync<AuthResponse>(
                ApiEndpoints.AutenticacionApiUrls.GetToken(),
                request
            );
        }
    }
}
