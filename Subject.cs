using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemConsoleApp
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; private set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam()
        {
            Console.WriteLine("Choose The Type Of Exam You Want To Create:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            Console.Write("Enter Your Choice (1 or 2): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid Choice. Please Enter Either 1 || 2.");
                Console.Write("Enter Your Choice (1 or 2): ");
            }

            if (choice == 1)
            {
                Console.Write("Enter The Estemated Time Of The Exam In Minutes: ");
                int timeInMinutes;
                while (!int.TryParse(Console.ReadLine(), out timeInMinutes) || timeInMinutes <= 0)
                {
                    Console.WriteLine("Invalid Input. Please Enter A Positive Integer.");
                    Console.Write("Enter The Estimated Time Of The Exam In Minutes: ");
                }

                Console.Write("Enter The Number Of Questions For The Exam: ");
                int numberOfQuestions;
                while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid Input. Please Enter A Positive Integer.");
                    Console.Write("Enter The Number Of Questions For The Exam: ");
                }
                Console.Clear();

                Exam = new FinalExam
                {
                    Time = DateTime.Now,
                    NumberOfQuestions = numberOfQuestions,
                    AssociatedSubject = this,

                };

                ((FinalExam)Exam).AddQuestions();
            }
            else if (choice == 2)
            {
                Console.Write("Enter The Estimated Time Of The Exam In Minutes: ");
                int timeInMinutes;
                while (!int.TryParse(Console.ReadLine(), out timeInMinutes) || timeInMinutes <= 0)
                {
                    Console.WriteLine("Invalid Input. Please Enter A Positive Integer.");
                    Console.Write("Enter The Estimated Time Of The Exam In Minutes: ");
                }

                Console.Write("Enter The Number Of Questions For The Exam: ");
                int numberOfQuestions;
                while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid Input. Please Enter A Positive Integer.");
                    Console.Write("Enter The Number Of Questions For The Exam: ");
                }
                Console.Clear();

                Exam = new PracticalExam
                {
                    Time = DateTime.Now,
                    NumberOfQuestions = numberOfQuestions,
                    AssociatedSubject = this
                };

                ((PracticalExam)Exam).AddQuestions();
            }
        }
    }


}
