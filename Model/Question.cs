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

        public string Id;
        public string QuestionText;
        public List<string> Answers = new List<string>();
        public string CorrectAnswer;

        public Question(string allText)
        {
            Id = Regex.Match(allText, @"[A-Z]-\d{1,3}").Value;
            QuestionText = Regex.Match(allText, @"^.*?\?.*?\r\n", RegexOptions.Singleline).Value;
            Regex answerRegex = new Regex(@"[A-G]\..*?\r\n");

            foreach (Match answerMatch in answerRegex.Matches(allText))
            {
                Answers.Add(answerMatch.Value);
                Console.WriteLine(answerMatch.Value);
            }
        }

    }
}
