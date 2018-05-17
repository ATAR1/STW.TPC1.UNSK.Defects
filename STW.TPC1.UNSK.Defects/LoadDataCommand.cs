using STW.TPC1.UNSK.Defects.DbModel;
using STW.TPC1.UNSK.Defects.MDT6DbModel;
using STW.TPC1.UNSK.Defects.ScanerDbModel;
using System;
using System.Collections.Generic;
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
            var tubes = new List<TubeInfo>();
            _mainWindowViewModel.Tubes.Clear();
            using (var mdt6Context = new MDT6DBEntities())
            {
                tubes.AddRange( mdt6Context.Tubes.Include("Melt.Standart").Include("Melt.Typesize").OrderByDescending(ti => ti.tCreatedDate).Take(2000).ToList()
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
                    }));
               

            }

            using (var scanerContext = new ScanerTubeInfoEntities())
            {
                tubes.AddRange(scanerContext.ScanerTubeInfoes.Include("Defects").Where(ti=>ti.TubeStatus==0).OrderByDescending(ti => ti.Date).Take(2000).ToList()
                    .Select(ti =>{
                        var typeSizeString = ti.TypeSize.Replace(" ", "").Replace('x', '*').Replace('х', '*').Replace('.', ',');
                        var diameterString = typeSizeString.Substring(0, typeSizeString.IndexOf('*'));
                        var thicknessString = typeSizeString.Substring(typeSizeString.IndexOf('*') + 1);
                        double diameter = -1;
                        double thickness = -1;
                        Double.TryParse(diameterString, out diameter);
                        Double.TryParse(thicknessString, out thickness);
                        var tubeNumStr = ti.TubeNum;
                        int tubeNum=0;
                        Int32.TryParse(tubeNumStr, out tubeNum);
                        return new DbModel.ScanerTubeInfo()
                        {
                            Date = ti.Date,
                            Defectoscope = "Сканер",
                            Diameter = diameter,
                            Thickness = thickness,
                            Level = (int)ti.TubeStatus,
                            Melt = ti.Melt,
                            Standart = ti.Standart,
                            TubeNum = tubeNum,
                            WorkArea = "ТО 1",
                            DefectMap = String.Join(" ", ti.Defects.Select(d => $"{d.Name} : {d.Value}"))
                        };
                    }));

            }

            foreach (var tube in tubes)
            {
                _mainWindowViewModel.Tubes.Add(tube);
            }
        }
        
    }
}