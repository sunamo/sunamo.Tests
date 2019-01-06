using desktop.Helpers.Clipboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClipboardMonitor.Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IntPtr nextClipboardViewer;
        WindowInteropHelper h = null;

        public MainWindow()
        {
            InitializeComponent();
            ClipboardMonitorW32 w32 = new ClipboardMonitorW32(this);
            w32.ClipboardContentChanged += W32_ClipboardContentChanged;

            Loaded += MainWindow_Loaded;
        }

        private void W32_ClipboardContentChanged(object sender, EventArgs e)
        {
            tb.Text = ClipboardHelperWin.Instance.GetText();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        

        ~MainWindow()
        {
            //this.Dispatcher.Invoke(() =>
            //{
            //    W32.ChangeClipboardChain(this.Handle, nextClipboardViewer);
            //});
        }

       



        
    }
}
