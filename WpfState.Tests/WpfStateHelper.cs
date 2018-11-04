using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfState.Tests
{
    class WpfStateHelper
    {
        public static void AddControls(StackPanel sp, params string[] v1)
        {
            var ass = new ComboBox().GetType().Assembly;
            string ns = "System.Windows.Controls.";
            foreach (var item in v1)
            {
                Type type = ass.GetType(ns + item);
                FrameworkElement fw = Activator.CreateInstance(type) as FrameworkElement;

                fw.Name = item;
                sp.Children.Add(fw);
            }
        }
    }
}
