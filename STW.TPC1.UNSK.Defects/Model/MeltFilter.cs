using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STW.TPC1.UNSK.Defects.Model
{
    public class MeltFilterRecord
    {
        public string Melt { get; set; }

        public bool Checked { get; set; }
    }

    public class MeltFilter
    {
        public ObservableCollection<MeltFilterRecord> Melts { get; set; }
    }
}
