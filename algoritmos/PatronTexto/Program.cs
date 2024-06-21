
namespace PatronTexto
{
    static class Program
    {
        static void Main()
        {

            Console.WriteLine("Ingrese las cadenas de texto:");


            string cadena = Console.ReadLine() ?? "";


            IPatronExtraccionStrategy strategy = PatronExtraccionStrategyFactory.CreateStrategy("Centro");


            Console.WriteLine($"{cadena} -> {strategy.ExtraerValores(cadena)}");

        }
    }
}