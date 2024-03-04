using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace _03_TasksHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //N1
            //Task task = new Task(GetCurrentTime);
            //task.Start();
            //
            //Task task1 = Task.Factory.StartNew(GetCurrentTime);
            //
            //Task task2 = Task.Run(GetCurrentTime);

            //N2
            //Console.Write("Enter first number :: ");
            //
            //int a = int.Parse(Console.ReadLine());
            //Console.Write("Enter first number :: ");
            //int b = int.Parse(Console.ReadLine());
            //Task task = Task.Run(()=>GetPrimeNumber(a, b));

            //N3
            //Task taskMax = Task.Run(GetMaxNumber);
            //Task taskMin = Task.Run(GetMinNumber);
            //Task taskAverage = Task.Run(GetAverageNumber);
            //Task taskSum = Task.Run(GetSumNumber);

            //N4
            Task task = Task.Run(ReapitingNumbers);
            task.Wait();
        }
        static void GetCurrentTime()
        {
            Console.WriteLine("Data : " + DateTime.Now.ToShortDateString()
                + ", Time : " + DateTime.Now.ToShortTimeString());
        }
        static void GetPrimeNumber(int a, int b)
        {
            for (int x = a; x < b; x++)
            {
                int isPrime = 0;
                for (int y = 1; y < x; y++)
                {
                    if (x % y == 0)
                        isPrime++;

                    if (isPrime == 2) break;
                }
                if (isPrime != 2)
                    Console.WriteLine(x+" is not prime");

                isPrime = 0;
            }
        }
        static int[] RandomNumbers()
        {
            int[] a = new int[100];
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                a[i] = random.Next(1, 1000);
            }
            return a;
        }
        static void GetMaxNumber()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Max. number :: "+a.Max());
        }
        static void GetMinNumber()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Min. number :: " + a.Min());
        }
        static void GetAverageNumber()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Average number :: " + a.Average());
        }
        static void GetSumNumber()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Sum of number :: " + a.Sum());
        }
        static void ReapitingNumbers()
        {
            int[]q= RandomNumbers();
            int[]a = q.Distinct().ToArray();
            Console.WriteLine("Array cleared!");
            Array.Sort(a);
            Console.WriteLine("Array sorted!");
            Console.WriteLine("New cleared array!");
            foreach (var item in a)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Console.Write("Enter number for search :: ");
            int b =int.Parse(Console.ReadLine());
            int c =Array.BinarySearch(a,b);
            Console.WriteLine(c);

        }
        static void Test()
        {
            int[] a = new int[4];
            a[0] = 1;
            a[1] = 1;
            a[2] = 2;
            a[3] = 3;
            foreach (var item in a)
            {
                Console.Write(item+" ");
            }
            int[] q = a.Distinct().ToArray();
            Console.WriteLine();
            foreach (var item in q)
            {
                Console.Write(item + " ");
            }
        }

    }
}
