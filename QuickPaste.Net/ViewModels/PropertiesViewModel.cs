using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuickPaste.Net.Helpers;
using QuickPaste.Net.Models;

namespace QuickPaste.Net.ViewModels
{
    public class PropertiesViewModel : ObservableObject
    {
        private readonly IPasteItemRepository _pasteItemRepo;

        public ICommand CloseWindowCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }

        public IEnumerable<PasteItem> PasteItems => _pasteItemRepo.GetItems().ToList();

        public PasteItem NewTask { get; set; } = new PasteItem();

        private bool CanAddTask() => !string.IsNullOrEmpty(NewTask.Name) && !string.IsNullOrEmpty(NewTask.Value);

        public PropertiesViewModel(IPasteItemRepository pasteItemRepo)
        {
            _pasteItemRepo = pasteItemRepo;

            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
            AddItemCommand = new RelayCommand(AddTask, CanAddTask);
            RemoveItemCommand = new RelayCommand<PasteItem>(RemoveItem);

            RaisePropertyChanged(() => PasteItems);
        }

        private void RemoveItem(PasteItem obj)
        {
            _pasteItemRepo.RemoveItem(obj);

            RaisePropertyChanged(() => PasteItems);
        }

        private void CloseWindow(Window win)
        {
            _pasteItemRepo.SaveItems();

            win.Close();
        }

        private void AddTask()
        {
            _pasteItemRepo.AddItem(NewTask);

            NewTask = new PasteItem();
            RaisePropertyChanged(() => NewTask);

            RaisePropertyChanged(() => PasteItems);
        }
    }
}
