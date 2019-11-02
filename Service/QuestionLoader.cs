using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APlusQuizApp.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace APlusQuizApp.Service
{
    class QuestionLoader
    {

        public List<Question> questions = new List<Question>();
        int NumberOfQuestions;

        public QuestionLoader(int numberOfQuestions)
        {
            NumberOfQuestions = numberOfQuestions;
        }

        public List<Question> LoadQuestions()
        {
            string questionsText = File.ReadAllText("Questions\\1001_questions.txt");
            Regex questionRegex = new Regex(@"CompTIA.*?\r\n\r\n", RegexOptions.Singleline);
            foreach (Match questionMatch in questionRegex.Matches(questionsText))
            {
                Question question = new Question(questionMatch.Value);
                questions.Add(question);
            }

            questions = RandomizeQuestions(questions);

            return questions;
        }

        private List<Question> RandomizeQuestions(List<Question> questionsToRandomize)
        {
            List<Question> randomizedQuestions = new List<Question>();
            
            Random random = new Random();

            var randomNumbers = Enumerable.Range(0, questionsToRandomize.Count).OrderBy(x => random.Next()).Take(NumberOfQuestions).ToList();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                randomizedQuestions.Add(questionsToRandomize[randomNumbers[i]]);
            }

            return randomizedQuestions;
        }

    }
}
