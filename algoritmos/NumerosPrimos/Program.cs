using NumerosPrimos;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
            var desde = SolicitarDato("Ingrese un número desde el cual encontrar números primos: ");
            var hasta = SolicitarDato("Ingrese cuantos números primos necesita encontrar : ");

            Console.Write("Seleccione una estrategia de generacion Criba[1] o Division[2]:");
            string input;
            do
            {
                Console.Write("Seleccione una estrategia de generacion C->Criba ó D->Division: ");
                input = Console.ReadLine();
            } while (!input.ToLower().Equals("c") && !input.ToLower().Equals("d"));
        PrimosStrategyFactory buscador;
        if (input.ToLower().Equals("c"))
        {
            buscador = new PrimosStrategyFactory(new CribaEratosthenes());
        }
        else 
        {
            buscador = new PrimosStrategyFactory(new Division());
        }
        List<int> primes = buscador.BuscarPrimos(desde, hasta);
        DisplayPrimes(primes);





    }
    static int SolicitarDato(string prompt)
    {
        int numero;
        do
        {
            Console.Write(prompt);
            int.TryParse(Console.ReadLine(), out numero);
        } while (numero == 0);
        
        return numero;
    }
    static void DisplayPrimes(List<int> primes)
    {
        Console.WriteLine("Números primos encontrados:");
        foreach (int prime in primes)
        {
            Console.Write(prime + " ");
        }
        Console.WriteLine();
    }
}