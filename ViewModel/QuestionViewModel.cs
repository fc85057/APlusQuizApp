using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using APlusQuizApp.Model;
using APlusQuizApp.Utility;
using APlusQuizApp.Service;

namespace APlusQuizApp.ViewModel
{
    class QuestionViewModel : ViewModelBase
    {

        private List<Question> questionList;
        private Question currentQuestion;
        private int currentQuestionInt;
        private Grader grader = new Grader();

        public MainWindowViewModel ParentWindow;

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }

        public ICommand SubmitCommand { get; set; }

        public void LoadCommands()
        {
            NextCommand = new RelayCommand(LoadNextQuestion, CanLoadNextQuestion);
            PreviousCommand = new RelayCommand(LoadPreviousQuestion, CanLoadPreviousQuestion);
            SubmitCommand = new RelayCommand(SubmitAnswers, CanSubmit);
        }
        

        public bool CanLoadNextQuestion(object obj)
        {
            
            return CurrentQuestionInt < (QuestionList.Count - 1);
            
        }

        public void LoadNextQuestion(object obj)
        {
            CurrentQuestionInt += 1;
            CurrentQuestion = QuestionList[CurrentQuestionInt];
        }

        public bool CanLoadPreviousQuestion(object obj)
        {
            return CurrentQuestionInt > 0;
        }

        public void LoadPreviousQuestion(object obj)
        {
            CurrentQuestionInt -= 1;
            CurrentQuestion = QuestionList[CurrentQuestionInt];
        }

        public bool CanSubmit(object obj)
        {
            foreach (Question question in QuestionList)
            {
                bool isAnswered = false;
                foreach (Answer answer in question.Answers)
                {
                    if (answer.IsSelected)
                    {
                        isAnswered = true;
                    }
                }
                if (!isAnswered)
                {
                    return false;
                }
            }
            return true;
        }

        public void SubmitAnswers(object obj)
        {
            int score = grader.GradeTest(QuestionList);
            ParentWindow.LoadResultVM(QuestionList, score);
        }

        public List<Question> QuestionList
        {
            get
            {
                return questionList;
            }
            set
            {
                questionList = value;
                RaisePropertyChanged("QuestionList");
            }
        }

        public int CurrentQuestionInt
        {
            get
            {
                return currentQuestionInt;
            }
            set
            {
                if (value >= 0 && value < QuestionList.Count)
                {
                    currentQuestionInt = value;
                }
            }
        }

        public QuestionViewModel(MainWindowViewModel parentWindow, List<Question> questions)
        {
            ParentWindow = parentWindow;
            QuestionList = questions;
            CurrentQuestion = questions[0];
            CurrentQuestionInt = 0;
            LoadCommands();
        }

        public Question CurrentQuestion
        { get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
                RaisePropertyChanged("CurrentQuestion");
                RaisePropertyChanged("QuestionText");
                RaisePropertyChanged("Answers");
            }
        }

        public string QuestionText
        {
            get
            {
                return CurrentQuestion.QuestionText;
            }
            set
            {
                QuestionText = CurrentQuestion.QuestionText;
                RaisePropertyChanged("QuestionText");
            }
        }

        public List<Answer> Answers
        {
            get
            {
                return CurrentQuestion.Answers;
            }
            set
            {
                Answers = CurrentQuestion.Answers;
                RaisePropertyChanged("Answers");
            }
        }



    }
}
