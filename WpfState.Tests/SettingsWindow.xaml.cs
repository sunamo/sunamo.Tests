using desktop.Interfaces;
using desktop.Storage;
using sunamo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using WpfState.Tests.Properties;

namespace WpfState.Tests
{
    /// <summary>
    /// Never delete, if I maybe in next time will be edit
    /// </summary>
    public partial class MainWindow : Window//, IWindowWithSettingsManager
    {
        const string s = "Number";
        Random random = new Random();
        WpfStateSettings mus = null;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int nt = random.Next(999);
            mus[s] = nt;
            SetToTb();
        }

        private void SetToTb()
        {
            // TODO: Osetrit kdyz nebude, nemusi vzdycky byt
            tb.Text = mus[s].ToString();
        }

        public MainWindow()
        {
            InitializeComponent();

            var settings = new WpfStateSettings();
            var sm = new SettingsManager(settings, settings.Providers);
            sm.customProperties.Add(s, 0);

            mus = settings;
            AppSettingsManager.SettingsManager = sm;

            //WpfStateHelper.AddControls(sp, "CheckBox", "TextBox");
            
            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AppSettingsManager.AddChildrenFrom(this);

            AppSettingsManager.LoadSettings();
        }

        

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            AppSettingsManager.SaveSettings();
        }


    }
}
