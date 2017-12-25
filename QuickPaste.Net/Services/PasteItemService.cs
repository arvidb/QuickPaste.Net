using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickPaste.Net.Models;
using QuickPaste.Net.ViewModels;
using QuickPaste.Net.Common;

namespace QuickPaste.Net
{
    public class PasteItemService : IPasteItemService
    {
        private IList<PasteItem> PasteItems { get; } = new List<PasteItem>();
        
        public PasteItemService()
        {
            if (File.Exists(Constants.DataStorePath))
            {
                var storedData = File.ReadAllText(Constants.DataStorePath);
                PasteItems = JsonConvert.DeserializeObject<List<PasteItem>>(storedData);
            }
        }

        public void SaveItems()
        {
            (new FileInfo(Constants.DataStorePath)).Directory.Create();

            File.WriteAllText(Constants.DataStorePath, JsonConvert.SerializeObject(PasteItems));
        }

        public IEnumerable<PasteItem> GetItems() => PasteItems;

        public void AddItem(PasteItem item) => PasteItems.Add(item.Clone() as PasteItem);

        public void RemoveItem(PasteItem item) => PasteItems.Remove(item);
    }
}
