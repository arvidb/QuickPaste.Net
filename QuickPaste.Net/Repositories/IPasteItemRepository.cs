using System.Collections.Generic;
using QuickPaste.Net.Models;
using QuickPaste.Net.ViewModels;

namespace QuickPaste.Net
{
    public interface IPasteItemRepository
    {
        IEnumerable<PasteItem> GetItems();

        void AddItem(PasteItem item);
        void RemoveItem(PasteItem item);
        void SaveItems();
    }
}