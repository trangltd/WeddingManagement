using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WeddingManagement
{
    public partial class FormMenu : Form
    {
        public static string currentTypeId = "";
        Point lastPoint = new Point();
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;

        public FormMenu()
        {
            InitializeComponent();
        }
        void load_data_Dishes()
        {
            table = new DataTable();

            // first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ItemName";
            column.AutoIncrement = false;
            column.Caption = "Item name";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            // second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ItemPrice";
            column.AutoIncrement = false;
            column.Caption = "Item price";
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
            column.ColumnName = "ItemNo";
            column.AutoIncrement = false;
            column.Caption = "ItemNo";
            column.ReadOnly = true;
            column.Unique = true;
            column.ColumnMapping = MappingType.Hidden;
            table.Columns.Add(column);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["ItemNo"];
            table.PrimaryKey = keys;

            dgv_menu.DataSource = table;
            dgv_menu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_menu.AllowUserToAddRows = false;
            foreach (DataGridViewColumn col in dgv_menu.Columns)
            {
                col.HeaderText = table.Columns[col.DataPropertyName].Caption;
            }


            List<Item> dishes = new List<Item>();
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MENU WHERE Available > 0" +
                    " ORDER BY ItemName", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dishes.Add(
                                new Item(
                                    reader["ItemNo"].ToString(), 
                                    reader["ItemName"].ToString(), 
                                    Convert.ToInt64(reader["ItemPrice"]), 
                                    reader["Note"].ToString()
                                    )
                                );
                        }
                    }
                }
            }
            WeddingClient.listItems = dishes;

            foreach (Item Item in dishes)
            {
                row = table.NewRow();
                row["ItemNo"] = Item.ItemNo;
                row["ItemName"] = Item.ItemName;
                row["ItemPrice"] = Item.ItemPrice;
                row["Note"] = Item.Note;
                table.Rows.Add(row);
            }
        }

        private void dgv_menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= table.Rows.Count)
            {
                currentTypeId = "";
                return;
            }

            var rowItem = (DataRowView)dgv_menu.Rows[e.RowIndex].DataBoundItem;
            int i = table.Rows.IndexOf(rowItem.Row);
            DataRow row = table.Rows[i];
            cbt_item_name.Text = row[0].ToString();
            cbt_item_price.Text = row[1].ToString();
            cbt_item_note.Text = row[2].ToString();

            if (i < WeddingClient.listItems.Count)
            {
                currentTypeId = WeddingClient.listItems[i].ItemNo;
            }
            else
            {
                currentTypeId = "";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_item_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (cbt_item_name.Text == "" || cbt_item_price.Text == "")
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
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO MENU (ItemNo, " +
                                "ItemName, ItemPrice, Note, Available) VALUES (@ItemNo, " +
                                "@ItemName, @ItemPrice, @Note, 1)", sql))
                            {
                                string newDishesId = "MN" + WeddingClient.GetNewIdFromTable("MN").ToString().PadLeft(19, '0');
                                cmd.Parameters.AddWithValue("@ItemNo", newDishesId);
                                cmd.Parameters.AddWithValue("@ItemName", cbt_item_name.Text);
                                cmd.Parameters.AddWithValue("@ItemPrice", cbt_item_price.Text);
                                cmd.Parameters.AddWithValue("@Note", cbt_item_note.Text);

                                if (cmd.ExecuteNonQuery() > 0)
                                {

                                    row = table.NewRow();
                                    row["ItemName"] = cbt_item_name.Text;
                                    row["ItemPrice"] = cbt_item_price.Text;
                                    row["Note"] = cbt_item_note.Text;
                                    row["ItemNo"] = newDishesId;
                                    table.Rows.Add(row);
                                    MessageBox.Show("Add successfully", "SUCCESS", MessageBoxButtons.OK);
                                    WeddingClient.listItems.Add(
                                        new Item(
                                            newDishesId, 
                                            cbt_item_name.Text, 
                                            Convert.ToInt64(cbt_item_price.Text), 
                                            cbt_item_note.Text)
                                        );

                                    load_data_Dishes();
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

        private void btn_delete_item_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (currentTypeId == "")
                {
                    MessageBox.Show("Please select a item to delete!");
                }
                else
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE MENU SET Available = 0 WHERE ItemNo = @ItemNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@ItemNo", currentTypeId);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                foreach (Item dishes in WeddingClient.listItems)
                                {
                                    if (dishes.ItemNo == currentTypeId)
                                    {
                                        WeddingClient.listItems.Remove(dishes);
                                        break;
                                    }
                                }
                                table.Rows.Remove(table.Rows.Find(currentTypeId));
                                MessageBox.Show("Delete successfully!");
                            }
                        }
                    }
                }
                FormMenu.currentTypeId = "";
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                string sqlquery = "SELECT ItemName, ItemPrice, Note FROM MENU " +
                    "WHERE Available > 0 AND (ItemName LIKE @searchMN OR ItemPrice LIKE " +
                    "@searchMN OR Note LIKE @searchMN) ORDER BY ItemName";
                sqlconn.Open();
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlcomm.Parameters.AddWithValue("@searchMN", "%" + cbt_search_item.Text + "%");
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcomm))
                    {
                        table = new DataTable();
                        sqlDataAdapter.Fill(table);
                        dgv_menu.DataSource = table;
                        foreach (DataGridViewColumn col in dgv_menu.Columns)
                        {
                            col.HeaderText = table.Columns[col.DataPropertyName].Caption;
                        }
                    }
                }
            }
        }
        
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

        private void btn_update_item_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (cbt_item_name.Text == "" ||cbt_item_price.Text == "")
                {
                    MessageBox.Show("Please fill out all the fields!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    if (currentTypeId == "")
                    {
                        MessageBox.Show("Please select a item to update!");
                    }
                    else
                    {
                        using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                        {
                            sql.Open();
                            using (SqlCommand cmd = new SqlCommand("UPDATE MENU SET ItemName = @name, ItemPrice = @price, " +
                                "Note = @note WHERE ItemNo = @ItemNo", sql))
                            {
                                cmd.Parameters.AddWithValue("@ItemNo", currentTypeId);
                                cmd.Parameters.AddWithValue("@name", cbt_item_name.Text);
                                cmd.Parameters.AddWithValue("@price", long.Parse(cbt_item_price.Text));
                                cmd.Parameters.AddWithValue("@note", cbt_item_note.Text);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Update successfully!");
                                }
                            }
                        }
                    }
                    FormMenu.currentTypeId = "";
                    load_data_Dishes();
                }
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            load_data_Dishes();

        }
    }
}
