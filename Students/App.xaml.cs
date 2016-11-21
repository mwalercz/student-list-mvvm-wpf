using Students.View;
using Students.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Students
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException +=
              new DispatcherUnhandledExceptionEventHandler(DispatcherUnhandledExceptionHandler);
            base.OnStartup(e);
        }
        void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            runException(e.Exception);
            e.Handled = true;
        }

        void runException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                runException(ex.InnerException);
            }
            else
            {
                MessageBox.Show(
                    String.Format(
                        "{0} Error:  {1}\r\n\r\n{2}",
                        ex.Source, ex.Message, ex.StackTrace,
                        "Initialize Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error));

            }
            // ex.Class = 14: duplicate key
        }
    }
}

