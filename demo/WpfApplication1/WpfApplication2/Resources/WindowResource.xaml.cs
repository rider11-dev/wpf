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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace WpfApplication2.Resources
{
    /// <summary>
    /// WindowResource.xaml 的交互逻辑
    /// </summary>
    public partial class WindowResource : Window
    {
        public WindowResource()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/Resources/ContentFile.xaml", UriKind.Relative);

            //StreamResourceInfo info = Application.GetContentStream(uri);
            //XamlReader reader = new XamlReader();
            //Page page = (Page)reader.LoadAsync(info.Stream);
            //frameContentFile.Content = page;

            frameContentFile.Source = uri;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //1、这种写法，会同时更新两个按钮的背景，因为画刷资源继承自Freezable类，自带跟踪变化的机制
            //ImageBrush brush = (ImageBrush)this.Resources["brushTitle"];
            //brush.Viewport = new Rect(0, 0, 100, 100);

            //2、
            ImageBrush brush = (ImageBrush)this.Resources["brushTitle"];
            ImageBrush newBrush = brush.Clone();
            newBrush.Viewport = new Rect(0, 0, 100, 100);
            this.Resources["brushTitle"] = newBrush;//此处虽然修改了全局资源，但是，静态资源只查找一次，所以不受影响
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = (ImageBrush)this.Resources["SadTileBrush"];
        }
    }
}
