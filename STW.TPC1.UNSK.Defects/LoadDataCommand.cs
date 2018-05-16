using STW.TPC1.UNSK.Defects.DbModel;
using STW.TPC1.UNSK.Defects.MDT6DbModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace STW.TPC1.UNSK.Defects
{
    public class LoadDataCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public LoadDataCommand(MainWindowViewModel mainWindowViewModel)
        {
            this._mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.Tubes.Clear();
            using (var mdt6Context = new MDT6DBEntities())
            {
                var tubes = mdt6Context.Tubes.Include("Melt.Standart").Include("Melt.Typesize").OrderByDescending(ti => ti.tCreatedDate).Take(2000).ToList()
                    .Select(ti => {
                        var typeSizeString = ti.Melt.Typesize.AsString.Replace(" ","").Replace('x', '*').Replace('х', '*').Replace('.', ',');
                        var diameterString = typeSizeString.Substring(0, typeSizeString.IndexOf('*'));
                        var thicknessString = typeSizeString.Substring(typeSizeString.IndexOf('*') + 1);
                        double diameter=-1;
                        double thickness=-1;
                        Double.TryParse(diameterString, out diameter);
                        Double.TryParse(thicknessString, out thickness);
                        return new MDT6TubeInfo()
                        {
                            Date = ti.tCreatedDate,
                            Defectoscope = "МДТ 6",
                            Melt = ti.Melt.melt,
                            Diameter =diameter ,
                            Thickness = thickness,
                            Level = -1,
                            TubeNum = ti.num_tube_melt,
                            Standart = ti.Melt.Standart.Name,
                            WorkArea = "ТО 1",
                            DefectMap = ti.s_map_defects
                        };
                    });
                foreach (var tube in tubes)
                {
                    _mainWindowViewModel.Tubes.Add(tube);
                }
            }
        }
        
    }
}