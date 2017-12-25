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

        private readonly IPasteItemRepository _pasteItemRepo;

        public ICommand ItemClickCommand { get; }
        public ICommand ReloadCommand { get; }

        public IEnumerable<PasteItem> PasteItems => _pasteItemRepo.GetItems().ToList();

        public TrayPopupViewModel(IPasteItemRepository pasteItemRepo)
        {
            _pasteItemRepo = pasteItemRepo;

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
