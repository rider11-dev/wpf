using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ControlTemplateBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Type> _types;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            lstTypes.SelectionChanged += lstTypes_SelectionChanged;
        }

        private void lstTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var type = (Type)lstTypes.SelectedItem;
                if (type == null)
                {
                    return;
                }
                var info = type.GetConstructor(System.Type.EmptyTypes);
                var control = (Control)info.Invoke(null);
                control.Visibility = Visibility.Collapsed;
                grid.Children.Add(control);
                var template = control.Template;
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                var sb = new StringBuilder();
                var writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);
                txtTemplate.Text = sb.ToString();
                grid.Children.Remove(control);
            }
            catch (Exception ex)
            {
                txtTemplate.Text = $"<< error generating template: {ex.Message}";
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ctlType = typeof(Control);
            var derivedTypes = new List<Type>();

            var assembly = Assembly.GetAssembly(typeof(Control));
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(ctlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }
            _types = derivedTypes.OrderBy(t => t.Name).ToList();
            lstTypes.ItemsSource = _types;
        }


        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = txtFilter.Text?.Trim();
            if (string.IsNullOrWhiteSpace(filter))
            {
                lstTypes.ItemsSource = _types;
            }
            else
            {
                lstTypes.ItemsSource = _types.Where(t => t.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
    }
}
