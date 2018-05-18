using STW.TPC1.UNSK.Defects.DbModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STW.TPC1.UNSK.Defects
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            
            LoadDataCommand = new LoadDataCommand(this.Tubes);
            LoadLocalDataCommand = new LoadLocalDataCommand(this.Tubes);
            SaveDataCommand = new SaveDataCommand(Tubes);
            ShowReportCommand = new ShowReportCommand();
        }
        public ICommand LoadDataCommand { get; private set; }

        public ICommand LoadLocalDataCommand { get; private set; }

        public ICommand SaveDataCommand { get; private set; }

        public ICommand ShowReportCommand { get; private set; }

        public ICollection<TubeInfo> Tubes { get; private set; } = new ObservableCollection<TubeInfo>();
    }
}
