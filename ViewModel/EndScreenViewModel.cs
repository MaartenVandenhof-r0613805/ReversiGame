using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EndScreenViewModel
    {
        public String Winner { get; set; }
        private OptionsViewModel Options { get; set; }
        public RestartCommand RestartCommand { get; set; }
        public String WinnerClass { get; set; }

        public EndScreenViewModel(String winner, String winnerClass, OptionsViewModel options)
        {
            if(winner == null)
            {
                this.Winner = "Draw";
                WinnerClass = "Draw";
            } else
            {
                this.Winner = winner;
                WinnerClass = winnerClass;
            }
            this.Options = options;
            this.RestartCommand = new RestartCommand(Options);
        }
    }
}
