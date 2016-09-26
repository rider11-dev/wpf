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
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Window_Property.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Property : Window
    {
        public Window_Property()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Console.WriteLine("actual size:width，{0}；height，{1}", this.ActualWidth, this.ActualHeight);
        }
    }
}
