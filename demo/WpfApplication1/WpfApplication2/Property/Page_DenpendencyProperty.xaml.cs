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

namespace WpfApplication2
{
    /// <summary>
    /// Page_DenpendencyProperty1.xaml 的交互逻辑
    /// </summary>
    public partial class Page_DenpendencyProperty : Page
    {
        double _oldFontSize = 0;
        public Page_DenpendencyProperty()
        {
            InitializeComponent();

            _oldFontSize = FontSize;
        }

        private void btnFontSizeWin_Click(object sender, RoutedEventArgs e)
        {
            FontSize = 16;
        }

        private void btnFontSize_Click(object sender, RoutedEventArgs e)
        {
            btnFontSize.FontSize = 8;
        }

        private void btnResetFontSize_Click(object sender, RoutedEventArgs e)
        {
            FontSize = _oldFontSize;
            this.btnFontSize.FontSize = _oldFontSize;
        }

        private void btnSpace1_Click(object sender, RoutedEventArgs e)
        {
            this.btnSpace1.Space = 2;
        }

        //为Page增加Space依赖属性
        public static readonly DependencyProperty SpaceProperty;
        //.NET属性包装器
        public int Space
        {
            set
            {
                SetValue(SpaceProperty, value);
            }
            get
            {
                return (int)GetValue(SpaceProperty);
            }
        }
        //静态构造函数中，绑定依赖属性
        static Page_DenpendencyProperty()
        {
            FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata();
            metaData.Inherits = true;//属性值继承
            //这里不是通过注册而来，即依赖属性可以把自身添加给其他属性
            SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(Page_DenpendencyProperty));
            SpaceProperty.OverrideMetadata(typeof(Page), metaData);//重建元数据
        }

        private void btnSpace2_Click(object sender, RoutedEventArgs e)
        {
            this.Space = 2;
        }
    }
}
