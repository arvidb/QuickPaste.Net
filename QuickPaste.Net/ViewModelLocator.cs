using QuickPaste.Net.ViewModels;
using QuickPaste.Net.ViewModels.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPaste.Net
{
    internal class ViewModelLocator
    {
        public MainViewModel MainViewModel => Bootstrapper.Resolve<MainViewModel>();
        public PropertiesViewModel PropertiesViewModel => Bootstrapper.Resolve<PropertiesViewModel>();
        public TrayPopupViewModel TrayPopupViewModel => Bootstrapper.Resolve<TrayPopupViewModel>();
    }
}
