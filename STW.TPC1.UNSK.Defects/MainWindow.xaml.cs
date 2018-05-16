using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace STW.TPC1.UNSK.Defects
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void expander_Expanded(object sender, RoutedEventArgs e)
        {

        }
    }
}
