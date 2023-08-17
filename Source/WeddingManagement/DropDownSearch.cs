using System;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class DropDownSearch : UserControl
    {
        public DropDownSearch()
        {
            InitializeComponent();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            FormShift frmS =new FormShift();
            frmS.ShowDialog();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to access!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            FormAccount a = new FormAccount();
            a.ShowDialog();
        }

        private void btnWedding_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormSearch frmS = new FormSearch();
            frmS.ShowDialog();
        }

        private void bill_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormSearch frmS = new FormSearch();
            frmS.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormLobbyType frm = new FormLobbyType();
            frm.ShowDialog();
            this.Visible = false;
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            FormLobby frm = new FormLobby();
            frm.ShowDialog();
            this.Visible = false;
        }

        private void btnLobbyType_Click(object sender, EventArgs e)
        {
            FormLobbyType frm = new FormLobbyType();
            frm.ShowDialog();
            this.Visible = false;
        }
    }
}
