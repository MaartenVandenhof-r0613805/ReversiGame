using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using Model;
using Model.Reversi;
using System.Globalization;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
            this.DataContext = new Navigator();
        }

        
    }

    public class Navigator : INotifyPropertyChanged
    {
        private Screen currentScreen;

        public Navigator()
        {
            this.currentScreen = new ScreenB(this);
        }

        public Screen CurrentScreen
        {
            get
            {
                return currentScreen;
            }
            set
            {
                this.currentScreen = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScreen)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public abstract class Screen
    {
        protected readonly Navigator navigator;

        protected Screen(Navigator navigator)
        {
            this.navigator = navigator;
        }

        protected void SwitchTo(Screen screen)
        {
            this.navigator.CurrentScreen = screen;
        }
    }

    public class ScreenA : Screen
    {
        public ScreenA(Navigator navigator) : base(navigator)
        {
            this.BoardViewModel = new BoardViewModel(ReversiBoard.CreateInitialState(4,4));
        }
        public BoardViewModel BoardViewModel { get; set; }
        public ICommand GoToB { get; }
    }

    public class ScreenB : Screen
    {
        public ScreenB(Navigator navigator) : base(navigator)
        {
            GoToA = new EasyCommand(() => SwitchTo(new ScreenA(navigator)));
            
        }

        public ICommand GoToA { get; }

    }

   

}
