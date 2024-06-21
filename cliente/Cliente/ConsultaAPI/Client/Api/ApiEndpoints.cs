namespace Cliente.ConsultaAPI.Client.Api
{
    public static class ApiEndpoints
    {

        public static class AutenticacionApiUrls
        {
            public static string GetToken()
            {
                return "/api/Auth/login";
            }
        }

        public static class AlgoritmoApiUrls
        {
            public static string ConsultaAlgoritmo()
            {
                return "/api/Algoritmo/GetSolucionAlgoritmo";
            }
        }
    }
}
