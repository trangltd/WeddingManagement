using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnHome.Top;
            this.dropDownSearch.Visible = false;
        }

        private void btnWedding_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.panelNavigate.Top = this.btnMenu.Top;
            FormMenu frm = new FormMenu();
            frm.ShowDialog();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.panelNavigate.Top = this.btnService.Top;
            FormService frm = new FormService();
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.panelNavigate.Top = this.btnReport.Top;
            this.dropDownReport.Visible = !this.dropDownReport.Visible;

        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            this.panelNavigate.Top = this.btnLobby.Top;
            this.dropDownLobby.Visible = !this.dropDownLobby.Visible;
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.panelNavigate.Top = this.btnWedding.Top;
            FormShift frm = new FormShift();
            frm.ShowDialog();
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = true;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void MainForm_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnLobby_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = true;
            this.dropDownReport.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming soon!", "CLOSE", MessageBoxButtons.OK);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            FormLogin frm = new FormLogin();
            frm.Show();
            this.Close();
        }

        private void btnMenu_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnService_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnWedding_Click_1(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.panelNavigate.Top = this.btnWedding.Top;
            FormWedding frm = new FormWedding();
            frm.ShowDialog();
        }

        private void btnReport_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = !this.dropDownSearch.Visible;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;

        }

        private void btnWedding_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            this.dropDownSearch.Visible = false;
            this.dropDownLobby.Visible = false;
            this.dropDownReport.Visible = false;
        }

        private void dropDownLobby_Load(object sender, EventArgs e)
        {
        }
        Point lastPoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the program?", "Confirm closing the program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBoxAnhNhoGiua_Click(object sender, EventArgs e)
        {

        }
        private void DropDownLobby_Load(object sender, EventArgs e)
        {
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }
    }
}
