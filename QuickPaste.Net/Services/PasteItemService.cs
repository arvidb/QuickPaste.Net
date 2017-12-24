using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickPaste.Net.Models;
using QuickPaste.Net.ViewModels;

namespace QuickPaste.Net
{
    public class PasteItemService : IPasteItemService
    {
        private IList<PasteItem> PasteItems { get; } = new List<PasteItem>();
        
        private string _dataStorePath => @"data/data.json";

        public PasteItemService()
        {
            if (File.Exists(_dataStorePath))
            {
                var storedData = File.ReadAllText(_dataStorePath);
                PasteItems = JsonConvert.DeserializeObject<List<PasteItem>>(storedData);
            }
        }

        public void SaveItems()
        {
            (new FileInfo(_dataStorePath)).Directory.Create();

            File.WriteAllText(_dataStorePath, JsonConvert.SerializeObject(PasteItems));
        }

        public IEnumerable<PasteItem> GetItems() => PasteItems;

        public void AddItem(PasteItem item) => PasteItems.Add(item.Clone() as PasteItem);

        public void RemoveItem(PasteItem item) => PasteItems.Remove(item);
    }
}
