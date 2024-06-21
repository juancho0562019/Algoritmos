using Domain.Entities;

namespace Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Algoritmo> Algoritmos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
