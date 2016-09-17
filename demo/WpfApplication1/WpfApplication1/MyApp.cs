using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2
{
    public class MyApp
    {
        [STAThread]
        public static void Main()
        {
            //MyWindow window = new MyWindow();
            //window.Show();

            Window_WithXAML win2 = new Window_WithXAML();
            win2.Show();

            Application app = new Application();
            app.Run();

        }
    }
}
