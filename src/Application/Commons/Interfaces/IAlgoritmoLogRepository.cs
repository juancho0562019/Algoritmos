using Domain.Entities;

namespace Application.Commons.Interfaces
{
    public interface IAlgoritmoLogRepository
    {
        Task<int> LogResponse(Algoritmo algoritmo, CancellationToken cancellationToken = default);
    }
}
