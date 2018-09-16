using Model.Reversi;
using System.Collections.Generic;

namespace ViewModel
{
    public class BoardRowViewModel 
    {
        public List<BoardSquareViewModel> Squares { get; set; }
        private ReversiGame Game { set; get; }
        private int width = 0;

        public BoardRowViewModel(ReversiGame Game)
        {
            this.Game = Game;
            this.Squares = new List<BoardSquareViewModel>();
        }

      
        public void SetWidth(int w)
        {
            this.width = w;
            for (int i =0; i < width; i++)
            {
                var square = new BoardSquareViewModel(Game);
                square.Text = i.ToString();
                Squares.Add(square);
            }
        }
    }
}
