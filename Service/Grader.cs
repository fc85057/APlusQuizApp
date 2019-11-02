using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APlusQuizApp.Model;

namespace APlusQuizApp.Service
{
    class Grader
    {

        public int GradeTest(List<Question> questions)
        {

            int numberOfQuestions = questions.Count;
            int numberOfQuestionsCorrect = 0;
            
            foreach (Question question in questions)
            {
                string selectedAnswers = "";

                foreach (Answer answer in question.Answers)
                {
                    if (answer.IsSelected)
                    {
                        selectedAnswers += answer.AnswerLetter;
                    }
                }

                if (selectedAnswers == question.CorrectAnswer)
                {
                    question.AnsweredCorrectly = true;
                    numberOfQuestionsCorrect++;
                }

            }

            return ((numberOfQuestionsCorrect * 100) / numberOfQuestions);

        }

    }
}
