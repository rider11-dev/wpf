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
    /// Page_RoutedEvent_1.xaml 的交互逻辑
    /// </summary>
    public partial class Page_RoutedEvent_1 : Page
    {
        public Page_RoutedEvent_1()
        {
            InitializeComponent();
            //MySimpleButton的类事件处理函数处理过window能够得到通知
            this.btnMySimple.ClassHandlerProcessed += btnMySimple_RaisedClass;
        }

        protected int _eventCount = 0;
        private void InsertList(object sender, RoutedEventArgs e)
        {
            _eventCount++;
            string msg = string.Format("#{0}:\r\nInsertList\r\n Sender:{1}\r\n Source:{2}\r\n Original Source:{3}", _eventCount.ToString(), sender.ToString(), e.Source, e.OriginalSource);
            lstMsg.Items.Add(msg);
        }

        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            _eventCount = 0;
            lstMsg.Items.Clear();
        }

        private void btnMySimple_RaisedClass(object sender, EventArgs e)
        {
            _eventCount++;
            string msg = string.Format("#{0}:\r\nWindows Class Handler\r\nSender:{1}", _eventCount.ToString(), sender.ToString());
            lstMsg.Items.Add(msg);
        }

        private void ProcessHandlersToo(object sender, RoutedEventArgs e)
        {
            _eventCount++;
            string msg = string.Format("#{0}:\r\nProcessHandlersToo\r\n Sender:{1}\r\n Source:{2}\r\n Original Source:{3}",
                _eventCount.ToString(), sender.ToString(), e.Source, e.OriginalSource);
            lstMsg.Items.Add(msg);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //添加特殊事件处理函数
            grid1.AddHandler(MySimpleButton.CustomClickEvent, new RoutedEventHandler(ProcessHandlersToo), true);
        }
    }
}
