using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StartScreenViewModel
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public OptionsViewModel Options { get; set; }
        public EasyCommand Command { get; set; }
        public String NameBlack { get; set; }
        public String NameWhite { get; set; }

        public StartScreenViewModel()
        {
         
        }

        public void SetOptions(OptionsViewModel options)
        {
            this.Options = options;
            this.Command = new EasyCommand(Options, this);
        }
    }
}
