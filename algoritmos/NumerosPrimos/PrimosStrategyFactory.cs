namespace NumerosPrimos
{
    public class PrimosStrategyFactory
    {
        private IPrimosStrategy _strategy;

        public PrimosStrategyFactory(IPrimosStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IPrimosStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<int> BuscarPrimos(int desde, int hasta)
        {
            return _strategy.EncontrarPrimos(desde, hasta);
        }
    }
}
