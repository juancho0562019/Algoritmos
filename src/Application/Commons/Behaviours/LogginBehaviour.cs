using Application.Commons.Interfaces;
using Domain.Entities;
using Newtonsoft.Json;

namespace Application.Commons.Behaviours
{

    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAlgoritmoLogRepository _logger;
        private readonly TimeProvider _dateTime;
        public LoggingBehaviour(IAlgoritmoLogRepository logger, TimeProvider dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) 
        { 
            
            var entity = new Algoritmo 
            {
                Request = JsonConvert.SerializeObject(request),
                FechaRequest = _dateTime.GetLocalNow()
            };

            var response = await next();

            entity.Response = JsonConvert.SerializeObject(response);
            entity.FechaResponse = _dateTime.GetLocalNow();
            try
            {
                await _logger.LogResponse(entity);
            }
            catch (Exception ex)
            {
                // TODO: Log manejo de errores
            }

            return response;
        }
    }

}
