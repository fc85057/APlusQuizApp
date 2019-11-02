using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using APlusQuizApp.Utility;
using APlusQuizApp.Service;
using APlusQuizApp.Model;
using System.Windows;

namespace APlusQuizApp.ViewModel
{
    class MainMenuViewModel : ViewModelBase
    {

        private int numberOfQuestions;
        private List<Question> questions;
        private bool include901;
        private bool include902;
        private bool include1001;
        private bool include1002;

        public MainWindowViewModel ParentWindow;
        QuestionLoader QuestionService;
        
        public int NumberOfQuestions
        {
            get
            {
                return numberOfQuestions;
            }
            set
            {
                if (!(value < 1 | value > 50))
                {
                    numberOfQuestions = value;
                }
            }
        }

        public bool Include901
        {
            get
            {
                return include901;
            }
            set
            {
                include901 = value;
                RaisePropertyChanged("Include901");
            }
        }

        public bool Include902
        {
            get
            {
                return include902;
            }
            set
            {
                include902 = value;
                RaisePropertyChanged("Include901");
            }
        }

        public bool Include1001
        {
            get
            {
                return include1001;
            }
            set
            {
                include1001 = value;
                RaisePropertyChanged("Include901");
            }
        }

        public bool Include1002
        {
            get
            {
                return include1002;
            }
            set
            {
                include1002 = value;
                RaisePropertyChanged("Include901");
            }
        }

        public MainMenuViewModel(MainWindowViewModel parentWindow)
        {
            ParentWindow = parentWindow;
            LoadCommands();
        }

        public ICommand StartCommand { get; set;  }

        public void LoadCommands()
        {
            StartCommand = new RelayCommand(StartQuiz, CanStartQuiz);
        }
        

        private Boolean CanStartQuiz(object obj)
        {
            return ((NumberOfQuestions > 0 && NumberOfQuestions < 50)&(Include901||Include902||Include1001||Include1002));
        }

        private void StartQuiz(object obj)
        {
            QuestionService = new QuestionLoader(NumberOfQuestions);
            questions = QuestionService.LoadQuestions(Include901, Include902, Include1001, Include1002);
            ParentWindow.LoadQuestionVM(questions);
        }

    }
}
