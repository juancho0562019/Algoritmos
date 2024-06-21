

namespace Domain.Interfaces
{
    public interface IPatronExtraccionStrategyFactory
    {
        void RegisterStrategy(string type, IPatronExtraccionStrategy strategy);
        IPatronExtraccionStrategy CreateStrategy(string type);
    }
}
