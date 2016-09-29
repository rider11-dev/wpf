using demo1.Model;
using demo1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SongViewModel _vmSong;
        int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
            _vmSong = (SongViewModel)base.DataContext;
        }

        private void btnUpdateName_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            _vmSong.ArtistName = "新名称" + _count;
        }
    }
}
