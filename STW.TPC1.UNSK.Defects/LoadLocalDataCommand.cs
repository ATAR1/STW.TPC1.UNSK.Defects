using STW.TPC1.UNSK.Defects.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace STW.TPC1.UNSK.Defects
{
    internal class LoadLocalDataCommand : ICommand
    {
        private ICollection<TubeInfo> _tubesCollection;

        public LoadLocalDataCommand(ICollection<TubeInfo> tubesCollection)
        {
            this._tubesCollection = tubesCollection;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _tubesCollection.Clear();
            using (var ctx = new DefectsEntities())
            {
                var tubes = ctx.TubeInfo.ToList();
                tubes.ForEach(t=>_tubesCollection.Add(t));
            }
        }
    }
}