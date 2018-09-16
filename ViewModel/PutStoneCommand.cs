using Model.Reversi;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModel
{
    public class PutStoneCommand : ICommand
    {
        public BoardSquareViewModel Square { get; set; }
        private ReversiGame Game { set; get; }
        public PutStoneCommand(BoardSquareViewModel square, ReversiGame game)
        {
            
            this.Square = square;
            this.Game = game;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (Square.game.IsValidMove(Square.PositionSquare))
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Debug.WriteLine(parameter);
            Square.Owner = Game.CurrentPlayer;
            Square.game = Game.PutStone(Square.PositionSquare);

        }
    }
}
