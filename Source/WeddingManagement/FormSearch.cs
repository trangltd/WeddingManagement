using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class FormSearch : Form
    {
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();

        public FormSearch()
        {
            InitializeComponent();
            load_gridView_wedding();
            load_gridView_bill();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void load_gridView_wedding()
        {
            using (SqlConnection conn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WeddingNo, WD.LobbyNo, WD.ShiftNo, BookingDate bDate, WeddingDate wDate, LobbyName, " +
                        "ShiftName, Representative, PhoneNumber, FORMAT(BookingDate, 'dd/MM/yyyy') BookingDate, " +
                        "FORMAT(WeddingDate, 'dd/MM/yyyy') WeddingDate, BroomName, BrideName, AmountOfTable, " +
                        "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING WD " +
                        "WHERE WD.ShiftNo = S.ShiftNo AND WD.LobbyNo = LB.LobbyNo ";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        adapter.Fill(table);
                        table.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                        table.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                        table.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                        table.Columns["bDate"].ColumnMapping = MappingType.Hidden;
                        table.Columns["wDate"].ColumnMapping = MappingType.Hidden;
                        table.Columns["ShiftName"].Caption = "Shift";
                        table.Columns["AmountOfTable"].Caption = "Table";
                        table.Columns["AmountOfContingencyTable"].Caption = "Contingency";
                        dataWedding.DataSource = table;
                        foreach (DataGridViewColumn col in dataWedding.Columns)
                        {
                            col.HeaderText = table.Columns[col.DataPropertyName].Caption;
                        }
                    }
                }
            }
        }
        void load_gridView_bill()
        {
            using (SqlConnection conn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT W.WeddingNo, W.ShiftNo, BillNo, W.LobbyNo, " +
                        "InvoiceDate iDate, PaymentDate pDate, Representative, BroomName, " +
                        "BrideName, PhoneNumber, LobbyName, ShiftName, " +
                        "FORMAT(InvoiceDate, 'dd/MM/yyyy') InvoiceDate, TablePriceTotal, " +
                        "ServicePriceTotal, Total, FORMAT(PaymentDate, 'dd/MM/yyyy') " +
                        "PaymentDate, MoneyLeft from WEDDING W, BILL B, LOBBY LB, " +
                        "SHIFT S WHERE B.WeddingNo = W.WeddingNo AND W.LobbyNo = LB.LobbyNo AND " +
                        "W.ShiftNo = S.ShiftNo";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        table1 = new DataTable();
                        adapter.Fill(table1);
                        table1.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                        table1.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                        table1.Columns["BillNo"].ColumnMapping = MappingType.Hidden;
                        table1.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                        table1.Columns["iDate"].ColumnMapping = MappingType.Hidden;
                        table1.Columns["pDate"].ColumnMapping = MappingType.Hidden;
                        dataBill.DataSource = table1;
                        foreach (DataGridViewColumn col in dataBill.Columns)
                        {
                            col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
                        }
                    }
                }
            }
        }

        private void tb_search_wd_textChange(object sender, EventArgs e)
        {
            if (tb_search_wd.Text == "")
            {
                load_gridView_wedding();
                return;
            }
            if (rBtn_name.Checked)
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT WeddingNo, WD.LobbyNo, WD.ShiftNo, BookingDate bDate, WeddingDate wDate, LobbyName, " +
                        "ShiftName, Representative, PhoneNumber, FORMAT(BookingDate, 'dd/MM/yyyy') BookingDate, " +
                        "FORMAT(WeddingDate, 'dd/MM/yyyy') WeddingDate, BroomName, BrideName, AmountOfTable, " +
                        "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING WD " +
                        "WHERE WD.ShiftNo = S.ShiftNo AND WD.LobbyNo = LB.LobbyNo AND (BroomName LIKE @searchWD " +
                        "OR BrideName LIKE @searchWD OR Representative LIKE @searchWD)";
                    sql.Open();
                    using (SqlCommand sqlcomm = sql.CreateCommand())
                    {
                        sqlcomm.CommandText = sqlquery;
                        sqlcomm.Parameters.AddWithValue("@searchWD", "%" + tb_search_wd.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table = new DataTable();
                            sqlDataAdapter.Fill(table);
                            table.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["bDate"].ColumnMapping = MappingType.Hidden;
                            table.Columns["wDate"].ColumnMapping = MappingType.Hidden;
                            table.Columns["ShiftName"].Caption = "Shift";
                            table.Columns["AmountOfTable"].Caption = "Table";
                            table.Columns["AmountOfContingencyTable"].Caption = "Contingency";
                            dataWedding.DataSource = table;
                            foreach (DataGridViewColumn col in dataWedding.Columns)
                            {
                                col.HeaderText = table.Columns[col.DataPropertyName].Caption;
                            }

                        }
                    }
                }
            }
            else if (rBtn_date.Checked)
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT WeddingNo, WD.LobbyNo, WD.ShiftNo, BookingDate bDate, WeddingDate wDate, LobbyName, " +
                        "ShiftName, Representative, PhoneNumber, FORMAT(BookingDate, 'dd/MM/yyyy') BookingDate, " +
                        "FORMAT(WeddingDate, 'dd/MM/yyyy') WeddingDate, BroomName, BrideName, AmountOfTable, " +
                        "AmountOfContingencyTable, TablePrice, Deposit FROM LOBBY LB, SHIFT S, WEDDING WD " +
                        "WHERE WD.ShiftNo = S.ShiftNo AND WD.LobbyNo = LB.LobbyNo AND (CONVERT(NVARCHAR(MAX), BookingDate, 103) " +
                        "LIKE @searchWD OR CONVERT(NVARCHAR(MAX), WeddingDate, 103) LIKE @searchWD)";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchWD", "%" + tb_search_wd.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table = new DataTable();
                            sqlDataAdapter.Fill(table);
                            table.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                            table.Columns["bDate"].ColumnMapping = MappingType.Hidden;
                            table.Columns["wDate"].ColumnMapping = MappingType.Hidden;
                            table.Columns["ShiftName"].Caption = "Shift";
                            table.Columns["AmountOfTable"].Caption = "Table";
                            table.Columns["AmountOfContingencyTable"].Caption = "Contingency";
                            dataWedding.DataSource = table;
                            foreach (DataGridViewColumn col in dataWedding.Columns)
                            {
                                col.HeaderText = table.Columns[col.DataPropertyName].Caption;
                            }
                        }
                    }
                }
            }

        }

        private void tb_search_bill_textChange(object sender, EventArgs e)
        {
            if (tb_search_bill.Text == "")
            {
                load_gridView_bill();
                return;
            }
            if (rBtn_name.Checked)
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT W.WeddingNo, W.ShiftNo, BillNo, W.LobbyNo, InvoiceDate iDate, PaymentDate pDate, " +
                        "Representative, BroomName, BrideName, PhoneNumber, LobbyName, ShiftName, " +
                        "FORMAT(InvoiceDate, 'dd/MM/yyyy') InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, " +
                        "FORMAT(PaymentDate, 'dd/MM/yyyy') PaymentDate, MoneyLeft from WEDDING W, BILL B, LOBBY LB, SHIFT S " +
                        "WHERE B.WeddingNo = W.WeddingNo AND W.LobbyNo = LB.LobbyNo AND W.ShiftNo = S.ShiftNo AND " +
                        "(BroomName LIKE @searchB OR BrideName LIKE @searchB OR Representative LIKE @searchB)";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchB", "%" + tb_search_bill.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            table1.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["BillNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["iDate"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["pDate"].ColumnMapping = MappingType.Hidden;
                            dataBill.DataSource = table1;
                            foreach (DataGridViewColumn col in dataBill.Columns)
                            {
                                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
                            }
                        }
                    }
                }
            }
            else if (rBtn_date.Checked)
            {
                using (
                SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT W.WeddingNo, W.ShiftNo, BillNo, W.LobbyNo, InvoiceDate iDate, PaymentDate pDate, " +
                        "Representative, BroomName, BrideName, PhoneNumber, LobbyName, ShiftName, " +
                        "FORMAT(InvoiceDate, 'dd/MM/yyyy') InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, " +
                        "FORMAT(PaymentDate, 'dd/MM/yyyy') PaymentDate, MoneyLeft from WEDDING W, BILL B, LOBBY LB, SHIFT S " +
                        "WHERE B.WeddingNo = W.WeddingNo AND W.LobbyNo = LB.LobbyNo AND W.ShiftNo = S.ShiftNo AND " +
                        "(CONVERT(NVARCHAR(MAX), InvoiceDate, 103) LIKE @searchB OR CONVERT(NVARCHAR(MAX), PaymentDate, 103) " +
                        "LIKE @searchB)";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchB", "%" + tb_search_bill.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            table1.Columns["WeddingNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["ShiftNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["BillNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["LobbyNo"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["iDate"].ColumnMapping = MappingType.Hidden;
                            table1.Columns["pDate"].ColumnMapping = MappingType.Hidden;
                            dataBill.DataSource = table1;
                            foreach (DataGridViewColumn col in dataBill.Columns)
                            {
                                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
                            }
                        }
                    }
                }
            }
        }

        private void dataWedding_CellDouBleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataWedding.Rows.Count)
            {
                var rowItem = (DataRowView)dataWedding.Rows[e.RowIndex].DataBoundItem;
                int index = table.Rows.IndexOf(rowItem.Row);
                DataRow row = table.Rows[index];

                string id = row["WeddingNo"].ToString();

                DialogResult dialogResult = MessageBox.Show("Do you want to edit wedding informations or pay for wedding?",
                    "Edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormWedding nt = new FormWedding(id);
                    nt.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void searchWedding_SizeChangedEvent(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            if (formWidth % 2 == 0)
            {
                formWidth -= 1;
                this.ClientSize = new Size(formWidth, formHeight);
                return;
            }
            else
            {
                dataWedding.Size = new Size((formWidth - 18 - 39) / 2, dataWedding.Size.Height);
                dataBill.Size = new Size((formWidth - 18 - 39) / 2, dataBill.Size.Height);
                dataBill.Location = new Point(dataWedding.Location.X + dataWedding.Size.Width + 39, dataBill.Location.Y);
            }
        }

        private void dataBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataBill.Rows.Count)
            {
                var rowItem = (DataRowView)dataBill.Rows[e.RowIndex].DataBoundItem;
                int index = table1.Rows.IndexOf(rowItem.Row);
                DataRow row = table1.Rows[index];

                string id = row["BillNo"].ToString();

                DialogResult dialogResult = MessageBox.Show("Do you want to edit bill informations?",
                    "Edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormBill b = new FormBill(id);
                    b.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }
    }
}
