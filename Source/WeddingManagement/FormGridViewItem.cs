using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WeddingManagement
{
    public partial class FormGridViewItem : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string idWedding = "";
        public FormGridViewItem(string idWedding)
        {
            this.idWedding = idWedding;
            InitializeComponent();
            Load_Item();
        }

        void Load_Item()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT WD.WeddingNo, Representative, ItemName, AmountOfItems, " +
                    "TotalItemsPrice, TBD.Note FROM WEDDING WD, MENU MN, TABLE_DETAIL TBD " +
                    "WHERE WD.WeddingNo = TBD.WeddingNo AND TBD.ItemNo = MN.ItemNo AND WD.WeddingNo = @WeddingNo", sql))
                {
                    cmd.Parameters.AddWithValue("@WeddingNo", idWedding);
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    dataItems.DataSource = table;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
