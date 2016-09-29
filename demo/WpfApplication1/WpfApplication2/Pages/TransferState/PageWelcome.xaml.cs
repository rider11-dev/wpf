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

namespace WpfApplication2.Pages.TransferState
{
    /// <summary>
    /// PageWelcome.xaml 的交互逻辑
    /// </summary>
    public partial class PageWelcome : Page
    {
        public PageWelcome()
        {
            InitializeComponent();
        }

        public PageWelcome(User usr,bool isPwdVisible):this()
        {
            string txt = "欢迎你" + usr.Name;
            if(isPwdVisible)
            {
                txt += "\n你的密码为：" + usr.Pwd;
            }

            lblInfo.Content = txt;
        }
    }
}
