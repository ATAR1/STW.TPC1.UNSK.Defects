using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STW.TPC1.UNSK.Defects.Model
{
    public class DefectoscopeFilterRecord
    {
        public string Defectoscope { get; set; }

        public bool Checked { get; set; }
    }

    public class WorkAreaFilterRecord
    {
        public string WorkArea { get; set; }
        public ICollection<DefectoscopeFilterRecord> Defectoscopes { get; private set; }
    }

    public class DefectoscopeFilter
    {
        public ICollection<WorkAreaFilterRecord> FilterRecords { get; set; }
        public IEnumerable<TubeInfo> ApplyFilter(IEnumerable<TubeInfo> records)
        {
                return records.SelectMany(ti => ti.WorkArea == record.WorkArea&&ti.Defectoscope==record.WorkArea);
        }
    }
}
