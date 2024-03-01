using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ozon.Navigations
{
    public class NavigationManager
    {
        public static void NavigateTo(Window window, bool mode)
        {
            if (mode) CloseCurrentWindow();
            window.Show();
        }

        public static void CloseCurrentWindow()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
