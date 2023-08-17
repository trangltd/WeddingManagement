using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WeddingManagement
{
    public partial class FormGridViewService : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string WeddingNo = "";

        public FormGridViewService(string WeddingNo)
        {
            this.WeddingNo = WeddingNo;
            InitializeComponent();
            Load_Service();
        }
        void Load_Service()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT WD.WeddingNo, Representative, ServiceName, AmountOfService, " +
                    "TotalServicePrice, SVD.Note FROM WEDDING WD, SERVICE SV, SERVICE_DETAIL SVD " +
                    "WHERE WD.WeddingNo = SVD.WeddingNo AND SVD.ServiceNo = SV.ServiceNo AND WD.WeddingNo = @WeddingNo", sql))
                {
                    cmd.Parameters.AddWithValue("@WeddingNo", WeddingNo);
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    dataService.DataSource = table;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}