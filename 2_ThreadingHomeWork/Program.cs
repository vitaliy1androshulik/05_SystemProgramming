using System.IO;

namespace _2_ThreadingHomeWork
{
    internal class Program
    {
        static void Numbers()
        {
            Console.WriteLine("Thread started!");
            for (int i = 0; i <= 50; i++) 
            { 
                Console.WriteLine(i);
            }
        }
        static void Numbers2(int a, int b)
        {
            Console.WriteLine("Thread started!");
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }
        static int[] RandomNumbers()
        {
            int[] a = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0,5000);
            }
            return a;
        }
        static void FindMax()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Max number :: "+a.Max());
        }
        static void FindMin()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Min number :: " + a.Min());
        }
        static void FindAverage()
        {
            int[] a = RandomNumbers();
            Console.WriteLine("Average number :: " + a.Average());
        }
        static void Main(string[] args)
        {
            //N1
            //Thread thread = new Thread(Numbers);
            //thread.Start();

            //N2
            //int a = 0;
            //int b = 20;
            //Thread thread = new Thread(()=>Numbers2(a,b));
            //thread.Start();

            //N3
            //int countOfThreads = 3;
            //int a = 0;
            //int b = 100;
            //int c = 0;
            //do
            //{
            //    Thread thread = new Thread(() => Numbers2(a, b));
            //    thread.Start();
            //    c++;
            //} while (c<countOfThreads);

            //N4 and N5
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //StreamWriter writer = new StreamWriter("res.txt");
            //
            //Thread threadFindMax = new Thread(FindMax);
            //threadFindMax.Start();
            //writer.WriteLine(threadFindMax);
            //
            //Thread threadFindMin = new Thread(FindMin);
            //threadFindMin.Start();
            //writer.WriteLine(threadFindMin);
            //
            //Thread threadFindAverage = new Thread(FindAverage);
            //threadFindAverage.Start();
            //writer.WriteLine(threadFindAverage);
            //
            //string content = writer.ToString();
            //File.WriteAllText(path, content);

            //N6

        }
    }
}
