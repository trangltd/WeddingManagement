using System;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class DropDownLobby : UserControl
    {
        public DropDownLobby()
        {
            InitializeComponent();
        }

        private void btnLobbyType_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormLobbyType frm = new FormLobbyType();
            frm.ShowDialog();
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            FormLobby frm = new FormLobby();
            frm.ShowDialog();
            this.Visible = false;
        }
    }
}