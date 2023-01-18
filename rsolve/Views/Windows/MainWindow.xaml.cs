using Rsolve.Static;
using Rsolve.Static.Theme;
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

namespace rsolve
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            #pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            StateChanged += AdjustWindowPropsOnStateChanged;
            #pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        }

        /// <summary>
        /// Handles adjustments when the window state changes.
        /// </summary>
        private void AdjustWindowPropsOnStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized) WindowStateMaximized();
            else WindowStateNormal();
        }

        /// <summary>
        /// Essential to provide dragability of the window.
        /// </summary>
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        /// <summary>
        /// Handles Maximizing and Normalising the Window State.
        /// </summary>
        private void ToggleWindowState(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                WindowStateMaximized();
            } else
            {
                WindowState = WindowState.Normal;
                WindowStateNormal();
            }
        }

        /// <summary>
        /// Helper method.
        /// </summary>
        private void WindowStateNormal()
        {
            WindowStateIcon.Content = FindResource("maximize");
            RsolveMainBorder.Padding = new Thickness(0);
        }

        /// <summary>
        /// Helper method.
        /// </summary>
        private void WindowStateMaximized()
        {
            WindowStateIcon.Content = FindResource("restore");
            RsolveMainBorder.Padding = new Thickness(6);
        }

        /// <summary>
        /// Handles minimizing the current view.
        /// </summary>
        private void MinimizeWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        /// <summary>
        /// Handles shuting down the application.
        /// </summary>
        private void CloseApp(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}