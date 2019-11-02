using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace APlusQuizApp.Model
{
    class Question
    {

        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public bool AnsweredCorrectly { get; set; }
        public List<Answer> Answers {get; set;}

        public Question(string allText)
        {
            Id = Regex.Match(allText, @"[A-Z]-\d{1,3}").Value;
            QuestionText = Regex.Match(allText, @"^.*?\?.*?\r\n", RegexOptions.Singleline).Value;
            Answers = new List<Answer>();
        }

        

    }
}
