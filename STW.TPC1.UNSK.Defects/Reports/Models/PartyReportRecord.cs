using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STW.TPC1.UNSK.Defects.Reports.Models
{
    public class PartyReportRecord
    {
        public DateTime Date { get; set; }
        public string Melt { get; set; }

        public string TypeSize { get; set; }

        public string WorkArea { get; set; }

        public string Defectoscope { get; set; }

        public int ControlledQuantity { get; set; }

        public int UsefulQuantity { get; set; }

        public int WasteQuantity { get; set; }

    }
}
