using Model.Reversi;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace ViewModel
{
    public class EasyCommand : ICommand
    {
        public OptionsViewModel Options { get; set; }
        private StartScreenViewModel StartScreen { get; set; }

        public EasyCommand(OptionsViewModel options, StartScreenViewModel StartScreen)
        {
            this.Options = options;
            this.StartScreen = StartScreen;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BoardViewModel b;
            try
            {
                b = new BoardViewModel(ReversiBoard.CreateInitialState(StartScreen.Width, StartScreen.Height), Options);
            }
            catch (Exception)
            {
                b = new BoardViewModel(ReversiBoard.CreateInitialState(6, 6), Options);
            }
            Debug.WriteLine("Heigt= " + b.Board.Height);
            Debug.WriteLine("Width= " + b.Board.Width);
            Options.SelectedOptionPane = new OptionsViewModel.OptionsCategory(b);
        }
    }
}
