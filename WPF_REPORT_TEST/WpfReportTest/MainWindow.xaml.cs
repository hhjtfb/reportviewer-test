using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfReportTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private WpfReportTest.BusinessObjects.Merchant m_merchant =
            new WpfReportTest.BusinessObjects.Merchant();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRpt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new
                Microsoft.Reporting.WinForms.ReportDataSource();

            reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file  
            reportDataSource1.Value = m_merchant.GetProducts();//重要部分  
            this._reportViewer.Reset();
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "WpfReportTest.Report1.rdlc";
            _reportViewer.RefreshReport();
        }
    }
}
