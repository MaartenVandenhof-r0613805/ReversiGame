using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using DataStructures;
using Model.Reversi;
using static ViewModel.OptionsViewModel;

namespace ViewModel
{

    public class BoardViewModel : Observable
    {
        private List<BoardRowViewModel> _rows;
        public List<BoardRowViewModel> Rows
        {
            set { _rows = value; }
            get { return _rows; }
        }
        private String _currentPlayer;
        public String CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                if (value.Equals("W")){
                    _currentPlayer = "White";
                }
                else
                {
                    _currentPlayer = "Black";
                }
                OnPropertyChanged("CurrentPlayer");
            }
        }
        public int _blackStones;
        public int BlackStones
        {
            get {return _blackStones; }
            set { _blackStones = value; OnPropertyChanged("BlackStones"); }
        }
        public int _whiteStones;
        public int WhiteStones
        {
            get { return _whiteStones; }
            set { _whiteStones = value; OnPropertyChanged("WhiteStones"); }
        }
        private String _winner;
        public String Winner
        {
            get { return this._winner; }
            set { this._winner = value; OnPropertyChanged(nameof(Winner)); }
        }
        public ReversiBoard Board { get; set; }
        public ReversiGame game { get; set; }
        public PutStoneNewBoardCommand Command{get; set;}
        public PlayMusicCommand PlayMusic { get; set; }
        public EndGameCommand EndGame { get; set; }
        private OptionsViewModel Options { get; set; }


        private String _blackPlayer;
        public String BlackPlayer {
            get { return _blackPlayer; }
            set { if(value == null) { _blackPlayer = Player.BLACK.ToString();  }
                else { _blackPlayer = value; }
            }
        }

        private String _whitePlayer;
        public String WhitePlayer
        {
            get { return _whitePlayer; }
            set
            {
                if (value == null) { _whitePlayer = Player.WHITE.ToString(); }
                else { _whitePlayer = value; }
            }
        }
        private String _winnerClass;
        public String WinnerClass {
            get { return _winnerClass; }
            set { _winnerClass = value; OnPropertyChanged(nameof(WinnerClass)); }
        }

        /// <summary>
        /// Constructor
        /// Initializes varables
        /// </summary>
        public BoardViewModel(ReversiBoard board, OptionsViewModel options)
        {
            
            this.Rows = new List<BoardRowViewModel>();
            this.Board = board;
            this.game = new ReversiGame(board.Width, board.Height);
            
            for (int f = 0; f < board.Height; f++)
            {
                var boardRow = new BoardRowViewModel(game);
                boardRow.SetWidth(board.Width);
                for (int s = 0; s < board.Width; s++)
                {
                    boardRow.Squares[s].Owner = game.Board[new Vector2D(s, f)];
                    boardRow.Squares[s].PositionSquare = new Vector2D(s, f);
                }
                Rows.Add(boardRow);
            }
            this.CurrentPlayer = game.CurrentPlayer.ToString();
            this.BlackStones = game.Board.CountStones(Player.BLACK);
            this.WhiteStones = game.Board.CountStones(Player.WHITE);
            
            this.PlayMusic = new PlayMusicCommand(new MediaPlayer());
            this.Options = options;
            this.EndGame = new EndGameCommand(this, Options);
            
            this.BlackPlayer = Options.StartScreen.NameBlack;
            this.WhitePlayer = Options.StartScreen.NameWhite;
            SetWinner();
            this.Command = new PutStoneNewBoardCommand(this);
        }

        
        /// <summary>
        /// Updates variables
        /// </summary>
        public void NotifyElement()
        {
            this.BlackStones = game.Board.CountStones(Player.BLACK);
            this.WhiteStones = game.Board.CountStones(Player.WHITE);
            
            this.Board = game.Board;
            for (int f = 0; f < Board.Height; f++)
            {
                for (int s = 0; s < Board.Width; s++)
                {
                    Rows[f].Squares[s].Owner = game.Board[new Vector2D(s,f)];
                }
            }

            if(!this.game.IsGameOver)
            {
                this.CurrentPlayer = game.CurrentPlayer.ToString();
                SetWinner();
            }
            else
            {
                SetWinner();
                Options.SelectedOptionPane = new OptionsCategory(new EndScreenViewModel(Winner, WinnerClass, Options));
            }

            
        }

        private void SetWinner()
        {
            if (BlackStones > WhiteStones)
            {
                WinnerClass = Player.BLACK.ToString();
                this.Winner = BlackPlayer.ToString();
                
            }
            else if (BlackStones < WhiteStones)
            {
                WinnerClass = Player.WHITE.ToString();
                this.Winner = WhitePlayer.ToString();
                
            }
            else if (BlackStones == WhiteStones)
            {
                WinnerClass = "Draw";
                this.Winner = "Draw";
                
            }
            Debug.WriteLine(WinnerClass);
        }
    }
}
