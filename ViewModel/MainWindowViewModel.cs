using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APlusQuizApp.View;
using APlusQuizApp.Model;

namespace APlusQuizApp.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        public MainMenuViewModel mainMenuVm;
        public QuestionViewModel questionVm;

        public MainWindowViewModel()
        {
            mainMenuVm = new MainMenuViewModel(this);
            // questionVm = new QuestionViewModel();

            CurrentViewModel = mainMenuVm;

        }

        private object currentViewModel;
        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    RaisePropertyChanged("CurrentViewModel");
                }
            }
        }

        public void LoadQuestionVM(List<Question> questions)
        {
            questionVm = new QuestionViewModel(questions);
            CurrentViewModel = questionVm;
        }

    }
}