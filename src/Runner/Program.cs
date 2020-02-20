using Runner.Factories;
using System;
using System.Threading.Tasks;

namespace Runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (await Run()) { }
        }

        static async Task<bool> Run()
        {
            try
            {
                Console.WriteLine("## Which problem do you want to solve? ##");
                Console.WriteLine("To find the sum of all natural numbers that are multiple of 3 or 5 - ENTER '1'");
                Console.WriteLine("To find the uppercase words in a string and order all characters in these words alphabetically - ENTER '2'");
                Console.WriteLine("To exit the application enter any other key");

                var service = ProblemSolverFactory.Create(Console.ReadLine());

                if (service == null)
                {
                    return false;
                }

                var result = await service.Start();

                Console.WriteLine($"The result is: {result}");
                Console.WriteLine();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
                Console.WriteLine(ex.GetBaseException().Message);

                return false;
            }            
        }
    }
}
