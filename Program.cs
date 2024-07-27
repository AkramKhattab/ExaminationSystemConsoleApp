using System.Diagnostics;

namespace ExaminationSystemConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C#");
            sub1.CreateExam();
            Console.Clear();
            Console.Write("Start The Exam ? (Y/N): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub1.Exam.ShowExam();
                Console.WriteLine($"GOOD LUCK , Your Time Is: {sw.Elapsed}");
            }
        }
    }
}
