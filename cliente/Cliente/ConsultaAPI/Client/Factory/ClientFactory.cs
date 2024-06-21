using Cliente.ConsultaAPI.Client.Api.Algoritmos;


namespace Cliente.ConsultaAPI.Client.Factory
{
    public static class ClientFactory
    {
        public static ApiClient Create(ClientOptions options)
        {
            var restClient = new RestClient(options);

            return new ApiClient(
                restClient
                , algoritmoClient: new AlgoritmoClient(restClient)
            );
        }
    }
}
