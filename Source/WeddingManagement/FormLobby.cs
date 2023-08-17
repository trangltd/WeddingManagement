using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class FormLobby : Form
    {
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        void Load_data_Lobby()
        {
            table = new DataTable();
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Lobby Name";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Lobby Type";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "Max Table";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Note";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lobbyNo";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = true;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lobbyTypeNo";
            column.AutoIncrement = false;
            column.Caption = "LobbyTypeNo";
            column.ReadOnly = true;
            column.Unique = false;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["lobbyNo"];
            table.PrimaryKey = keys;

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            WeddingClient.listLobbyTypes = new List<LobbyType>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LOBBY_TYPE WHERE Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WeddingClient.listLobbyTypes.Add(
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

            lobbyTypeCombobox.DisplayMember = "LobbyTypeName";
            lobbyTypeCombobox.ValueMember = "LobbyTypeNo";
            lobbyTypeCombobox.DataSource = WeddingClient.listLobbyTypes;
            lobbyTypeCombobox.SelectedIndex = 0;

            WeddingClient.listLobbies = new List<Lobby>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT LB.LobbyNo, LT.LobbyTypeNo LobbyTypeNo, LT.LobbyTypeName LobbyTypeName, " +
                    "LB.LobbyName, LB.MaxTable, LB.Note FROM LOBBY LB, LOBBY_TYPE LT WHERE LB.LobbyTypeNo = LT.LobbyTypeNo " +
                    "AND LB.Available > 0", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WeddingClient.listLobbies.Add(
                                new Lobby(reader["LobbyNo"].ToString(), 
                                reader["LobbyTypeNo"].ToString(), 
                                reader["LobbyName"].ToString(), 
                                Convert.ToInt32(reader["MaxTable"]), 
                                reader["Note"].ToString())
                                );
                            row = table.NewRow();
                            row["Lobby Name"] = reader["LobbyName"].ToString();
                            row["Lobby Type"] = reader["LobbyTypeName"].ToString();
                            row["Max Table"] = Convert.ToInt32(reader["MaxTable"]);
                            row["Note"] = reader["Note"].ToString();
                            row["lobbyNo"] = reader["LobbyNo"].ToString();
                            row["lobbyTypeNo"] = reader["LobbyTypeNo"].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
            }
        }

        public static string currentLobbyId = "";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                currentLobbyId = "";
                return;
            }
            var rowItem = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            int index = table.Rows.IndexOf(rowItem.Row);

            DataRow row = table.Rows[index];

            currentLobbyId = row["lobbyNo"].ToString();
            nameTextBox.Text = row["Lobby Name"].ToString();
            maxTableTextBox.Text = (row["Max Table"]).ToString();
            noteTextBox.Text = row["Note"].ToString();

            lobbyTypeCombobox.SelectedIndex = WeddingClient.listLobbyTypes.FindIndex(
                x => x.LobbyTypeNo == row["lobbyTypeNo"].ToString());
        }

        public FormLobby()
        {
            InitializeComponent();
        }
        private Label label2;
        private LinkLabel linkLabel1;
        private GroupBox groupBox1;
        private TextBox maxTableTextBox;
        private ComboBox lobbyTypeCombobox;
        private Button btn_delete;
        private Button btn_add;
        private Panel panel3;
        private Panel panel1;
        private Label label9;


        private void FormLobby_Load(object sender, EventArgs e)
        {
            Load_data_Lobby();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (currentLobbyId == "")
                {
                    MessageBox.Show("Please select a lobby!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE LOBBY SET Available = 0 WHERE LobbyNo = @LobbyNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@LobbyNo", currentLobbyId);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                foreach (Lobby lobby in WeddingClient.listLobbies)
                                {
                                    if (lobby.LobbyNo == currentLobbyId)
                                    {
                                        WeddingClient.listLobbies.Remove(lobby);
                                        break;
                                    }
                                }
                                table.Rows.Remove(table.Rows.Find(currentLobbyId));
                                MessageBox.Show("Delete successfully!", "SUCESS", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                FormLobby.currentLobbyId = "";
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (!int.TryParse(maxTableTextBox.Text, out int maxTable))
                {
                    MessageBox.Show("Max table must be number!", "ERROR", MessageBoxButtons.OK);
                    return;
                }
                if (nameTextBox.Text == "" || maxTableTextBox.Text == "")
                {
                    MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                }
                else if (lobbyTypeCombobox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a lobby type!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO LOBBY (LobbyNo, LobbyTypeNo, LobbyName, MaxTable, Note, " +
                            "Available) VALUES (@LobbyNo, @LobbyTypeNo, @LobbyName, @MaxTable, @Note, 1)", sql))
                        {
                            string idLobbyType = ((LobbyType)lobbyTypeCombobox.SelectedItem).LobbyTypeNo;
                            string newTypeId = "LO" + WeddingClient.GetNewIdFromTable("LO").ToString().PadLeft(19, '0');
                            cmd.Parameters.AddWithValue("@LobbyNo", newTypeId);
                            cmd.Parameters.AddWithValue("@LobbyTypeNo", idLobbyType);
                            cmd.Parameters.AddWithValue("@LobbyName", nameTextBox.Text);
                            cmd.Parameters.AddWithValue("@MaxTable", maxTable);
                            cmd.Parameters.AddWithValue("@Note", noteTextBox.Text);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                row = table.NewRow();
                                row["Lobby Name"] = nameTextBox.Text;
                                row["Lobby Type"] = WeddingClient.listLobbyTypes.Find(
                                    x => { if (x.LobbyTypeNo == idLobbyType) return true; else return false; }).LobbyTypeName;
                                row["Max Table"] = maxTable;
                                row["Note"] = noteTextBox.Text;
                                row["lobbyNo"] = newTypeId;
                                row["lobbyTypeNo"] = idLobbyType;
                                table.Rows.Add(row);
                                MessageBox.Show("Add successfully!");
                                WeddingClient.listLobbies.Add(
                                    new Lobby(
                                        newTypeId, 
                                        idLobbyType, 
                                        nameTextBox.Text, 
                                        maxTable, 
                                        noteTextBox.Text)
                                    );
                            }
                        }
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
                if (!int.TryParse(maxTableTextBox.Text, out int maxTable))
                {
                    MessageBox.Show("Max table must be number!", "ERROR", MessageBoxButtons.OK);
                    return;
                }
                if (nameTextBox.Text == "" || maxTableTextBox.Text == "")
                {
                    MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                }
                else if (lobbyTypeCombobox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a lobby type!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    if (currentLobbyId == "")
                    {
                        MessageBox.Show("Please select a lobby!", "LACK", MessageBoxButtons.OK);
                    }
                    else
                    {
                        using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                        {
                            sql.Open();
                            String ID = "";
                            using (SqlCommand cm = new SqlCommand("SELECT * from LOBBY_TYPE where LobbyTypeName = @name", sql))
                            {
                                cm.Parameters.AddWithValue("@name", lobbyTypeCombobox.Text);
                                SqlDataReader rd = cm.ExecuteReader();
                                while (rd.Read())
                                {
                                    ID = rd["LobbyTypeNo"].ToString();
                                }
                                rd.Close();
                            }

                            using (SqlCommand cmd = new SqlCommand("UPDATE LOBBY SET LobbyTypeNo = @idlt, LobbyName = @name, " +
                                "MaxTable = @table, Note = @note WHERE LobbyNo = @LobbyNo", sql))
                            {
                                cmd.Parameters.AddWithValue("@LobbyNo", currentLobbyId);
                                cmd.Parameters.AddWithValue("@idlt", ID);
                                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                                cmd.Parameters.AddWithValue("@table", int.Parse(maxTableTextBox.Text));
                                cmd.Parameters.AddWithValue("@note", noteTextBox.Text);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Update successfully!", "SUCESS", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                    FormLobby.currentLobbyId = "";
                    Load_data_Lobby();
                }
            }
        }
    }
}