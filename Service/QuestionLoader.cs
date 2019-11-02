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

        public List<Question> LoadQuestions(bool include901, bool include902, bool include1001, bool include1002)
        {

            string questionsText = "";
            string correctAnswerText = "";

            if (include1001)
            {
                questionsText += File.ReadAllText("Questions\\1001_questions.txt");
                correctAnswerText += File.ReadAllText("Questions\\1001_answer_key.txt");
            }

            if (include1002)
            {
                questionsText += "\r\n\r\n" + File.ReadAllText("Questions\\1002_questions.txt");
                correctAnswerText += "\r\n\r\n" + File.ReadAllText("Questions\\1001_answer_key.txt");
            }

            Regex questionRegex = new Regex(@"CompTIA.*?\r\n\r\n", RegexOptions.Singleline);

            foreach (Match questionMatch in questionRegex.Matches(questionsText))
            {
                Question question = new Question(questionMatch.Value);
                LoadCorrectAnswer(question, correctAnswerText);
                LoadAnswers(question, questionMatch.Value);
                questions.Add(question);
            }

            questions = RandomizeQuestions(questions);

            return questions;
        }

        private void LoadAnswers(Question question, string questionText)
        {
            Regex answerRegex = new Regex(@"[A-H]\..*?\r\n");

            foreach (Match answerMatch in answerRegex.Matches(questionText))
            {

                // need to figure out multiple answer questions

                Answer answer = new Answer(answerMatch.Value);
                string answerLetter = (answerMatch.Value)[0].ToString();
                if (question.CorrectAnswer.Contains(answerLetter))
                {
                    answer.IsCorrect = true;
                }
                question.Answers.Add(answer);
            }
        }

        private void LoadCorrectAnswer(Question question, string textToSearch)
        {
            question.CorrectAnswer = Regex.Match(textToSearch, question.Id + @"\r\n.*?: ([A-Z]+)").Groups[1].Value;
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
