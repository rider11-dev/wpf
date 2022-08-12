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

namespace WpfApp1
{
    /// <summary>
    /// DragAndDrop.xaml 的交互逻辑
    /// </summary>
    public partial class DragAndDrop : Window
    {
        public DragAndDrop()
        {
            InitializeComponent();
        }

        private void lblSrc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
        }

        private void lbl2_Drop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = e.Data.GetData(DataFormats.Text);
        }
    }
}
