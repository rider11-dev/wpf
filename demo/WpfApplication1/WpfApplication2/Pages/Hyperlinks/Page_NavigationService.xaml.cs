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

namespace WpfApplication2.Pages.Hyperlinks
{
    /// <summary>
    /// Page_NavigationService.xaml 的交互逻辑
    /// </summary>
    public partial class Page_NavigationService : Page
    {
        public Page_NavigationService()
        {
            InitializeComponent();
        }

        private void link_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            if (link == link1)
            {
                NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Hyperlinks/Page2.xaml"));
            }
            else if (link == link2)
            {
                NavigationService.Navigate(new Page2("使用NavigationService导航到Page2.xaml"));
            }
            else if (link == link3)
            {
                NavigationService.Navigate(new Uri("pack://application:,,,/Pages/Hyperlinks/Page1.xaml"));
            }
            else if (link == link4)
            {
                NavigationService.Navigate(new Person { name = "张鹏飞", sex = "男", age = 100 });
            }
            else if (link == link4)
            {
                NavigationService.Navigate(new Uri("http://www.baidu.com"));
            }
        }
    }
}
