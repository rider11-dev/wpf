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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window();
            win.Width = 600;
            win.Height = 300;
            win.Title = "动态加载xaml";
            DependencyObject rootEle;
            using (var fs = new FileStream("xaml.xml", FileMode.Open))
            {
                rootEle = (DependencyObject)XamlReader.Load(fs);
            }
            win.Content = rootEle;
            Button btn = null;
            //btn = (Button)((FrameworkElement)rootEle).FindName("button1");
            btn = (Button)LogicalTreeHelper.FindLogicalNode(rootEle, "button1");
            btn.Click += Btn_Click;
            win.ShowDialog();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("谢谢");
        }

        private void element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var ele = (FrameworkElement)sender;
            lstBox.Items.Add($"MouseUp=>{ele.GetType()},{ele.Name}");
        }

        private void element_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var ele = (FrameworkElement)sender;
            lstBox.Items.Add($"PreviewMouseUp=>{ele.GetType()},{ele.Name}");
            //Manipulation
        }

        private void btnDrag_Click(object sender, RoutedEventArgs e)
        {
            new DragAndDrop().ShowDialog();

        }

        private void btnCmd_Click(object sender, RoutedEventArgs e)
        {
            new WinCmdTest().ShowDialog();
        }

        private void btnBehavior_Click(object sender, RoutedEventArgs e)
        {
            new BehaviorTest().ShowDialog();
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            new PathTest().ShowDialog();
        }
    }
}
