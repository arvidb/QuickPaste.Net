using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuickPaste.Net.Helpers;
using QuickPaste.Net.Windows;

namespace QuickPaste.Net.ViewModels
{
    public class MainViewModel
    {
        public ICommand OpenPropertiesCommand { get; }

        public MainViewModel()
        {
            OpenPropertiesCommand = new RelayCommand(OpenProperties);
        }

        private void OpenProperties()
        {
            var win = new PropertiesWindow
            {
                DataContext = Bootstrapper.Resolve<PropertiesViewModel>()
            };
            win.ShowDialog();
        }
    }
}
