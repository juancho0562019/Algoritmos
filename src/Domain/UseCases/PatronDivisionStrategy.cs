using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.UseCases
{
    public class PatronDivisionStrategy : IPatronExtraccionStrategy
    {
        public string ExtraerValores(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new InvalidStringException();

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
