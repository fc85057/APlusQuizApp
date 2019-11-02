using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using APlusQuizApp.Model;
using APlusQuizApp.Utility;

namespace APlusQuizApp.ViewModel
{
    class ResultViewModel : ViewModelBase
    {
        private List<Question> questions;

        public MainWindowViewModel ParentWindow;

        public int Score { get; set; }
        public ICommand LoadMenuCommand { get; set; }

        public List<Question> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
                RaisePropertyChanged("Questions");
            }
        }

        private void LoadCommands()
        {
            LoadMenuCommand = new RelayCommand(LoadMainMenu, CanLoadMainMenu);
        }

        public ResultViewModel(MainWindowViewModel parentWindow, List<Question> questions, int score)
        {
            ParentWindow = parentWindow;
            Questions = questions;
            Score = score;
            LoadCommands();
        }

        public bool CanLoadMainMenu(object obj)
        {
            return true;
        }

        public void LoadMainMenu(object obj)
        {
            ParentWindow.CurrentViewModel = new MainMenuViewModel(ParentWindow);
        }

    }
}
