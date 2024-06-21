namespace NumerosPrimos
{
    public class Division : IPrimosStrategy
    {
        public List<int> EncontrarPrimos(int desde, int cuantos)
        {
            List<int> primos = new List<int>();
            int numeroActual = Math.Max(desde, 2);

            while (primos.Count < cuantos)
            {
                if (esPrimo(numeroActual))
                {
                    primos.Add(numeroActual);
                }
                numeroActual++;
            }

            return primos;
        }

        static bool esPrimo(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
