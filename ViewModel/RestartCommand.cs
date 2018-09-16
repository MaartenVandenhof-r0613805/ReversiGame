using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static ViewModel.OptionsViewModel;

namespace ViewModel
{
    public class RestartCommand : ICommand
    {
        public OptionsViewModel Options { get; set; }
        public event EventHandler CanExecuteChanged;

        public RestartCommand(OptionsViewModel options)
        {
            this.Options = options;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Options.Reset();
        }
    }
}
