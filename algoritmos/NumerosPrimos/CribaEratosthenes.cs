namespace NumerosPrimos
{
    public class CribaEratosthenes : IPrimosStrategy
    {
        public List<int> EncontrarPrimos(int desde, int cuantos)
        {
            if (cuantos < 1) return new List<int>();
            desde = Math.Max(desde, 2);

            int limiteSuperiorEstimado = desde + cuantos * 15;

            bool[] esPrimo = new bool[limiteSuperiorEstimado + 1];
            for (int i = 2; i <= limiteSuperiorEstimado; i++)
            {
                esPrimo[i] = true;
            }

            for (int i = 2; i * i <= limiteSuperiorEstimado; i++)
            {
                if (esPrimo[i])
                {
                    for (int j = i * i; j <= limiteSuperiorEstimado; j += i)
                    {
                        esPrimo[j] = false;
                    }
                }
            }

            List<int> primos = new List<int>();
            for (int i = desde; i <= limiteSuperiorEstimado && primos.Count < cuantos; i++)
            {
                if (esPrimo[i])
                {
                    primos.Add(i);
                }
            }

            return primos;
        }
    }
}
