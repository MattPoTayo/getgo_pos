using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetGoPOS.Model.Global;
using GetGoPOS.Views.Modal;

namespace GetGoPOS.Helpers
{
    class FncFilter
    {
        public static decimal GetDecimalValue(string str)
        {
            decimal ret;
            str = str.Replace(",", "");
            bool isNum = decimal.TryParse(str, out ret);
            if (isNum)
            {
                return ret;
            }
            else
            {
                return 0;
            }
        }
        public static BaseForm GetLastOpenForm()
        {
            BaseForm frm = null;
            if (Application.OpenForms.Count > 0)
                frm = Application.OpenForms.Cast<BaseForm>().Last();
            if (frm == null)
                return null;
            return frm;
        }

        public static void SetGridViewDisplay(DataGridView dgv, bool setMinWidth = true)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            List<int> col_index = new List<int>();
            decimal col_width = 0;
            decimal res_width = 0;
            int col_each = 0;
            int new_colwidth = 0;
            int dgv_width = 0;
            int counter_col = 0;
            dgv_width = dgv.Width;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == true)
                {
                    col_index.Add(i);
                    counter_col++;
                    col_width += dgv.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);
                }
            }
            if (dgv.ColumnCount != 0)
            {
                res_width = dgv_width - col_width - 2;
                col_each = Convert.ToInt32(res_width) / counter_col;
                for (int i = 0; i < col_index.Count; i++)
                {
                    int width = Convert.ToInt32(dgv.Columns[col_index[i]].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true) + col_each);
                    if (setMinWidth)
                        dgv.Columns[col_index[i]].MinimumWidth = (width < 2) ? 2 : width;
                    dgv.Columns[col_index[i]].Width = width;
                    new_colwidth += width;
                }

                if (dgv_width > new_colwidth)
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        public static void set_dgv_controls(DataGridView dgv)
        {
            //DGV Properties
            //int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            float custom_FontSize = 12F;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", custom_FontSize, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.Font = new Font("Calibri", custom_FontSize, FontStyle.Regular);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = true;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                // Column Aligmnent
                //if (dgv.Columns[i].Name == "colProduct" || dgv.Columns[i].Name == "description" || dgv.Columns[i].Name == "memo")
                if (dgv.Columns[i].Name == "description")
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //else if (dgv.Columns[i].Name == "colSellingPrice")
                //    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                else
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns[i].Resizable = DataGridViewTriState.False;

                //AutoSizeColumnMode
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            SetGridViewDisplay(dgv);
        }

        public static void Alert(string str)
        {
            alert(str, "");
        }
        public static void alert(string str, ErrorFormButtonType errorFormButtonType)
        {
            alert(str, "", errorFormButtonType);
        }
        public static void alert(string str, string title, ErrorFormButtonType errorFormButtonType = ErrorFormButtonType.Escape)
        {
            ErrorForm Errorform = new ErrorForm();
            if (title.Trim() != "")
                Errorform.Text = title;
            Errorform.errormessage = str;
            Errorform.ErrorFormButtonType = errorFormButtonType;
            Errorform.ShowDialog();
        }
        public static void alert(string str, int isBarcode)
        {
            ErrorForm Errorform = new ErrorForm();
            Errorform.errormessage = str;
            Errorform.ShowDialog();
        }
        public static bool ConfirmYesNo(string message)
        {
            return ConfirmYesNo(message, globalvariables.BusinessName);
        }
   
        public static bool ConfirmYesNo(string message, string title)
        {
            return ConfirmYesNo(message, title, "Yes", "No");
        }
        public static bool ConfirmYesNo(string message, string title, string yesButtonLabel, string noButtonLabel)
        {
            return ConfirmYesNoDialog(message, title, yesButtonLabel, noButtonLabel);
        }
        private static bool ConfirmYesNoDialog(string message, string title, string yesButtonLabel, string noButtonLabel)
        {
            DialogForm dialogBoxForm = new DialogForm(message, title, yesButtonLabel, noButtonLabel);
            if (title != "")
                dialogBoxForm.Text = title;
            dialogBoxForm.ShowDialog();
            return dialogBoxForm.ReturnValue == dialogBoxForm.YesButtonLabel;
        }
    }
}
