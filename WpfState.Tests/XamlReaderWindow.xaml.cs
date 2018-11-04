using desktop;
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
    /// Disadvantage is save whole XAML - if I change some in project, then will be loaded always from saved state
    /// </summary>
    public partial class XamlReaderWindow : Window
    {
        public XamlReaderWindow()
        {
            InitializeComponent();

            ThisApp.Name = "WpfState";
            AppData.CreateAppFoldersIfDontExists();
            

            //WpfStateHelper.AddControls(sp, "CheckBox", "TextBox");
            
            XamlSerializer xaml = new XamlSerializer(this);
            
        }
    }
}
