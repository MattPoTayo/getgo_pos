using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GetGoPOS.Views;

namespace GetGoPOS
{
    public partial class MainForm : BaseForm
    {
        private IconButton currentButton;
        private Panel leftBorderBtn;
        private Panel defaultPanel;
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelMenuSub.Controls.Add(leftBorderBtn);
            panelOptionSub.Controls.Add(leftBorderBtn);
            defaultPanel = panelDesktop;
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBCOlors
        {
            public static Color color1 = Color.FromArgb(255, 190, 0);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(85, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 165, 251);
        }

        private void ActiveButton(object senderBtn, Color color)
        {
            DisableButton();
            if(senderBtn != null)
            {
                currentButton = (IconButton)senderBtn;
                currentButton.BackColor = Color.FromArgb(127, 131, 142);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;

                //Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentButton.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if(currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(255, 247, 226);
                currentButton.ForeColor = Color.DimGray;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.DimGray;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void customizeDesign()
        {
            panelMenuSub.Visible = false;
            panelOptionSub.Visible = false;
            btnHMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelMenuSub.Visible == true)
                panelMenuSub.Visible = false;
            if (panelOptionSub.Visible == true)
                panelOptionSub.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #region MENU
        private void btnMenuMain_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenuSub);

        }

        private void btnPointOfSalesSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
            OpenChildForm(new PointOfSales());

        }
        private void btnProductMngmtSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
            OpenChildForm(new ProductManagement());
        }
        private void btnMngInventorySub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
            OpenChildForm(new ManageInventory());
        }

        private void btnReportsSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
            OpenChildForm(new Reports());
        }
        #endregion

        #region OPTIONS
        private void btnOptionsMain_Click(object sender, EventArgs e)
        {
            showSubMenu(panelOptionSub);

        }
        private void btnAboutUsSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
        }
        private void btnContactUsSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
        }
        private void btnHelpSub_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBCOlors.color1);
        }
        #endregion

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(activeForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnHMenu_Click(object sender, EventArgs e)
        {
            HideSideMenu();
        }

        private void HideSideMenu()
        {
            panelSidieMenu.Visible = !panelSidieMenu.Visible;
            btnHMenu.Visible = !btnHMenu.Visible;
            if (!panelSidieMenu.Visible)
            {
                iconCurrentChildForm.Location = new Point(70, 17);
                lblTitleChildForm.Location = new Point(109, 26);
            }
            else
            {
                iconCurrentChildForm.Location = new Point(19, 17);
                lblTitleChildForm.Location = new Point(58, 26);
            }
        }

        private void btnHide_Click_1(object sender, EventArgs e)
        {
            HideSideMenu();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Reset();
            if (activeForm != null)
                activeForm.Close();
            panelDesktop = defaultPanel;
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.FromArgb(255, 190, 0);
            lblTitleChildForm.Text = "Home";

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
