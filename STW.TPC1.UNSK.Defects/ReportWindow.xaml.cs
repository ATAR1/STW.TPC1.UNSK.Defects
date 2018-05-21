using Microsoft.Reporting.WinForms;
using STW.TPC1.UNSK.Defects.Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STW.TPC1.UNSK.Defects
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reportViewer.ShowParameterPrompts = true;
            reportViewer.LocalReport.ReportEmbeddedResource = "STW.TPC1.UNSK.Defects.Reports.ControlResultsReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1"));

            reportViewer.LocalReport.DataSources["DataSet1"].Value = new[]
            {
                new PartyReportRecord()
                {
                    Date = DateTime.Parse("15.05.2018"),
                    Shift = 'Б',
                    WorkArea = "ТО 1",
                    Defectoscope ="МДТ 6",
                    TypeSize = "219,08 х 8,02",
                    Melt ="2468",
                    ControlledQuantity = 168,
                    UsefulQuantity = 164,
                    WasteQuantity = 4,
                    ExternalDefectCount=1,
                    InternalDefectCount=4,

                },
                new PartyReportRecord()
                {
                    Date = DateTime.Parse("15.05.2018"),
                    Shift = 'Б',
                    WorkArea = "ТО 1",
                    Defectoscope ="МДТ 6",
                    TypeSize = "219,08 х 8,02",
                    Melt ="2456",
                    ControlledQuantity = 42,
                    UsefulQuantity = 37,
                    WasteQuantity = 5,
                    ExternalDefectCount =5
                    
                },
                new PartyReportRecord()
                {
                    Date = DateTime.Parse("15.05.2018"),
                    Shift = 'Б',
                    WorkArea = "ТО 1",
                    Defectoscope ="Сканер",
                    TypeSize = "219,08 х 8,02",
                    Melt ="2468",
                    ControlledQuantity = 168,
                    UsefulQuantity = 167,
                    WasteQuantity = 1,
                    TooThinCount=1
                },
                new PartyReportRecord()
                {
                    Date = DateTime.Parse("15.05.2018"),
                    Shift = 'Б',
                    WorkArea = "ТО 1",
                    Defectoscope ="Сканер",
                    TypeSize = "219,08 х 8,02",
                    Melt ="2456",
                    ControlledQuantity = 42,
                    UsefulQuantity = 41,
                    WasteQuantity = 1,
                    ExternalDefectCount=1
                },
            };
            reportViewer.RefreshReport();
        }
    }
}
