using ConstructorRostro;

class Program
{
    static void Main()
    {
        Rostrobuilder faceBuilder = new Rostrobuilder();

        faceBuilder.AñadirOjos(SolicitarDato("Ingrese un caracter para los ojos: ", 1));
        faceBuilder.AñadirCejas(SolicitarDato("Ingrese dos caracteres para las cejas: ", 2));
        faceBuilder.AñadirNariz(SolicitarDato("Ingrese un caracter para la nariz: ", 1));
        faceBuilder.AñadirBoca(SolicitarDato("Ingrese tres caracteres para la boca en el orden que desea que aparezcan: ", 3));
        faceBuilder.AñadirCabello(SolicitarDato("Ingrese un caracter para el cabello: ", 1));
        faceBuilder.AñadirOrejas(SolicitarDato("Ingrese dos caracteres para las orejas: ", 2));
        faceBuilder.AñadirContorno(SolicitarDato("Ingrese un caracter para delinear la cara o para el contorno: ", 1));
        faceBuilder.AñadirBarbilla(SolicitarDato("Ingrese tres caracteres para el mentón: ", 3));

        Rostro face = faceBuilder.Build();
        face.Display();
    }

    static string SolicitarDato(string prompt, int expectedLength)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()??"";
        } while (input.Length != expectedLength);
        return input;
    }
}