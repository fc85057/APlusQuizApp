using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlusQuizApp.Model
{
    class Answer
    {

        public string AnswerText { get; set; }
        public bool IsSelected { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerLetter { get; set; }


        public Answer(string answerText)
        {
            AnswerText = answerText;
            IsSelected = false;
            AnswerLetter = answerText[0].ToString();
        }

    }
}
