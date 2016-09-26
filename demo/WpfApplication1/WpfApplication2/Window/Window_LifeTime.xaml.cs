using System;
using System.Collections.Generic;
using System.IO;
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
    /// WindowNoContent.xaml 的交互逻辑
    /// </summary>
    public partial class Window_LifeTime : Window
    {
        public Window_LifeTime()
        {
            InitializeComponent();
        }

        private void Notify(string msg)
        {
            //File.AppendAllText("window_lifetime.txt", msg + Environment.NewLine);
            Console.WriteLine(msg);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Notify("Window_ContentRendered");
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            Notify("Window_SourceInitialized");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //Notify("Window_Activated");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Notify("Window_Loaded");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
            Notify("Window_Closing");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Notify("Window_Closed");
        }

    }
}
