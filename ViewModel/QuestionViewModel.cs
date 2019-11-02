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

namespace APlusQuizApp.ViewModel
{
    class QuestionViewModel : ViewModelBase
    {

        private List<Question> questionList;
        private Question currentQuestion;
        private int currentQuestionInt;
        private string questionText;
        private IList<ItemsPresenter> test;

        public IList<ItemsPresenter> Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                RaisePropertyChanged("Test");
            }
        }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }

        public void LoadCommands()
        {
            NextCommand = new RelayCommand(LoadNextQuestion, CanLoadNextQuestion);
            PreviousCommand = new RelayCommand(LoadPreviousQuestion, CanLoadPreviousQuestion);
        }
        

        public bool CanLoadNextQuestion(object obj)
        {
            
            return CurrentQuestionInt < (QuestionList.Count - 1);
            
        }

        public void LoadNextQuestion(object obj)
        {
            MessageBox.Show(Test.ToString());
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

        public QuestionViewModel(List<Question> questions)
        {
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

        public List<string> Answers
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
