using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Algoritmos.GetSolucion
{
    public class GetSolucionAlgoritmoRequest: IRequest<GetSolucionAlgoritmoResponse>
    {
        [Required(ErrorMessage = "Campo cadena requerido")]
        [MaxLength(30, ErrorMessage = "Tamaño maximo de cadena 30")]
        public string Cadena { get; set; } = string.Empty;
    }
    public class GetSolucionAlgoritmoResponse
    {
        
        public string Respuesta { get; set; } = string.Empty;
    }
    public class GetSolucionAlgoritmoHandler : IRequestHandler<GetSolucionAlgoritmoRequest, GetSolucionAlgoritmoResponse>
    {
        private readonly IPatronExtraccionStrategyFactory _factory;

        public GetSolucionAlgoritmoHandler(IPatronExtraccionStrategyFactory factory) 
        {
            _factory = factory;
        }
        public async Task<GetSolucionAlgoritmoResponse> Handle(GetSolucionAlgoritmoRequest request, CancellationToken cancellationToken)
        {
            var strategy= _factory.CreateStrategy("Centro");

            return await Task.FromResult(new GetSolucionAlgoritmoResponse { Respuesta = strategy.ExtraerValores(request.Cadena) });
        }
    }
}
