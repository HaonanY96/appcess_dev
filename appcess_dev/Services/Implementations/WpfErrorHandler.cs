using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appcess_dev.Services.Interfaces;

namespace appcess_dev.Services.Implementations
{
    public class WpfErrorHandler : IErrorHandler
    {
        public void ShowErrorMessage(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
