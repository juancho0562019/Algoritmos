
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Auth.Request;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Auth.Response;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Solucion.Request;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Solucion.Response;
using System.Threading;

namespace Cliente.ConsultaAPI.Client.Api.Algoritmos
{
    public interface IAlgoritmoClient
    {
        Task<ConsultarPatronResponse?> ConsultarPatronAsync(ConsultarPatronRequest request);
        Task<AuthResponse?> Auth(AuthRequest request);
    }
}
