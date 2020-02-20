using ApplicationServices.Interfaces;
using SumOfMultiple;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class SumOfMultipleService : IProblemSolver
    {
        private readonly NaturalNumberSumCalculator _naturalNumberSumCalculator;

        public SumOfMultipleService(NaturalNumberSumCalculator naturalNumberSumCalculator)
        {
            _naturalNumberSumCalculator = naturalNumberSumCalculator ?? throw new ArgumentNullException(nameof(naturalNumberSumCalculator));
        }

        public async Task<string> Start()
        {
            Console.WriteLine("Please enter a positive number to be analysed: ");
            var input = Console.ReadLine();

            var number = ParseInput(input);

            if (number == -1)
            {
                Console.WriteLine("Input is not a natural number. Try again!");
                return string.Empty;
            }

            Console.WriteLine("Initializing analysis...");
            var naturalSumResult = await _naturalNumberSumCalculator.Calculate(number, 3, 5);
            
            return naturalSumResult.ToString();
        }

        private static long ParseInput(string input)
        {
            if (long.TryParse(input, out var number) && number > 0) 
                return number;
            
            return -1;
        }
    }
}
