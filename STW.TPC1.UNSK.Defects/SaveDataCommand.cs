using System;
using System.Collections.Generic;
using System.Windows.Input;
using STW.TPC1.UNSK.Defects.DbModel;

namespace STW.TPC1.UNSK.Defects
{
    internal class SaveDataCommand : ICommand
    {
        private ICollection<TubeInfo> _tubes;

        public SaveDataCommand(ICollection<TubeInfo> tubes)
        {
            this._tubes = tubes;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (var defectContext = new DefectsEntities())
            {
                defectContext.TubeInfo.RemoveRange(defectContext.TubeInfo);
                defectContext.TubeInfo.AddRange(_tubes);
                defectContext.SaveChanges();
            }
        }
    }
}