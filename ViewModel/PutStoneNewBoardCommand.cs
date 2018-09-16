using DataStructures;
using System;
using System.Windows.Input;

namespace ViewModel
{
    public class PutStoneNewBoardCommand : ICommand
    {
        public BoardViewModel BoardView { get; set; }

        public PutStoneNewBoardCommand(BoardViewModel boardview)
        {
            this.BoardView = boardview;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return BoardView.game.IsValidMove((Vector2D)parameter);

        }

        public void Execute(object parameter)
        {
            BoardView.game = BoardView.game.PutStone((Vector2D)parameter);
            BoardView.NotifyElement();
        }
    }
}
