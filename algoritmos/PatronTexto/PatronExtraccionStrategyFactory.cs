

namespace PatronTexto
{
    public static class PatronExtraccionStrategyFactory
    {
        public static IPatronExtraccionStrategy CreateStrategy(string type)
        {
            if (type == "Centro")
            {
                return new PatronDivisionStrategy();
            }

            
            throw new ArgumentException("Tipo de estrategia no soportado");
        }
    }
}
