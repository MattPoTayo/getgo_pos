using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetGoPOS.Helpers;
using GetGoPOS.Model;
using GetGoPOS.Views.Modal;

namespace GetGoPOS.Views
{
    public partial class Reports : BaseForm
    {
        private List<Report> reports = new List<Report>();
        private int beginColumn = 0;
        private Report longestReportsName = null;
        private bool isCheckSize = false;
        public Reports()
        {
            InitializeComponent();

            dgvDates.AutoGenerateColumns = false;
            this.KeyPreview = true;
            this.beginColumn = 0;
        }


        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            keyDownTimer.Start();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            keyDownTimer.Start();
        }

        private void Reports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgvDates.RowCount != 0)
                {
                    int current_row = dgvDates.CurrentCell.RowIndex;
                    int next_row = current_row + 1;
                    dgvDates.MultiSelect = false;

                    if (next_row < dgvDates.RowCount)
                    {
                        dgvDates.Rows[next_row].Selected = true;
                        dgvDates.CurrentCell = dgvDates[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvDates.RowCount != 0)
                {
                    int current_row = dgvDates.CurrentCell.RowIndex;
                    int next_row = current_row - 1;
                    dgvDates.MultiSelect = false;

                    if (next_row > -1)
                    {
                        dgvDates.Rows[next_row].Selected = true;
                        dgvDates.CurrentCell = dgvDates[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Enter)
                GenerateReport();
            else
                return;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvDates.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            FncFilter.set_dgv_controls(dgvDates);
            dgvDates.VirtualMode = true;
            dgvDates.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvDates_CellValueNeeded);
        }

        private void dgvDates_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (reports.Count == 0 || e.RowIndex >= reports.Count || !this.dgvDates.Columns[e.ColumnIndex].Visible ||
                (isCheckSize && longestReportsName == null))
                return;

            Report report = null;
            if (isCheckSize)
                report = longestReportsName;
            else
                report = reports[e.RowIndex];

            switch (this.dgvDates.Columns[e.ColumnIndex].Name)
            {
                case "colDate":
                    e.Value = report.Date.ToString("yyyyy-MM-dd");
                    break;
                case "colOldGrandTotal":
                    e.Value = report.OldGrandTotal.ToString("N2");
                    break;
                case "colNewGrandTotal":
                    e.Value = report.NewGrandTotal.ToString("N2");
                    break;
                case "colNetSales":
                    e.Value = report.VatableSales.ToString("N2");
                    break;
                case "colVat":
                    e.Value = report.Vat.ToString("N2");
                    break;
                case "colTransCount":
                    e.Value = report.TransCount.ToString("N2");
                    break;
                case "colBeginOR":
                    e.Value = report.MinOR;
                    break;
                case "colEndOR":
                    e.Value = report.MaxOR;
                    break;
            }
        }

        private void keyDownTimer_Tick(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            if (!bgwSearchReports.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchReports.RunWorkerAsync();
            }
        }

        private void bgwSearchReports_DoWork(object sender, DoWorkEventArgs e)
        {
            string SQLSearch = "";
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            //if (from > to)
                //return;

            e.Result = false;
            SQLSearch = string.Format(@"SELECT * FROM Reports WHERE transdate BETWEEN '{0}' AND '{1}' GROUP BY transdate", from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));

            DataTable reportsDataTable = DataBaseHelper.GetDB(SQLSearch);
            reports.Clear();
            this.bgwSearchReports.ReportProgress(0);
            //dgvProduct.DataSource = result;
            foreach (DataRow reportsDataRow in reportsDataTable.Rows)
            {
                reports.Add(
                    new Report
                    {
                        ID = Convert.ToInt64(reportsDataRow["id"]),
                        OldGrandTotal = Convert.ToDecimal(reportsDataRow["oldgrandtotal"]),
                        NewGrandTotal = Convert.ToDecimal(reportsDataRow["newgrandtotal"]),
                        Date = Convert.ToDateTime(reportsDataRow["transdate"].ToString()),
                        Type = Convert.ToInt32(reportsDataRow["readtype"]),
                        ReadCount = Convert.ToInt32(reportsDataRow["readcount"]),
                        SalesItemQty = Convert.ToDecimal(reportsDataRow["salesitemqty"]),
                        VoidItemQty = Convert.ToDecimal(reportsDataRow["voiditemqty"]),
                        GrossAmount = Convert.ToDecimal(reportsDataRow["grossamount"]),
                        VoidAmount = Convert.ToDecimal(reportsDataRow["voidamount"]),
                        SalesTransCount = Convert.ToDecimal(reportsDataRow["salescount"]),
                        TransCount = Convert.ToDecimal(reportsDataRow["transcount"]),
                        VoidTransCount = Convert.ToDecimal(reportsDataRow["voidcount"]),
                        Vat = Convert.ToDecimal(reportsDataRow["vat"]),
                        VatableSales = Convert.ToDecimal(reportsDataRow["vatablesales"]),
                        MinOR = reportsDataRow["minor"].ToString(),
                        MaxOR = reportsDataRow["maxor"].ToString(),
                        ActualDate = Convert.ToDateTime(reportsDataRow["date"].ToString())
                    }
                ); ;
            }
            longestReportsName = null;
            List<string> reportDates = new List<string>();
            if (reports.Count != 0)
            {
                reports.ForEach(x => reportDates.AddRange(x.Date.ToShortDateString().Split(' ')));
                int textLength = reportDates.Max(s => s.Length);
                string reportDate = reportDates.FirstOrDefault(s => s.Length == textLength);
                longestReportsName = reports.FirstOrDefault(s => s.Date.ToShortDateString().Contains(reportDate));
            }
            this.bgwSearchReports.ReportProgress(1);
        }

        private void bgwSearchReports_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Un-comment to record speed in log.
            //DateTime startTime = DateTime.Now;
            if (e.ProgressPercentage == 0)
                dgvDates.RowCount = 0;

            if (e.ProgressPercentage == 1 && reports.Count != 0)
            {
                isCheckSize = false;
                dgvDates.RowCount = reports.Count;
            }
            // Un - comment to record speed in log.
            //LOGS.LOG_PRINT(string.Format("BG_PROGRESS, complete run in {0} ms", (DateTime.Now - startTime).TotalMilliseconds));
        }

        private void bgwSearchReports_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!bgwSearchReports.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchReports.RunWorkerAsync();
            }
        }

        private void dgvDates_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            if (dgvDates.SelectedRows.Count == 0)
                return;

            ChooseReportType chooseReportType = new ChooseReportType();
            chooseReportType.report = reports[dgvDates.SelectedRows[0].Index];
            chooseReportType.ShowDialog();
        }
    }
}
