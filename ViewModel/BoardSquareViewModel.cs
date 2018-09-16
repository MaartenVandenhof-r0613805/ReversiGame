using DataStructures;
using Model.Reversi;
using System;
using System.ComponentModel;

namespace ViewModel
{
    public class BoardSquareViewModel : INotifyPropertyChanged
    {
        private Player _owner;
        public Player Owner
        {
            get { return _owner; }
            set { _owner = value; OnPropertyChanged("Owner"); }
        }
        public String Text { get; set; }

        public ReversiGame game { get; set; }
        public Vector2D PositionSquare { get; set; }


        public BoardSquareViewModel(ReversiGame game)
        {
            this.game = game;
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
