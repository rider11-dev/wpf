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

namespace WpfApplication2.Pages
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            this.WindowTitle = "没有对窗口尺寸进行配置";
        }

        public Page1(double width, double height, double hostWidth, double hostHeight)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.WindowWidth = hostWidth;
            this.WindowHeight = hostHeight;

            this.WindowTitle = "设置了窗口尺寸";

            this.lblInfo.Content = string.Format("Width = {1}{0}Height = {2}{0} WindowWidth = {3}{0} WindowHeight = {4}{0}",
                Environment.NewLine, width, height, hostWidth, hostHeight);
        }
    }
}
