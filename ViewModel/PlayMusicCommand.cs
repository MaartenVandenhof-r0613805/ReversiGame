using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ViewModel
{
    public class PlayMusicCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MediaPlayer Player { get; set; }
        private Boolean Playing { get; set; }

        public PlayMusicCommand(MediaPlayer player)
        {
            this.Player = player;
            Player.Open(new Uri(@"C:\Users\Maarten Van den hof\OneDrive\School\UCLL TI\Semester 4\VGO\reversi-MaartenVandenhof-r0613805\reversi-MaartenVandenhof-r0613805\Model\Music\Music.mp3"));
            Playing = false;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (Playing)
            {
                Player.Pause();
                Playing = false;
            }
            else
            {
                Player.Play();
                Playing = true;
            }
        }
    }
}
