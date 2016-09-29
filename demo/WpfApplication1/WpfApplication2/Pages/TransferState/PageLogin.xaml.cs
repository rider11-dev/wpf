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
    /// PageLogin.xaml 的交互逻辑
    /// </summary>
    public partial class PageLogin : Page
    {
        public static DependencyProperty FocusElementProperty;

        public string FocusElement
        {
            get
            {
                return (string)base.GetValue(FocusElementProperty);
            }
            set
            {
                base.SetValue(FocusElementProperty, value);
            }
        }

        public PageLogin()
        {
            InitializeComponent();
        }

        public static void Register()
        {
            PageLogin.FocusElementProperty = DependencyProperty.Register("FocusElement", typeof(string), typeof(PageLogin),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            List<User> usrs = ((WpfApplication2.App)(App.Current)).users;
            var usr = usrs.Where(u => u.Name == txtName.Text && u.Pwd == txtPwd.Password).FirstOrDefault();
            if (usr != null)
            {
                PageWelcome pageWel = new PageWelcome(usr, false);
                NavigationService.Navigate(pageWel);
                return;
            }

            NavigationService.Navigate(new Uri("pack://application:,,,/Pages/TransferState/PageError.xaml"));
        }

        private void Page_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.NewFocus == this.txtName || e.NewFocus == this.txtPwd)
            {
                this.FocusElement = (string)(((DependencyObject)e.NewFocus).GetValue(FrameworkElement.NameProperty));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.FocusElement != null)
            {
                IInputElement element = (IInputElement)LogicalTreeHelper.FindLogicalNode(this, this.FocusElement);

                Keyboard.Focus(element);
            }
        }
    }
}
