using System;
using QuickPaste.Net.Helpers;

namespace QuickPaste.Net.Models
{
    public class PasteItem : ObservableObject, ICloneable
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        public object Clone()
        {
            return new PasteItem()
            {
                Name = this.Name,
                Value = this.Value
            };
        }
    }
}
