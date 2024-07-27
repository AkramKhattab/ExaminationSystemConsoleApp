using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemConsoleApp
{
    public class QuestionList
    {
        public List<QuestionBase> Questions { get; } = new List<QuestionBase>();

        // Method to add a question to the list
        public void AddQuestion(QuestionBase question)
        {
            Questions.Add(question);
        }
    }

}
