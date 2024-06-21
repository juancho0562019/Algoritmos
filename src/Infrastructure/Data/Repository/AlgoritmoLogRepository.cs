using Application.Commons.Interfaces;
using Domain.Entities;

namespace Infrastructure.Data.Repository
{
    public class AlgoritmoLogRepository : IAlgoritmoLogRepository
    {
        private readonly IApplicationDbContext _context;

        public AlgoritmoLogRepository(IApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<int> LogResponse(Algoritmo algoritmo, CancellationToken cancellationToken = default)
        {
            await _context.Algoritmos.AddAsync(algoritmo, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
