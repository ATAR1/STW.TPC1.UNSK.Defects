using System;
using System.Windows.Input;

namespace STW.TPC1.UNSK.Defects
{
    internal class ShowReportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var reportWindow = new ReportWindow();
            reportWindow.ShowDialog();
        }
    }
}