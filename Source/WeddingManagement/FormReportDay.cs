using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WeddingManagement
{
    public partial class FormReportDay : Form
    {

        DataTable table1 = new DataTable();
        public FormReportDay()
        {
            InitializeComponent();
            ReportLoad();
            rBtn_day.Checked = true;
            rBtn_amount.Checked = false;
        }

        private void ReportLoad()
        {
            table1 = new DataTable();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT D.ReportNo, D.Day, R.Month, R.Year, D.DayRevenue, R.RevenueTotal, " +
                    "D.AmountOfWedding FROM REVENUE_REPORT R, REVENUE_REPORT_DETAIL D WHERE R.ReportNo = D.ReportNo", sql))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table1);
                    }
                }
            }
            table1.Columns[0].ColumnMapping = MappingType.Hidden;
            table1.Columns[1].Caption = "Day";
            table1.Columns[2].Caption = "Month";
            table1.Columns[3].Caption = "Year";
            table1.Columns[4].Caption = "Day Revenue";
            table1.Columns[5].Caption = "Revenue Total";
            table1.Columns[6].Caption = "Amout Of Wedding";
            DataColumn column = new DataColumn("Ratio", typeof(float));
            column.Caption = "Ratio";
            table1.Columns.Add(column);
            foreach (DataRow row in table1.Rows)
            {
                row["Ratio"] = Convert.ToSingle(row["DayRevenue"]) / Convert.ToSingle(row["RevenueTotal"]);
            }
            dataRPD.DataSource = table1;
            foreach (DataGridViewColumn col in dataRPD.Columns)
            {
                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
            }
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int index = comboBoxDay.SelectedIndex;
            int index2 = comboBoxMonth.SelectedIndex;
            if (!int.TryParse(textBoxYear.Text, out int year))
            {
                MessageBox.Show("Please enter year number correctly!", "ERROR!", MessageBoxButtons.OK);
                return;
            }
            if (index < 0 || index2 < 0)
            {
                MessageBox.Show("Please fill full the fields!");
                return;
            }
            if (!int.TryParse(comboBoxDay.SelectedItem.ToString(), out int day))
            {
                MessageBox.Show("Input error: Day!", "ERROR", MessageBoxButtons.OK);
            }
            if (!int.TryParse(comboBoxMonth.SelectedItem.ToString(), out int month))
            {
                MessageBox.Show("Input error: Month!", "ERROR", MessageBoxButtons.OK);
            }
            GetRevenue(year, month, day);
            ReportLoad();
        }

        public static void GetRevenue(int year, int month, int day, bool silent = false)
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                long total = 0;
                int count = 0;
                string Id = "";

                using (SqlCommand cmd2 = new SqlCommand("SELECT * from BILL where (DAY(PaymentDate) = @day and " +
                    "Month(PaymentDate) = @month and Year(PaymentDate) = @year) AND MoneyLeft <= 0", sql))
                {
                    cmd2.Parameters.AddWithValue("@day", day);
                    cmd2.Parameters.AddWithValue("@month", month);
                    cmd2.Parameters.AddWithValue("@year", year);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            total += (long)reader["Total"];
                            count += 1;
                        }
                    }
                }
                bool existed = false;
                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM REVENUE_REPORT WHERE Month = @month AND Year = @year", sql))
                {
                    cmd2.Parameters.AddWithValue("@month", month);
                    cmd2.Parameters.AddWithValue("@year", year);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = reader["ReportNo"].ToString();
                            existed = true;
                        }
                        else
                        {
                            Id = "RR" + WeddingClient.GetNewIdFromTable("RR").ToString();
                        }
                    }
                }
                if (!existed)
                {
                    using (SqlCommand cmd2 = new SqlCommand("INSERT INTO REVENUE_REPORT (ReportNo, Month, Year, RevenueTotal) " +
                        "VALUES (@id, @month, @year, 0) ", sql))
                    {
                        cmd2.Parameters.AddWithValue("@id", Id);
                        cmd2.Parameters.AddWithValue("@month", month);
                        cmd2.Parameters.AddWithValue("@year", year);
                        if (cmd2.ExecuteNonQuery() > 0)
                        {
                            using (SqlCommand cmd3 = new SqlCommand("Insert into REVENUE_REPORT_DETAIL(ReportNo, Day, DayRevenue, " +
                                "AmoutOfWedding) values(@id, @day, @rday, @amout)", sql))
                            {
                                cmd3.Parameters.AddWithValue("@id", Id);
                                cmd3.Parameters.AddWithValue("@day", day);
                                cmd3.Parameters.AddWithValue("@rday", total);
                                cmd3.Parameters.AddWithValue("@amout", count);
                                if (cmd3.ExecuteNonQuery() > 0)
                                {
                                    using (SqlCommand cmd4 = new SqlCommand("UPDATE REVENUE_REPORT " +
                                        "SET RevenueTotal = RevenueTotal + @plus WHERE ReportNo = @Id", sql))
                                    {
                                        cmd4.Parameters.AddWithValue("@plus", total);
                                        cmd4.Parameters.AddWithValue("@Id", Id);
                                        if (cmd4.ExecuteNonQuery() > 0)
                                        {
                                            if (!silent) MessageBox.Show("Add new day report successfully!", 
                                                "SUCCESS", MessageBoxButtons.OK);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd2 = new SqlCommand("SELECT DayRevenue FROM REVENUE_REPORT_DETAIL " +
                        "WHERE ReportNo = @Id AND Day = @day", sql))
                    {
                        cmd2.Parameters.AddWithValue("@Id", Id);
                        cmd2.Parameters.AddWithValue("@day", day);
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long oldRevenue = (long)reader["DayRevenue"];
                                using (SqlCommand cmd3 = new SqlCommand("UPDATE REVENUE_REPORT_DETAIL " +
                                    "SET DayRevenue = @rday, AmoutOfWedding = @amout WHERE ReportNo = @Id AND Day = @day", sql))
                                {
                                    cmd3.Parameters.AddWithValue("@rday", total);
                                    cmd3.Parameters.AddWithValue("@amout", count);
                                    cmd3.Parameters.AddWithValue("@Id", Id);
                                    cmd3.Parameters.AddWithValue("@day", day);
                                    if (cmd3.ExecuteNonQuery() > 0)
                                    {
                                        using (SqlCommand cmd4 = new SqlCommand("UPDATE REVENUE_REPORT " +
                                            "SET RevenueTotal = RevenueTotal + @plus WHERE ReportNo = @Id", sql))
                                        {
                                            cmd4.Parameters.AddWithValue("@plus", total - oldRevenue);
                                            cmd4.Parameters.AddWithValue("@Id", Id);
                                            if (cmd4.ExecuteNonQuery() > 0)
                                            {
                                                if (!silent) MessageBox.Show("Add new day report successfully", 
                                                    "SUCCESS", MessageBoxButtons.OK);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                using (SqlCommand cmd3 = new SqlCommand("Insert into REVENUE_REPORT_DETAIL(ReportNo,Day,DayRevenue,AmoutOfWedding) values(@id, @day, @rday, @amout)", sql))
                                {
                                    cmd3.Parameters.AddWithValue("@id", Id);
                                    cmd3.Parameters.AddWithValue("@day", day);
                                    cmd3.Parameters.AddWithValue("@rday", total);
                                    cmd3.Parameters.AddWithValue("@amout", count);
                                    if (cmd3.ExecuteNonQuery() > 0)
                                    {
                                        using (SqlCommand cmd4 = new SqlCommand("UPDATE REVENUE_REPORT " +
                                            "SET RevenueTotal = RevenueTotal + @plus WHERE ReportNo = @Id", sql))
                                        {
                                            cmd4.Parameters.AddWithValue("@plus", total);
                                            cmd4.Parameters.AddWithValue("@Id", Id);
                                            if (cmd4.ExecuteNonQuery() > 0)
                                            {
                                                if (!silent) MessageBox.Show("Add new day report successfully!", 
                                                    "SUCCESS", MessageBoxButtons.OK);
                                            }
                                        }
                                    }
                                }
                            }
                            reader.Close();
                        }
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search_rpDay_Click(object sender, EventArgs e)
        {
            if (rBtn_day.Checked)
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT D.ReportNo, D.Day, R.Month, D.DayRevenue, R.RevenueTotal, D.AmoutOfWedding " +
                        "FROM REVENUE_REPORT R, REVENUE_REPORT_DETAIL D WHERE D.ReportNo = R.ReportNo AND D.Day LIKE @searchRPD";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchRPD", "%" + tb_seacrh_rpDay.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            DataColumn[] keys = new DataColumn[2];
                            keys[0] = table1.Columns["ReportNo"];
                            keys[1] = table1.Columns["Day"];
                            table1.PrimaryKey = keys;
                            table1.Columns[0].ColumnMapping = MappingType.Hidden;
                            table1.Columns[1].Caption = "Day";
                            table1.Columns[2].Caption = "Month";
                            table1.Columns[3].Caption = "Day Revenue";
                            table1.Columns[4].Caption = "Month Revenue";
                            table1.Columns[5].Caption = "Amout Of Wedding";
                            DataColumn column = new DataColumn("Ratio", typeof(float));
                            column.Caption = "Ratio";
                            table1.Columns.Add(column);
                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["Ratio"] = Convert.ToSingle(table1.Rows[i]["DayRevenue"]) / 
                                    Convert.ToSingle(table1.Rows[i]["RevenueTotal"]);
                            }
                            dataRPD.DataSource = table1;
                            foreach (DataGridViewColumn col in dataRPD.Columns)
                            {
                                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
                            }
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    string sqlquery = "SELECT D.ReportNo, D.Day, R.Month, D.DayRevenue, R.RevenueTotal, D.AmoutOfWedding " +
                                        "FROM REVENUE_REPORT R, REVENUE_REPORT_DETAIL D WHERE D.ReportNo = R.ReportNo " +
                                        "AND D.AmoutOfWedding LIKE @searchRPD";
                    sqlconn.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                    {
                        sqlcomm.Parameters.AddWithValue("@searchRPD", "%" + tb_seacrh_rpDay.Text + "%");
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                        {
                            table1 = new DataTable();
                            sqlDataAdapter.Fill(table1);
                            DataColumn[] keys = new DataColumn[2];
                            keys[0] = table1.Columns["ReportNo"];
                            keys[1] = table1.Columns["Day"];
                            table1.PrimaryKey = keys;
                            table1.Columns[0].ColumnMapping = MappingType.Hidden;
                            table1.Columns[1].Caption = "Day";
                            table1.Columns[2].Caption = "Month";
                            table1.Columns[3].Caption = "Day Revenue";
                            table1.Columns[4].Caption = "Month Revenue";
                            table1.Columns[5].Caption = "Amout Of Wedding";
                            DataColumn column = new DataColumn("Ratio", typeof(float));
                            column.Caption = "Ratio";
                            table1.Columns.Add(column);
                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["Ratio"] = Convert.ToSingle(table1.Rows[i]["DayRevenue"]) /
                                    Convert.ToSingle(table1.Rows[i]["RevenueTotal"]);
                            }
                            dataRPD.DataSource = table1;
                            foreach (DataGridViewColumn col in dataRPD.Columns)
                            {
                                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
                            }
                        }
                    }
                }
            }
        }

        private void dataRPD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataRPD.Rows.Count - 1)
            {
                return;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataRow selectedRow = table1.Rows[
                    table1.Rows.IndexOf(
                        ((DataRowView)dataRPD.Rows[e.RowIndex].DataBoundItem).Row)
                    ];

                comboBoxDay.Text = selectedRow["Day"].ToString();
                comboBoxMonth.Text = selectedRow["Month"].ToString();
                textBoxYear.Text = selectedRow["Year"].ToString();
                textBoxDayRevenue.Text = selectedRow["DayRevenue"].ToString();
                textBoxAOW.Text = selectedRow["AmoutOfWedding"].ToString();
            }
        }
    }
}