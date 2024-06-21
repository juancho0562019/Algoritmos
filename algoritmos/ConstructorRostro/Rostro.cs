namespace ConstructorRostro
{
    public class Rostro
    {
        public string Ojos { get; set; } = string.Empty;
        public string Cejas { get; set; } = string.Empty;
        public string Nariz { get; set; } = string.Empty;
        public string Boca { get; set; } = string.Empty;
        public string Cabello { get; set; } = string.Empty;
        public string Orejas { get; set; } = string.Empty;
        public string Contorno { get; set; } = string.Empty;
        public string Barbilla { get; set; } = string.Empty;

        public void Display()
        {
            char[,] grid = new char[7, 7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    grid[i, j] = ' ';

            for (int i = 1; i <= 5; i++)
                grid[0, i] = Cabello[0];

            grid[1, 0] = Contorno[0];
            grid[1, 3] = Cejas[0];
            grid[1, 4] = Cejas[1];
            grid[1, 6] = Contorno[0];

            grid[2, 0] = Orejas[0];
            grid[2, 2] = Ojos[0];
            grid[2, 4] = Ojos[0];
            grid[2, 6] = Orejas[1];

            grid[3, 0] = Contorno[0];
            grid[3, 3] = Nariz[0];
            grid[3, 6] = Contorno[0];

            grid[4, 0] = Contorno[0];
            grid[4, 2] = Boca[0];
            grid[4, 3] = Boca[1];
            grid[4, 4] = Boca[2];
            grid[4, 6] = Contorno[0];

            grid[5, 1] = Contorno[0];
            grid[5, 5] = Contorno[0];

            grid[6, 2] = Barbilla[0];
            grid[6, 3] = Barbilla[1];
            grid[6, 4] = Barbilla[2];

            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

