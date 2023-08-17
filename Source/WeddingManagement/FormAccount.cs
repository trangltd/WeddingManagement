using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace WeddingManagement
{
    public partial class FormAccount : Form
    {
        DataTable table = new DataTable();
        public long selectedId = -1;
        public FormAccount()
        {
            InitializeComponent();
            if (WeddingClient.client_priority == 0)
            {
                cbb_level.DataSource = new string[] { "Director", "Manager", "Employee" };
                cbb_level.SelectedIndex = 2;
            }
            else if (WeddingClient.client_priority == 1)
            {
                cbb_level.DataSource = new string[] { "Manager", "Employee" };
                cbb_level.SelectedIndex = 1;
            }
            else if (WeddingClient.client_priority == 2)
            {
                cbb_level.DataSource = new string[] { "Employee" };
                cbb_level.SelectedIndex = 0;
            }
            else
            {
                cbb_level.DataSource = new string[] { };
                cbb_level.SelectedIndex = -1;
            }
            gv_act.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gv_act.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Reset();
        }

        private void Reset()
        {
            tb_username.Text = "";
            tb_password.Text = "";
            tb_name.Text = "";
            tb_iden.Text = "";
            this.table = new DataTable();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT AccountNo, Username, Name, Priority, Identification, Password " +
                    "FROM ACCOUNT WHERE Priority > @myPriority", sql))
                {
                    cmd.Parameters.AddWithValue("@myPriority", WeddingClient.client_priority);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    table.Columns[0].ColumnMapping = MappingType.Hidden;
                    table.Columns[5].Caption = "Password";
                    gv_act.DataSource = table;
                    gv_act.Columns["Password"].HeaderText = "Password";
                }
            }
        }
        private void btn_update_account_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Please select an account"); return; }
            bool reset = false;
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string inputText = tb_iden.Text;
                Regex regex = new Regex("^[0-9]+$");

                if (regex.IsMatch(inputText))
                {
                    if (tb_password.Text == "")
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE ACCOUNT SET Username = @username, Name = @name, Priority = @priority, " +
                            "Identification = @identification WHERE AccountNo = @accountno", sql))
                        {
                            cmd.Parameters.AddWithValue("@accountno", selectedId);
                            cmd.Parameters.AddWithValue("@username", tb_username.Text);
                            cmd.Parameters.AddWithValue("@name", tb_name.Text);
                            cmd.Parameters.AddWithValue("@priority", cbb_level.SelectedIndex + 1 + WeddingClient.client_priority);
                            cmd.Parameters.AddWithValue("@identification", tb_iden.Text);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                reset = true;
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE ACCOUNT SET Username = @username, Name = @name, Priority = @priority, " +
                            "Identification = @identification, Password = @password WHERE AccountNo = @accountno", sql))
                        {
                            cmd.Parameters.AddWithValue("@accountno", selectedId);
                            cmd.Parameters.AddWithValue("@username", tb_username.Text);
                            cmd.Parameters.AddWithValue("@name", tb_name.Text);
                            cmd.Parameters.AddWithValue("@priority", cbb_level.SelectedIndex + 1 + WeddingClient.client_priority);
                            cmd.Parameters.AddWithValue("@identification", tb_iden.Text);
                            cmd.Parameters.AddWithValue("@password", CryptSharp.Crypter.Blowfish.Crypt(tb_password.Text));
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                reset = true;
                            }
                        }
                    }
                } else
                {
                    MessageBox.Show("Identification must not contain letter!!!");
                    return;
                }

                
            }
            if (reset)
            {
                Reset();
            }
        }
        private void btn_add_account_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "")
            {
                MessageBox.Show("Username is not empty!!!");
                return;
            }

            if (tb_password.Text == "")
            {
                MessageBox.Show("Password is not empty!!!");
                return;
            }

            if (tb_name.Text == "")
            {
                MessageBox.Show("Name is not empty!!!");
                return;
            }

            if (tb_iden.Text == "")
            {
                MessageBox.Show("Identification is not empty!!!");
                return;
            }

            string inputText = tb_iden.Text;
            Regex regex = new Regex("^[0-9]+$");

            if (regex.IsMatch(inputText))
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE " +
                        "Username = @username", sql))
                    {
                        cmd.Parameters.AddWithValue("@username", tb_username.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Username already exists!");
                                return;
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ACCOUNT WHERE " +
                        "Identification = @identification", sql))
                    {
                        cmd.Parameters.AddWithValue("@identification", tb_iden.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("identification already exists!");
                                return;
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO ACCOUNT (AccountNo, Username, " +
                        "Name, Password, Priority, Identification) VALUES (@accountno, @username, @name, " +
                        "@password, @priority, @identification)", sql))
                    {
                        long newId = WeddingClient.GetNewACCOUNTSId();
                        string newPass = tb_password.Text == "" ? CryptSharp.Crypter.Blowfish.Crypt("123") :
                            CryptSharp.Crypter.Blowfish.Crypt(tb_password.Text);
                        cmd.Parameters.AddWithValue("@accountno", newId);
                        cmd.Parameters.AddWithValue("@username", tb_username.Text);
                        cmd.Parameters.AddWithValue("@name", tb_name.Text);
                        cmd.Parameters.AddWithValue("@identification", tb_iden.Text);
                        cmd.Parameters.AddWithValue("@password", newPass);
                        cmd.Parameters.AddWithValue("@priority", WeddingClient.client_priority + cbb_level.SelectedIndex + 1);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            DataRow row = table.NewRow();
                            row["AccountNo"] = newId;
                            row["Username"] = tb_username.Text;
                            row["Name"] = tb_name.Text;
                            row["Identification"] = tb_iden.Text;
                            row["Password"] = newPass;
                            row["Priority"] = cbb_level.SelectedIndex + 1 + WeddingClient.client_priority;
                            table.Rows.Add(row);
                            gv_act.DataSource = table;
                            MessageBox.Show("Account created!");
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Identification must not contain letter!!!");
                return;
            }
        }
        private void btn_delete_account_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Please select an account"); return; }
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ACCOUNT WHERE AccountNo = @accountno", sql))
                {
                    cmd.Parameters.AddWithValue("@accountno", selectedId);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        DataRow[] rows = table.Select("AccountNo = " + selectedId);
                        foreach (DataRow row in rows)
                        {
                            table.Rows.Remove(row);
                        }
                        gv_act.DataSource = table;

                        MessageBox.Show("Account deleted!");
                    }
                }
            }
            selectedId = -1;
        }
        private void gv_act_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gv_act.Rows.Count)
            {
                selectedId = -1;
                return;
            }
            var rowItem = (DataRowView)gv_act.Rows[e.RowIndex].DataBoundItem;
            int i = table.Rows.IndexOf(rowItem.Row);
            DataRow row = table.Rows[i];
            selectedId = (long)row["AccountNo"];
            tb_username.Text = row["Username"].ToString();
            tb_password.Text = "";
            cbb_level.SelectedIndex = (short)row["Priority"] - WeddingClient.client_priority - 1;
            tb_name.Text = row["Name"].ToString();
            tb_iden.Text = row["Identification"].ToString();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_username.Text.Trim())
                && string.IsNullOrEmpty(tb_name.Text.Trim())
                && string.IsNullOrEmpty(tb_iden.Text.Trim()))
            {
                this.table = new DataTable();
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT AccountNo, Username, Name, Priority, " +
                        "Identification, Password FROM ACCOUNT WHERE Priority = @priority", sql))
                    {
                        var level = cbb_level.SelectedItem.ToString();
                        int priority = -1;

                        if (level == "Director")
                        {
                            priority = 1;
                        } else if (level == "Manager")
                        {
                            priority = 2;
                        } else
                        {
                            priority = 3;
                        }

                        cmd.Parameters.AddWithValue("@priority", priority);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);
                        table.Columns[0].ColumnMapping = MappingType.Hidden;
                        table.Columns[5].Caption = "Password";
                        gv_act.DataSource = table;
                        gv_act.Columns["Password"].HeaderText = "Password";
                    }
                }
            } else
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    this.table = new DataTable();
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT AccountNo, Username, Name, Priority, " +
                        "Identification, Password FROM ACCOUNT WHERE Priority > @priority AND " +
                        "(Username LIKE @searchACC OR Name LIKE @searchACC OR Identification " +
                        "LIKE @searchACC)", sql))
                    {
                        var search_acc = "";
                        if (!string.IsNullOrEmpty(tb_username.Text.Trim()))
                        {
                            search_acc = tb_username.Text;
                        }
                        else if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
                        {
                            search_acc = tb_name.Text;
                        }
                        else if (!string.IsNullOrEmpty(tb_iden.Text.Trim()))
                        {
                            search_acc = tb_iden.Text;
                        }

                        cmd.Parameters.AddWithValue("@searchACC", "%" + search_acc + "%");
                        cmd.Parameters.AddWithValue("@priority", WeddingClient.client_priority);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);
                        table.Columns[0].ColumnMapping = MappingType.Hidden;
                        table.Columns[5].Caption = "Password";
                        gv_act.DataSource = table;
                        gv_act.Columns["Password"].HeaderText = "Password";
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}