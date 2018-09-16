using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OptionsViewModel : Observable
    {
        public StartScreenViewModel StartScreen = new StartScreenViewModel();
        public OptionsViewModel()
        {
            StartScreen.SetOptions(this);
            this.OptionPanes = new List<object> {
                new OptionsCategory(StartScreen),
            };
            this.SelectedOptionPane = OptionPanes.First();
        }


        public List<object> OptionPanes { get; private set; }
        public object SelectedOptionPane
        {
            get
            {
                return _selectedOptionPane;
            }
            set
            {
                _selectedOptionPane = value;
                OnPropertyChanged(nameof(SelectedOptionPane));
            }
        }
        private object _selectedOptionPane;

        public class OptionsCategory
        {
            public OptionsCategory(object vm)
            {
                this.ViewModel = vm;
            }
            public object ViewModel { get; private set; }
            public string Name { get; private set; }
            public override string ToString()
            {
                return Name;
            }
        }

        public void Reset()
        {
            StartScreen = new StartScreenViewModel();
            StartScreen.SetOptions(this);
            this.OptionPanes = new List<object> {
                new OptionsCategory(StartScreen),
            };
            this.SelectedOptionPane = OptionPanes.First();
        }
    }
}
