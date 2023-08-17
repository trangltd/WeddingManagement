using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeddingManagement
{
    public partial class FormLobbyType : Form
    {
        public static string currentTypeId = "";
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        void load_data_LobbyType()
        {
            table = new DataTable();
            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name Of Lobby Type";
            column.AutoIncrement = false;
            column.Caption = "Type";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "Min Of Table Price";
            column.AutoIncrement = false;
            column.Caption = "Minimum Table Price";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // third column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LobbyTypeNo";
            column.AutoIncrement = false;
            column.Caption = "LobbyTypeNo";
            column.ReadOnly = true;
            column.Unique = true;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["LobbyTypeNo"];
            table.PrimaryKey = keys;

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;


            List<LobbyType> lobbyTypes = new List<LobbyType>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LOBBY_TYPE WHERE Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lobbyTypes.Add(
                                new LobbyType(
                                    reader["LobbyTypeNo"].ToString(), 
                                    reader["LobbyTypeName"].ToString(), 
                                    Convert.ToInt64(reader["MinTablePrice"])
                                    )
                                );
                        }
                    }
                }
            }
            WeddingClient.listLobbyTypes = lobbyTypes;
            foreach (LobbyType lobbyType in lobbyTypes)
            {
                row = table.NewRow();
                row["Name Of Lobby Type"] = lobbyType.LobbyTypeName;
                row["Min Of Table Price"] = lobbyType.MinTablePrice;
                row["LobbyTypeNo"] = lobbyType.LobbyTypeNo;
                table.Rows.Add(row);
            }
        }
        public FormLobbyType()
        {
            InitializeComponent();
            cbName.SelectedIndex = 0;
        }

        private void FormLobbyType_Load(object sender, EventArgs e)
        {
            load_data_LobbyType();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= table.Rows.Count)
            {
                currentTypeId = "";
                return;
            }
            var rowItem = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            int i = table.Rows.IndexOf(rowItem.Row);
            DataRow row = table.Rows[i];
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                // Lấy giá trị của ô đầu trong dòng đã chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string value = selectedRow.Cells[0].Value.ToString();

                // Binding giá trị với ComboBox
                cbName.Text = value;
            }
            minTable.Text = row[1].ToString();
            if (i < WeddingClient.listLobbyTypes.Count)
            {
                currentTypeId = WeddingClient.listLobbyTypes[i].LobbyTypeNo;
            }
            else
            {
                currentTypeId = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(minTable.Text, out int number))
            {
                // Kiểm tra nếu giá trị nhỏ hơn hoặc bằng 0
                if (number <= 0)
                {
                    MessageBox.Show("The value in the textbox should be a number greater than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    if (WeddingClient.client_priority > 2)
                    {
                        MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (!long.TryParse(minTable.Text, out long price))
                        {
                            MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                        }
                        else
                        {
                            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                            {
                                sql.Open();
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO LOBBY_TYPE (LobbyTypeNo, LobbyTypeName, MinTablePrice, " +
                                    "Available) VALUES (@LobbyTypeNo, @LobbyTypeName, @MinTablePrice, 1)", sql))
                                {
                                    string newTypeId = "LT" + WeddingClient.GetNewIdFromTable("LT").ToString().PadLeft(19, '0');
                                    cmd.Parameters.AddWithValue("@LobbyTypeNo", newTypeId);
                                    cmd.Parameters.AddWithValue("@LobbyTypeName", cbName.Text);
                                    cmd.Parameters.AddWithValue("@MinTablePrice", price);
                                    if (cmd.ExecuteNonQuery() > 0)
                                    {
                                        row = table.NewRow();
                                        row["Name Of Lobby Type"] = cbName.Text;
                                        row["Min Of Table Price"] = price;
                                        row["LobbyTypeNo"] = newTypeId;
                                        table.Rows.Add(row);
                                        MessageBox.Show("New type added!");
                                        WeddingClient.listLobbyTypes.Add(new LobbyType(newTypeId, cbName.Text, price));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Hiển thị thông báo nếu giá trị không hợp lệ
                MessageBox.Show("Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                // check if current type ID is not empty
                if (currentTypeId == "")
                {
                    MessageBox.Show("Please select a type!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE LOBBY_TYPE " +
                            "SET Available = 0 WHERE LobbyTypeNo = @LobbyTypeNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@LobbyTypeNo", currentTypeId);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                foreach (LobbyType lobbyType in WeddingClient.listLobbyTypes)
                                {
                                    if (lobbyType.LobbyTypeNo == currentTypeId)
                                    {
                                        WeddingClient.listLobbyTypes.Remove(lobbyType);
                                        break;
                                    }
                                }
                                table.Rows.Remove(table.Rows.Find(currentTypeId));
                                MessageBox.Show("Type deleted!", "SUCCESS", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                FormLobbyType.currentTypeId = "";
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the value from the textbox
            if (int.TryParse(minTable.Text, out int number))
            {
                // Check if the value is less than or equal to 0
                if (number <= 0)
                {
                    MessageBox.Show("The value in the textbox should be a number greater than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (WeddingClient.client_priority > 2)
                    {
                        MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (!long.TryParse(minTable.Text, out long price))
                        {
                            MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (currentTypeId == "")
                            {
                                MessageBox.Show("Please select a type!", "LACK", MessageBoxButtons.OK);
                            }
                            else
                            {
                                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                                {
                                    sql.Open();
                                    using (SqlCommand cmd = new SqlCommand("UPDATE LOBBY_TYPE " +
                                        "SET LobbyTypeName=@name, MinTablePrice=@price WHERE LobbyTypeNo = @LobbyTypeNo", sql))
                                    {
                                        cmd.Parameters.AddWithValue("@LobbyTypeNo", currentTypeId);
                                        cmd.Parameters.AddWithValue("@name", cbName.Text);
                                        cmd.Parameters.AddWithValue("@price", long.Parse(minTable.Text));
                                        if (cmd.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Type Update!", "SUCCESS", MessageBoxButtons.OK);
                                        }
                                    }
                                }
                            }
                            FormLobbyType.currentTypeId = "";
                            load_data_LobbyType();
                        }
                    }
                }
            }
            else
            {
                // Display an error message if the value is invalid
                MessageBox.Show("Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}