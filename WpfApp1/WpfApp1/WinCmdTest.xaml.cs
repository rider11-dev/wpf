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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// WinCmdTest.xaml 的交互逻辑
    /// </summary>
    public partial class WinCmdTest : Window
    {
        public WinCmdTest()
        {
            InitializeComponent();
            BindCommand();
        }

        private void BindCommand()
        {
            var cmdBinding = new CommandBinding(ApplicationCommands.New);
            cmdBinding.Executed += CmdBinding_Executed;
            this.CommandBindings.Add(cmdBinding);
        }

        private void CmdBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"CmdBinding_Executed=>{e.Command.GetType().Name},source={e.Source.ToString()}");
        }
    }
}
