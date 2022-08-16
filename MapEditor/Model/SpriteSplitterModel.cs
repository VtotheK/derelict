using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public class SpriteSplitterModel : ObservableObject
    {
        private string _filepath;
        public string FilePath
        {
            get { return _filepath; }
            set
            {
                FilePath = value;
                OnPropertyChanged(ref _filepath, value);
            }
        }
    }
}
