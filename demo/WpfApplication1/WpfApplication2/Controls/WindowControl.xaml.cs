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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication2.Controls
{
    /// <summary>
    /// WindowControl.xaml 的交互逻辑
    /// </summary>
    public partial class WindowControl : Window
    {
        public WindowControl()
        {
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            var radio = e.OriginalSource as RadioButton;
            switch (radio.Name)
            {
                case "radioSingle":
                    list.SelectionMode = SelectionMode.Single;
                    break;
                case "radioMultiple":
                    list.SelectionMode = SelectionMode.Multiple;
                    break;
                case "radioExtended":
                    list.SelectionMode = SelectionMode.Extended;
                    break;
            }

        }

        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation aniDouble = new DoubleAnimation(100.0, duration);
            progressBar2.BeginAnimation(ProgressBar.ValueProperty, aniDouble);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtColor_R.Text = sliderR.Value.ToString("f0");
            txtColor_G.Text = sliderG.Value.ToString("f0");
            txtColor_B.Text = sliderB.Value.ToString("f0");

            var color = Color.FromRgb(Convert.ToByte(sliderR.Value), Convert.ToByte(sliderG.Value), Convert.ToByte(sliderB.Value));
            recColor.Fill = new SolidColorBrush(color);
        }

        
    }
}
