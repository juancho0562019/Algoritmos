namespace PatronTexto
{
    public class PatronDivisionStrategy : IPatronExtraccionStrategy
    {
        public string ExtraerValores(string input)
        {
            int length = input.Length;
            if (length % 2 == 0)
            {
                return input.Substring((length / 2) - 1, 2);
            }
            else
            {
                return input.Substring(length / 2, 1);
            }
        }
    }
}
