using System.Collections.ObjectModel;

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
