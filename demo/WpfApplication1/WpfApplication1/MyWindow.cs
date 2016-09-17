using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication2
{
    public class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.Title = "WPF——without xaml";
            this.Width = 300;
            this.Height = 200;

            DockPanel panel = new DockPanel(); 

            Button btn = new Button();
            btn.Content = "hellow xaml";
            btn.Background = new SolidColorBrush(Colors.AliceBlue);
            btn.Margin = new Thickness(0, 5, 0, 10);
            DockPanel.SetDock(btn, Dock.Left);
            panel.Children.Add(btn);

            Button btn2 = new Button();
            btn2.Content = "hello xaml2";

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            brush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1));

            btn2.Background = brush;
            DockPanel.SetDock(btn2, Dock.Right);
            panel.Children.Add(btn2);

            this.Content = panel;
        }
    }
}
