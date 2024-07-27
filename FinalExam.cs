using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemConsoleApp
{
    public enum QuestionType
    {
        TrueFalse = 1,
        MultipleChoice = 2
    }
    public class FinalExam : Exam
    {
        public int ExamTimeInMinutes { get; set; }
        public QuestionType QuestionType { get; set; }
        private TrueFalseQuestion CreateTrueFalseQuestion()
        {
            Console.WriteLine("Enter The Body Of The True/False Question:");
            string body = Console.ReadLine();
            Console.Write("Enter The Mark For The Question: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
            {Console.WriteLine("Invalid Input. Please Enter a Positive Integer For The Mark.");
                Console.Write("Enter The Mark For The Question: ");}
            Console.WriteLine("Enter The Correct Answer (1 for True | 2 for False): ");
            int correctAnswer;
            while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2))
            {Console.WriteLine("Invalid Input. Please Enter 1 For True || 2 for False.");
                Console.Write("Enter The Correct Answer (1 for True || 2 for False): ");}
            bool isTrue = correctAnswer == 1;
            TrueFalseQuestion tfQuestion = new TrueFalseQuestion
            {Header = "True/False Question",
                Body = body,
                Mark = mark,
                CorrectAnswer = isTrue};
            return tfQuestion;
        }
        private MCQQuestion CreateMultipleChoiceQuestion()
        {
            Console.WriteLine("Enter The Body Of The Multiple Choice Question (MCQ):");
            string body = Console.ReadLine();
            Console.Write("Enter The Mark For The Question: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
            {Console.WriteLine("Invalid Input. Please Enter a Positive Integer For The Mark.");
                Console.Write("Enter The Mark For The Question: ");}
            Console.WriteLine("Enter The Number Of Choices For The Question:");
            int numChoices;
            while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
            {Console.WriteLine("Invalid Input. Please Enter a Positive Integer For The Number Of Choices.");
                Console.Write("Enter The Number Of Choices For The Question:");}
            List<string> choices = new List<string>();
            for (int i = 0; i < numChoices; i++)
            {Console.Write($"Enter Choice {i + 1}: ");
                choices.Add(Console.ReadLine());}
            Console.Write("Enter The Number Of The Correct Choice: ");
            int correctIndex;
            while (!int.TryParse(Console.ReadLine(), out correctIndex) || correctIndex < 1 || correctIndex > numChoices)
            {Console.WriteLine($"Invalid Input. Please Enter An Integer Between 1 And {numChoices}.");
                Console.Write("Enter The Number Of The Correct Choice: ");}
            MCQQuestion mcqQuestion = new MCQQuestion
            {Header = "Multiple Choice Question",
                Body = body,
                Mark = mark,
                Choices = choices,
                CorrectChoiceIndex = correctIndex - 1};
            return mcqQuestion;
        }
        public void AddQuestions()
        {
            Console.WriteLine($"Adding {NumberOfQuestions} Questions To The Final Exam:");

            for (int i = 0; i < NumberOfQuestions; i++)
            {Console.WriteLine($"\nQuestion {i + 1}:");
                Console.WriteLine("Choose The Type Of Question To Include:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. Multiple Choice");
                Console.Write("Enter your choice (1 or 2): ");
                int questionType;
                while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                {Console.WriteLine("Invalid Choice. Please Enter 1 || 2.");
                    Console.Write("Enter Your Choice (1 || 2): ");}
                Console.Clear();
                if (questionType == 1)
                {TrueFalseQuestion tfQuestion = CreateTrueFalseQuestion();
                    Questions.AddQuestion(tfQuestion);
                    Console.WriteLine("Added True/False Question:");
                    Console.WriteLine($"Body: {tfQuestion.Body}");
                    Console.WriteLine($"Mark: {tfQuestion.Mark}");
                    Console.WriteLine($"Correct Answer: {(tfQuestion.CorrectAnswer ? "True" : "False")}");}
                else if (questionType == 2)
                {MCQQuestion mcqQuestion = CreateMultipleChoiceQuestion();
                    Questions.AddQuestion(mcqQuestion);
                    Console.WriteLine($"Added Multiple Choice Question (MCQ):");
                    Console.WriteLine($"Body: {mcqQuestion.Body}");
                    Console.WriteLine($"Mark: {mcqQuestion.Mark}");
                    Console.WriteLine("Choices:");
                    foreach (var choice in mcqQuestion.Choices)
                    {Console.WriteLine(choice);}
                    Console.WriteLine($"Correct Choice Number: {mcqQuestion.CorrectChoiceIndex + 1}");}
                    Console.Clear();
            }
        }
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("Final Exam:");
            Console.WriteLine("");
            int totalGrade = 0;
            int totalQuestions = 0;
            List<string> userAnswers = new List<string>();
            foreach (var question in Questions.Questions)
            {if (question is TrueFalseQuestion tfQuestion)
                {Console.WriteLine("--------------------------------------");
                    totalQuestions++;
                    Console.WriteLine($"Question {totalQuestions}: True/False        Mark({tfQuestion.Mark})");
                    Console.WriteLine($"{tfQuestion.Body}");
                    Console.WriteLine("(1-True / 2-False)");
                    Console.WriteLine("--------------------------------------");
                    Console.Write("Your answer (1 or 2): ");
                    int userChoice;
                    while (!int.TryParse(Console.ReadLine(), out userChoice) || (userChoice != 1 && userChoice != 2))
                    {Console.WriteLine("Invalid Input. Please Enter 1 For True || 2 For False.");
                        Console.Write("Your Answer (1 || 2): ");}
                    bool userAnswer = userChoice == 1;
                    bool correctAnswer = tfQuestion.CorrectAnswer;
                    if (userAnswer == correctAnswer)
                    {totalGrade += tfQuestion.Mark;}
                    else
                    {Console.WriteLine($"");}
                    userAnswers.Add($"{tfQuestion.Body}-{(userAnswer ? "True" : "False")}");}
                    else if (question is MCQQuestion mcqQuestion)
                    {Console.WriteLine("=======================================");
                    totalQuestions++;
                    Console.WriteLine($"Question{totalQuestions}: Multiple Choice        Mark({mcqQuestion.Mark})");
                    Console.WriteLine($"{mcqQuestion.Body}");
                    Console.WriteLine("Choices:");
                    for (int i = 0; i < mcqQuestion.Choices.Count; i++)
                    {Console.WriteLine($"{i + 1}. {mcqQuestion.Choices[i]}");}
                    Console.WriteLine("---------------------------------------");
                    Console.Write("Your Choice (1, 2, 3, ...): ");
                    int userChoiceIndex;
                    while (!int.TryParse(Console.ReadLine(), out userChoiceIndex) || userChoiceIndex < 1 || userChoiceIndex > mcqQuestion.Choices.Count)
                    {Console.WriteLine($"Invalid Input. Please Enter a Number Between 1 And {mcqQuestion.Choices.Count}.");
                        Console.Write("Your Choice (1, 2, 3, ...): ");}
                    if (userChoiceIndex - 1 == mcqQuestion.CorrectChoiceIndex)
                    {totalGrade += mcqQuestion.Mark;}
                    else
                    {Console.WriteLine($"");}
                    userAnswers.Add($"{mcqQuestion.Body}-{mcqQuestion.Choices[userChoiceIndex - 1]}  ");}}
                    Console.Clear();
                    Console.WriteLine("Exam Answers");
                    Console.WriteLine("");
                    Console.WriteLine($"Your Total Grades is {totalGrade}");
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Correct Answers:");
                    for (int i = 0; i < Questions.Questions.Count; i++)
                    {var question = Questions.Questions[i];
                        if (question is TrueFalseQuestion tfQuestion)
                        {Console.WriteLine($"Q{i + 1}:  {tfQuestion.Body}-{(tfQuestion.CorrectAnswer ? "True" : "False")}");}
                        else if (question is MCQQuestion mcqQuestion)
                        {Console.WriteLine($"Q{i + 1}:  {mcqQuestion.Body}-{mcqQuestion.Choices[mcqQuestion.CorrectChoiceIndex]} ");}}
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Your Answers:");
                    for (int i = 0; i < userAnswers.Count; i++)
                    {Console.WriteLine($"Q{i + 1}: {userAnswers[i]}");}
        }
    }
}
