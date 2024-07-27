using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemConsoleApp
{    public class TrueFalseQuestion : QuestionBase
    {
        public bool IsTrue { get; set; }
        public int Mark { get; set; }
        public bool CorrectAnswer { get; set; }
        public void SetMark(int mark)
        {Mark = mark;}
        public int GetMark()
        {return Mark;}
        public void SetCorrectAnswer(bool correctAnswer)
        {CorrectAnswer = correctAnswer;}
        public bool IsAnswerCorrect(bool userAnswer)
        {return userAnswer == CorrectAnswer;}
    }
}
