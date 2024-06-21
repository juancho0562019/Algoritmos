using Domain.Interfaces;


namespace Domain.UseCases
{
    public class PatronExtraccionStrategyFactory : IPatronExtraccionStrategyFactory
    {
        private readonly Dictionary<string, IPatronExtraccionStrategy> strategies = new Dictionary<string, IPatronExtraccionStrategy>();

        public PatronExtraccionStrategyFactory()
        {
            RegisterStrategy("Centro", new PatronDivisionStrategy());
        }
        
        public void RegisterStrategy(string type, IPatronExtraccionStrategy strategy)
        {
            strategies[type] = strategy;
        }

        public  IPatronExtraccionStrategy CreateStrategy(string type)
        {
            if (strategies.ContainsKey(type))
            {
                return strategies[type];
            }

            throw new ArgumentException("Tipo de estrategia no soportado");
        }
    }
}
