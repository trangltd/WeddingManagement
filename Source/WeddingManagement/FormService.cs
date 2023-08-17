using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class FormService : Form
    {

        public static string currentServiceId = "";
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        public FormService()
        {
            InitializeComponent();
        }

        void load_data_service()
        {
            table = new DataTable();
            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ServiceName";
            column.AutoIncrement = false;
            column.Caption = "Name";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ServicePrice";
            column.AutoIncrement = false;
            column.Caption = "Price";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Note";
            column.AutoIncrement = false;
            column.Caption = "Note";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // forth column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ServiceNo";
            column.AutoIncrement = false;
            column.Caption = "ServiceNo";
            column.ReadOnly = true;
            column.Unique = true;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["ServiceNo"];
            table.PrimaryKey = keys;

            dataService.DataSource = table;
            dataService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // prevent user from adding new row
            dataService.AllowUserToAddRows = false;
            foreach (DataGridViewColumn col in dataService.Columns)
            {
                col.HeaderText = table.Columns[col.DataPropertyName].Caption;
            }


            List<Service> ser = new List<Service>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SERVICE WHERE " +
                    "Available > 0 ORDER BY ServiceName", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ser.Add(
                                new Service(
                                    reader["ServiceNo"].ToString(), 
                                    reader["ServiceName"].ToString(), 
                                    Convert.ToInt64(reader["ServicePrice"]), 
                                    reader["Note"].ToString()
                                    )
                                );
                        }
                    }
                }
            }
            WeddingClient.listServices = ser;
            foreach (Service serData in ser)
            {
                row = table.NewRow();
                row["ServiceNo"] = serData.ServiceNo;
                row["ServiceName"] = serData.ServiceName;
                row["ServicePrice"] = serData.ServicePrice;
                row["Note"] = serData.Note;
                table.Rows.Add(row);
            }
        }
        private void form_service_load(object sender, EventArgs e)
        {
            load_data_service();
        }
        private void img_close_service_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= table.Rows.Count)
            {
                currentServiceId = "";
                return;
            }
            var rowItem = (DataRowView)dataService.Rows[e.RowIndex].DataBoundItem;
            int i = table.Rows.IndexOf(rowItem.Row);
            DataRow row = table.Rows[i];
            tb_service_name.Text = row[0].ToString();
            tb_service_price.Text = row[1].ToString();
            tb_service_note.Text = row[2].ToString();
            currentServiceId = row[3].ToString();
        }

        private void btn_add_service_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (tb_service_name.Text == "" || tb_service_price.Text == "")
                {
                    MessageBox.Show("Please fill out all the fields!", "LACK", MessageBoxButtons.OK);
                }

                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO SERVICE " +
                                "(ServiceNo, ServiceName, ServicePrice, Note, Available) " +
                                "VALUES (@ServiceNo, @ServiceName, @ServicePrice, @Note, 1)", sql))
                            {
                                string newServiceId = "SV" + WeddingClient.GetNewIdFromTable("SV").ToString().PadLeft(19, '0');
                                cmd.Parameters.AddWithValue("@ServiceNo", newServiceId);
                                cmd.Parameters.AddWithValue("@ServiceName", tb_service_name.Text);
                                cmd.Parameters.AddWithValue("@ServicePrice", tb_service_price.Text);
                                cmd.Parameters.AddWithValue("@Note", tb_service_note.Text);

                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    row = table.NewRow();
                                    row["ServiceName"] = tb_service_name.Text;
                                    row["ServicePrice"] = tb_service_price.Text;
                                    row["Note"] = tb_service_note.Text;
                                    row["ServiceNo"] = newServiceId;
                                    table.Rows.Add(row);
                                    MessageBox.Show("Add successfully!!!", "SUCCESS", MessageBoxButtons.OK);
                                    WeddingClient.listServices.Add(new Service(
                                        newServiceId, 
                                        tb_service_name.Text, 
                                        Convert.ToInt64(tb_service_price.Text), 
                                        tb_service_note.Text)
                                        );

                                    load_data_service();
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Price must be number", "Error", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btn_delete_service_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (currentServiceId == "")
                {
                    MessageBox.Show("Please select a service to delete!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE SERVICE SET Available = 0 WHERE ServiceNo = @ServiceNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@ServiceNo", currentServiceId);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                foreach (Service ser in WeddingClient.listServices)
                                {
                                    if (ser.ServiceNo == currentServiceId)
                                    {
                                        WeddingClient.listServices.Remove(ser);
                                        break;
                                    }
                                }
                                table.Rows.Remove(table.Rows.Find(currentServiceId));
                                MessageBox.Show("Delete successfully!", "LACK", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                FormService.currentServiceId = "";
            }
        }

        private void btn_search_service_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                string sqlquery = "SELECT ServiceName, ServicePrice, Note, ServiceNo FROM " +
                    "SERVICE WHERE ServiceName LIKE @searchSV OR ServicePrice LIKE @searchSV " +
                    "OR Note LIKE @searchSV ORDER BY ServiceName";
                sqlconn.Open();
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlcomm.Parameters.AddWithValue("@searchSV", "%" + tb_search_service.Text + "%");
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                    {
                        table = new DataTable();
                        sqlDataAdapter.Fill(table);
                        DataColumn[] keys = new DataColumn[1];
                        keys[0] = table.Columns["ServiceNo"];
                        table.PrimaryKey = keys;
                        table.Columns["ServiceNo"].ColumnMapping = MappingType.Hidden;
                        dataService.DataSource = table;
                        foreach (DataGridViewColumn col in dataService.Columns)
                        {
                            col.HeaderText = table.Columns[col.DataPropertyName].Caption;
                        }
                    }
                }
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (tb_service_name.Text == "" || tb_service_price.Text == "")
                {
                    MessageBox.Show("Please fill out all the fields!", "LACK", MessageBoxButtons.OK);
                }

                else
                {
                    if (currentServiceId == "")
                    {
                        MessageBox.Show("Please select a service to delete!", "LACK", MessageBoxButtons.OK);
                    }
                    else
                    {
                        using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                        {
                            sql.Open();
                            using (SqlCommand cmd = new SqlCommand("UPDATE SERVICE " +
                                "SET ServiceName=@name,ServicePrice=@price,Note=@note " +
                                "WHERE ServiceNo = @ServiceNo", sql))
                            {
                                cmd.Parameters.AddWithValue("@ServiceNo", currentServiceId);
                                cmd.Parameters.AddWithValue("@price", long.Parse(tb_service_price.Text));
                                cmd.Parameters.AddWithValue("@name", tb_service_name.Text);
                                cmd.Parameters.AddWithValue("@note", tb_service_note.Text);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Update successfully!", "LACK", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                    FormService.currentServiceId = "";
                    load_data_service();
                }
            }
        }
    }
}