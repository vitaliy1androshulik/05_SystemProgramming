using System.Text.RegularExpressions;

namespace _05_SystemProgramming
{
    internal class Program
    {
        class Statistic
        {
            public static int Letters { get; set; } = 0;
            public static int Digits { get; set; } = 0;
            public static int Words { get; set; } = 0;
            public static int Lines { get; set; } = 0;
            public static int Punctuations { get; set; } = 0;
        }
        static void Main(string[] args)
        {
            Statistic stat= new Statistic();

            string[] files = Directory.GetFiles("C://Users//Vitaliy//Desktop//test");
            foreach (string file in files) 
            {
                string text = File.ReadAllText(file);
                Thread thread = new Thread(TextAnalyse);
                thread.Start(text);
            }
            Thread.Sleep(2000);
            PrintCounts();

        }
        static void TextAnalyse(object text)
        {
            string pattern = @"\w+";
            string textAnalyze = (string)text;
            //int a = new int();
            lock (typeof(Statistic)) 
            {
                //a = Regex.Matches(textAnalyze, pattern).Count;

                MatchCollection coll = Regex.Matches(textAnalyze, pattern);
                Statistic.Words += coll.Count();

                pattern = @"\w";
                coll = Regex.Matches(textAnalyze, pattern);
                Statistic.Letters += coll.Count();

                pattern = @"\d";
                coll = Regex.Matches(textAnalyze, pattern);
                Statistic.Digits += coll.Count();

                pattern = @"[.!@#$%^&*(),?/]";
                coll = Regex.Matches(textAnalyze, pattern);
                Statistic.Punctuations += coll.Count();

                pattern = @"\n";
                coll = Regex.Matches(textAnalyze, pattern);
                Statistic.Lines += coll.Count()+1;
            }

        }
        static void PrintCounts()
        {
            Console.WriteLine("Words count :: " + Statistic.Words);
            Console.WriteLine("Letters count :: " + Statistic.Letters);
            Console.WriteLine("Digits count :: " + Statistic.Digits);
            Console.WriteLine("Punctuations count :: " + Statistic.Punctuations);
            Console.WriteLine("Lines count :: " + Statistic.Lines);
        }
    }
}
