using System.ComponentModel;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _06_ParallelHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //N1
            //Parallel.Invoke(() => Console.WriteLine($"Result :: " +
            //    $"{Factorial(4)}");

            //N2
            //Parallel.Invoke(() => SumOfNumbers(4), 
            //                ()=>CountOfDigits(4);

            //N3        
            //string finalpath=Path.Combine(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
            //    "Test.txt");
            //using (StreamWriter writer = new StreamWriter(finalpath))
            //{
            //    Parallel.For(5, 8 + 1, i =>
            //    {
            //        for (int j = 1; j <= 10; j++)
            //        {
            //            int result = i * j;
            //            writer.WriteLine($"{i} * {j} = {result}");
            //            Thread.Sleep(500);
            //        }
            //    });
            //}

            //N4
            //string finalpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            //                             "Numbers.txt");
            //Random rnd = new Random();
            //using (StreamWriter writer = new StreamWriter(finalpath))
            //{
            //    for (int i = 0; i <= 10; i++)
            //    {
            //        writer.WriteLine(rnd.Next(20));
            //    }
            //};
            //StreamReader reader = new StreamReader(finalpath);
            //List<int> numbers = new List<int>();
            //string line;
            //while((line=reader.ReadLine())!=null)
            //{
            //    numbers.Add(int.Parse(line));
            //}
            //Thread.Sleep(3000);
            //Parallel.ForEach(numbers,FactorialVoid);

            //N5
            string finalpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                         "Numbers.txt");
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(finalpath))
            {
                for (int i = 0; i <= 10; i++)
                {
                    writer.WriteLine(rnd.Next(20));
                }
            };
            StreamReader reader = new StreamReader(finalpath);
            List<int> numbers = new List<int>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                numbers.Add(int.Parse(line));
            }

            Thread.Sleep(2000);
            Parallel.Invoke(() =>
            {
                Console.WriteLine($"Max number in file :: {numbers.Max()}");
            },
            ()=>
            {
                Console.WriteLine($"Min number in file :: {numbers.Min()}");
            },
            ()=>
            {
                Console.WriteLine($"Sum of number in file :: {numbers.Sum()}");
            });
        }
        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
        static void FactorialVoid(int numbers)
        {
            long result = 1;

            for (int i = 1; i <= numbers; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Result of digit {numbers} :: {result}");
        }
        static void SumOfNumbers(int x)
        {
            int num = Factorial(x);
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Sum of numbers :: {sum}");
        }
        static void CountOfDigits(int x)
        {
            int num = Factorial(x);
            Console.WriteLine($"Count of digits :: " +
                $"{num.ToString().Length}");
        }
    }
}
