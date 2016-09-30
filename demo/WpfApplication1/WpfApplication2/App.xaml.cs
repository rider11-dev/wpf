using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using WpfApplication2.Controls;
using WpfApplication2.Layouts;
using WpfApplication2.Pages;
using WpfApplication2.Pages.Host;
using WpfApplication2.Pages.TransferState;
using WpfApplication2.Resources;

namespace WpfApplication2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public List<User> users;

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //WindowTest();
            //PageTest();
            //TransferStateTest();
            //LayoutTest();
            //ControlsTest();

            //ResourcesTest();
            StyleTest();
        }

        void StyleTest()
        {
            Window win = new WpfApplication2.Styles.WindowStyle();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        void ResourcesTest()
        {
            Window win = new WindowResource();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        void ControlsTest()
        {
            Window win = new WindowControl();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        void LayoutTest()
        {
            Window win = new LayoutWindow();
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        /// <summary>
        /// 页面状态及参数传递
        /// </summary>
        void TransferStateTest()
        {
            PageLogin.Register();

            users = new List<User>();

            User usr = new User("zpf", "zpf");
            usr.FavColors.Add("绿色");
            usr.FavColors.Add("黑色");

            users.Add(usr);

            NavigationWindow win = new NavigationWindow();
            win.Width = 480;
            win.Height = 400;
            win.Content = new PageLogin();
            win.Show();
        }

        private void PageTest()
        {
            NavigationWindow win = new NavigationWindow();
            ////win.Content = new Page1();
            //win.Content = new Page1(300, 300, 500, 500);
            ////win.Content = new Page1(500, 500, 300, 300);

            //win.Content = new Page_UsingFrameAsHost();
            //win.Content = new WpfApplication2.Pages.Hyperlinks.Page1();
            win.Content = new WpfApplication2.Pages.Hyperlinks.Page_NavigationService();



            win.Show();
        }

        private void WindowTest()
        {
            //Window win = new MainWindow();
            //Window win = new Window_LifeTime();
            //Window win = new Window_Property();
            Window win = new Window_NoneRegular();
            win.Show();
        }

        private void Application_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("我被激活啦");
        }

        private void Application_Deactivated(object sender, EventArgs e)
        {
            //MessageBox.Show("我失去焦点啦");
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            if (e.Exception is DivideByZeroException)
            {
                MessageBox.Show("出错了：" + e.Exception.Message + "。dispatcher：" + e.Dispatcher.ToString());

            }
            else
            {
                MessageBox.Show("出错了：" + e.Exception.Message + "。程序马上退出");
                var rst = MessageBox.Show("是否退出？", "", MessageBoxButton.YesNo);
                if (rst == MessageBoxResult.Yes)
                {
                    this.Shutdown(-1);
                }
            }
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            MessageBox.Show(string.Format("警告，系统正在{0}。不要啊！", e.ReasonSessionEnding.ToString()));
            e.Cancel = true;
        }
    }
}
