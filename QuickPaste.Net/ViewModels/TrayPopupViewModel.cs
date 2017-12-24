using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuickPaste.Net.Helpers;
using QuickPaste.Net.Models;

namespace QuickPaste.Net.ViewModels
{
    public class TrayPopupViewModel : ObservableObject
    {
        public event EventHandler TrayItemExecuted;

        private IPasteItemService _pasteService => Bootstrapper.Resolve<IPasteItemService>();

        public ICommand ItemClickCommand { get; }
        public ICommand ReloadCommand { get; }

        public IEnumerable<PasteItem> PasteItems => _pasteService.GetItems().ToList();

        public TrayPopupViewModel()
        {
            ItemClickCommand = new RelayCommand<PasteItem>(OnItemClicked);
            ReloadCommand = new RelayCommand(Reload);

            RaisePropertyChanged(() => PasteItems);
        }

        private void Reload()
        {
            RaisePropertyChanged(() => PasteItems);
        }

        private void OnItemClicked(PasteItem item)
        {
            Clipboard.SetText(item.Value);
            TrayItemExecuted?.Invoke(this, new EventArgs());
        }
    }
}
