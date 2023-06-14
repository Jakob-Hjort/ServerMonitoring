using System; 
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Moderndesign.Core
{
    internal class ObersvableObjects : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
