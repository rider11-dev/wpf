using demo1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace demo1.ViewModel
{
    public class AlbumViewModel
    {
        ObservableCollection<Song> _songs = new ObservableCollection<Song>();
    }
}
