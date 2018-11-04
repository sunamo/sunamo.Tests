using sunamo.Essential;
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

namespace WpfState.Tests
{
    /// <summary>
    /// Interaction logic for ApplicationDataSettingsTests.xaml
    /// </summary>
    public partial class ApplicationDataSettingsTests : Window
    {
        ApplicationDataContainer data = null;

        public ApplicationDataSettingsTests()
        {
            InitializeComponent();

            Loaded += ApplicationDataSettingsTests_Loaded;

        }

        private async void ApplicationDataSettingsTests_Loaded(object sender, RoutedEventArgs e)
        {
            ThisApp.Name = "WpfState.Tests";
            await AppData.CreateAppFoldersIfDontExists();

            data = new ApplicationDataContainer();
            data.Add(cb);
            data.Add(chb);
        }
    }
}
