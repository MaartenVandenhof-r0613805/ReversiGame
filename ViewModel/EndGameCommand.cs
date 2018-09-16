using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static ViewModel.OptionsViewModel;

namespace ViewModel
{
    public class EndGameCommand : ICommand
    {
        private BoardViewModel BoardView { get; set; }
        private OptionsViewModel Options { get; set; }
        
        public event EventHandler CanExecuteChanged;

        public EndGameCommand(BoardViewModel boardView, OptionsViewModel options)
        {
            this.BoardView = boardView;
            this.Options = options;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Options.SelectedOptionPane = new OptionsCategory(new EndScreenViewModel(BoardView.Winner, BoardView.WinnerClass, Options));
        }
    }
}
