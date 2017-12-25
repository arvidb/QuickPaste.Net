using QuickPaste.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPaste.Net.Mocks
{
    public class DesignTrayViewModel
    {
        public IEnumerable<PasteItem> PasteItems => new List<PasteItem>()
        {
            new PasteItem() { Name = "Test 1", Value = "Test 1 Value" },
            new PasteItem() { Name = "Test 2", Value = "Test 2 Value" },
            new PasteItem() { Name = "Test 3", Value = "Test 3 Value" },
        };
    }
}
