using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeddingManagement
{
    public partial class FormWedding : Form
    {
        public static string currentWeddingNo = "";
        DataTable table1 = new DataTable();

        public FormWedding()
        {
            InitializeComponent();
            load_gridView_wedding();
            load_comboBox_shift();
            load_comboBox_lobby();
            load_comboBox_menu();
            load_comboBox_service();
            date_booking.Value = DateTime.Now;
            date_wedding.Value = DateTime.Now;
        }

        public FormWedding(string id) : this()
        {
            currentWeddingNo = id;
            Load_data_wedding(id);
            date_booking.Value = DateTime.Now;
            date_wedding.Value = DateTime.Now;
        }

        void Load_data_wedding(string id)
        {
            Load_Menu_Detail(id);
            Load_Service_Detail(id);
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                table1.Rows.Clear();
                using (SqlCommand cmd = new SqlCommand("SELECT LobbyName, ShiftName, Representative, PhoneNumber, BookingDate, " +
                    "WeddingDate, BroomName, BrideName, AmountOfTable, AmountOfContingencyTable, TablePrice, Deposit, " +
                    "WD.LobbyNo, S.ShiftNo FROM LOBBY LB, SHIFT S, WEDDING WD WHERE WD.ShiftNo = S.ShiftNo AND " +
                    "WD.LobbyNo = LB.LobbyNo AND WD.WeddingNo = @id", sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cbt_representative.Text = reader.GetString(2);
                            cbt_phone.Text = reader.GetString(3);
                            cbt_broom.Text = reader.GetString(6);
                            cbt_bride.Text = reader.GetString(7);
                            cbt_table.Text = reader.GetInt32(8).ToString();
                            cbt_contigency.Text = reader.GetInt32(9).ToString();
                            cbt_deposit.Text = reader.GetInt64(11).ToString();
                            cbb_lobby.SelectedIndex = WeddingClient.listLobbies.FindIndex(
                                x => x.LobbyNo == reader["LobbyNo"].ToString());
                            cbb_shift.SelectedIndex = WeddingClient.listShifts.FindIndex(
                                x => x.ShiftNo == reader["ShiftNo"].ToString());

                            DataRow row = table1.NewRow();
                            row.ItemArray = new object[] { 
                                reader["LobbyName"].ToString(), 
                                reader["ShiftName"].ToString(),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetDateTime(4).ToString(),
                                reader.GetDateTime(5).ToString(),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetInt32(8).ToString(),
                                reader.GetInt32(9).ToString(), 
                                reader.GetInt64(10).ToString(),
                                reader.GetInt64(11).ToString(), 
                                id 
                            };
                            table1.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void Initial_DataTable()
        {
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lobbyName";
            column.AutoIncrement = false;
            column.Caption = "Lobby name";
            column.ReadOnly = true;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "shiftName";
            column.AutoIncrement = false;
            column.Caption = "Shift Name";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "representative";
            column.AutoIncrement = false;
            column.Caption = "Representative";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "phoneNumber";
            column.AutoIncrement = false;
            column.Caption = "Phone number";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.DateTimeMode = DataSetDateTime.Unspecified;
            column.ColumnName = "bookingDate";
            column.AutoIncrement = false;
            column.Caption = "Booking Date";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.DateTimeMode = DataSetDateTime.Unspecified;
            column.ColumnName = "weddingDate";
            column.AutoIncrement = false;
            column.Caption = "Wedding Date";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "GroomName";
            column.AutoIncrement = false;
            column.Caption = "Groom Name";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "brideName";
            column.AutoIncrement = false;
            column.Caption = "Bride Name";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "amountOfTable";
            column.AutoIncrement = false;
            column.Caption = "Amount Of Table";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "amountOfContingencyTable";
            column.AutoIncrement = false;
            column.Caption = "Amount Of Contingency Table";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "tablePrice";
            column.AutoIncrement = false;
            column.Caption = "Table Price";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "deposit";
            column.AutoIncrement = false;
            column.Caption = "Deposit";
            column.ReadOnly = false;
            column.Unique = false;
            table1.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "WeddingNo";
            column.AutoIncrement = false;
            column.Caption = "WeddingNo";
            column.ReadOnly = false;
            column.Unique = false;
            column.ColumnMapping = MappingType.Hidden;
            table1.Columns.Add(column);
        }

        void load_after_change_menu()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                long minTablePrice = 0;
                long totalItemsPrice = 0;
                Lobby lobby = WeddingClient.listLobbies[cbb_lobby.SelectedIndex];

                string queryUpdate ="UPDATE WEDDING " +
                                    "SET TablePrice = @originalTablePrice + @totalItemsPrice " +
                                    "FROM WEDDING W " +
                                    "WHERE WeddingNo = @weddingno";

                string querySelectMinTablePrice = "SELECT MinTablePrice FROM LOBBY_TYPE WHERE LobbyTypeNo = @LobbyTypeNo";
                string querySelectSumItemPrice = "(SELECT SUM(T.TotalItemsPrice) AS 'Total' FROM TABLE_DETAIL T WHERE T.WeddingNo = @weddingNo)";

                using (SqlCommand cmd = new SqlCommand(querySelectMinTablePrice, sql))
                {
                    cmd.Parameters.AddWithValue("@LobbyTypeNo", lobby.LobbyTypeNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            minTablePrice = Convert.ToInt64(reader["MinTablePrice"]);
                        }
                        reader.Close();
                    }
                }
                long originalTablePrice = minTablePrice * (Convert.ToInt32(cbt_table.Text) + Convert.ToInt32(cbt_contigency.Text));

                using (SqlCommand cmd = new SqlCommand(querySelectSumItemPrice, sql))
                {
                    cmd.Parameters.AddWithValue("@weddingNo", currentWeddingNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalItemsPrice = Convert.ToInt64(reader["Total"]);
                        }
                        reader.Close();
                    }
                }

                using (SqlCommand cmd  = new SqlCommand(queryUpdate, sql)) {
                    cmd.Parameters.AddWithValue("@originalTablePrice", originalTablePrice);
                    cmd.Parameters.AddWithValue("@totalItemsPrice", totalItemsPrice);
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        load_gridView_wedding();
                    }
                }
            }
        }

        void load_gridView_wedding()
        {
            if (table1.Columns.Count == 0)
            {
                Initial_DataTable();
            }

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                table1.Rows.Clear();
                string query = "SELECT LobbyName, ShiftName, Representative, PhoneNumber, " +
                                        "BookingDate, WeddingDate, BroomName, BrideName, AmountOfTable, AmountOfContingencyTable, TablePrice, " +
                                        "Deposit, WeddingNo FROM LOBBY LB, SHIFT S, WEDDING WD WHERE WD.ShiftNo = S.ShiftNo AND " +
                                        "WD.LobbyNo = LB.LobbyNo AND WD.Available > 0";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = table1.NewRow();
                            row.ItemArray = new object[] {
                                        reader["LobbyName"].ToString(),
                                        reader["ShiftName"].ToString(),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetDateTime(4).ToString(),
                                        reader.GetDateTime(5).ToString(),
                                        reader.GetString(6),
                                        reader.GetString(7),
                                        reader.GetInt32(8).ToString(),
                                        reader.GetInt32(9).ToString(),
                                        reader.GetInt64(10).ToString(),
                                        reader.GetInt64(11).ToString(),
                                        reader["WeddingNo"].ToString()
                                    };
                            table1.Rows.Add(row);
                        }
                    }
                }
            }

            dataWedding.DataSource = table1;
            foreach (DataGridViewColumn col in dataWedding.Columns)
            {
                col.HeaderText = table1.Columns[col.DataPropertyName].Caption;
            }
            dataWedding.Columns["bookingDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataWedding.Columns["weddingDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        void load_comboBox_shift()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ShiftNo, ShiftName, Starting, Ending FROM SHIFT " +
                    "where Available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listShifts = new List<Shift>();
                            var dt = new DataTable();
                            dt.Load(dr);
                            cbb_shift.DataSource = dt;
                            cbb_shift.DisplayMember = "ShiftName";
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listShifts.Add(new Shift()
                                {
                                    ShiftNo = row["ShiftNo"].ToString(),
                                    ShiftName = row["ShiftName"].ToString(),
                                    Starting = (TimeSpan)row["Starting"],
                                    Ending = (TimeSpan)row["Ending"]
                                }); ;
                            }
                        }
                    }
                }
            }
        }

        void load_comboBox_lobby()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT LobbyNo, LobbyTypeNo, LobbyName, MaxTable, Note FROM LOBBY " +
                    "WHERE Available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listLobbies = new List<Lobby>();
                            var dt = new DataTable();
                            dt.Load(dr);
                            dr.Dispose();
                            cbb_lobby.DataSource = dt;
                            cbb_lobby.DisplayMember = "LobbyName";
                            foreach (DataRow row in dt.Rows)
                            {
                                WeddingClient.listLobbies.Add(
                                    new Lobby(
                                        row["LobbyNo"].ToString(), 
                                        row["LobbyTypeNo"].ToString(), 
                                        row["LobbyName"].ToString(), 
                                        Convert.ToInt32(row["MaxTable"]), 
                                        row["Note"].ToString()
                                        )
                                    );
                            }
                        }
                    }
                }
            }
        }

        private bool _isDataSourceMenuChanging = false;
        private bool _isDataSourceServiceChanging = false;
        void load_comboBox_menu()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ItemNo, ItemName, ItemPrice FROM MENU " +
                    "where Available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listItems = new List<Item>();
                            var dt = new DataTable();
                            dt.Load(dr);

                            DataView dv = dt.DefaultView;
                            dv.Sort = "ItemName ASC";
                            DataTable sortedDt = dv.ToTable();

                            _isDataSourceMenuChanging = true;
                            cbb_item.DataSource = sortedDt;
                            _isDataSourceMenuChanging = false;
                            cbb_item.DisplayMember = "ItemName";
                            foreach (DataRow row in sortedDt.Rows)
                            {
                                WeddingClient.listItems.Add(new Item()
                                {
                                    ItemNo = (row["ItemNo"]).ToString(),
                                    ItemName = row["ItemName"].ToString(),
                                    ItemPrice = Convert.ToInt64(row["ItemPrice"])
                                });
                            }
                            cbt_price_item.Text = WeddingClient.listItems[0].ItemPrice.ToString() + " VND";
                        }
                    }
                }
            }
        }

        void load_comboBox_service()
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ServiceNo, ServiceName, ServicePrice, Note FROM SERVICE " +
                    "where Available > 0", sql))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            WeddingClient.listServices = new List<Service>();
                            var dt = new DataTable();
                            dt.Load(dr);

                            DataView dv = dt.DefaultView;
                            dv.Sort = "ServiceName ASC";
                            DataTable sortedDt = dv.ToTable();

                            _isDataSourceServiceChanging = true;
                            cbb_service.DataSource = sortedDt;
                            _isDataSourceServiceChanging = false;
                            cbb_service.DisplayMember = "ServiceName";
                            foreach (DataRow row in sortedDt.Rows)
                            {
                                WeddingClient.listServices.Add(new Service()
                                {
                                    ServiceNo = (row["ServiceNo"]).ToString(),
                                    ServiceName = row["ServiceName"].ToString(),
                                    ServicePrice = Convert.ToInt64(row["ServicePrice"]),
                                    Note = row["Note"].ToString()
                                });
                            }
                            cbt_price_service.Text = WeddingClient.listItems[0].ItemPrice.ToString() + " VND";
                        }
                    }
                }
            }
        }

        private void cbb_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isDataSourceMenuChanging) return;
            int index = cbb_item.SelectedIndex;
            Item dishes = WeddingClient.listItems[index];
            cbt_price_item.Text = dishes.ItemPrice.ToString() + " VND";
        }

        private void cbb_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isDataSourceServiceChanging) return;
            int index = cbb_service.SelectedIndex;
            Service service = WeddingClient.listServices[index];
            cbt_price_service.Text = service.ServicePrice.ToString() + " VND";
        }

        private void btn_detail_item_Click(object sender, EventArgs e)
        {
            if (currentWeddingNo != null && currentWeddingNo.Length == 21)
            {
                FormGridViewItem show = new FormGridViewItem(currentWeddingNo);
                show.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a wedding!", "LACK", MessageBoxButtons.OK);
            }
        }

        private void btn_detail_service_Click(object sender, EventArgs e)
        {
            if (currentWeddingNo != null && currentWeddingNo.Length == 21)
            {
                FormGridViewService show = new FormGridViewService(currentWeddingNo);
                show.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a wedding!", "LACK", MessageBoxButtons.OK);
            }
        }

        private void btn_add_menu_Click(object sender, EventArgs e)
        {
            if (currentWeddingNo != null && currentWeddingNo.Length == 21)
            {
                int index = cbb_item.SelectedIndex;
                Item dishes = WeddingClient.listItems[index];
                if (cbt_amount_item.Text.Length > 0 && long.TryParse(cbt_amount_item.Text, out long count))
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        long currentDishesPrice = 0;
                        using (SqlCommand check = new SqlCommand("SELECT AmountOfItems FROM TABLE_DETAIL " +
                            "WHERE WeddingNo = @WeddingNo AND ItemNo = @ItemNo", sql))
                        {
                            check.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                            check.Parameters.AddWithValue("@ItemNo", dishes.ItemNo);
                            using (SqlDataReader reader = check.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    currentDishesPrice = Convert.ToInt32(reader["AmountOfItems"]) * dishes.ItemPrice;
                                }
                                else
                                {
                                    currentDishesPrice = 0;
                                }
                            }
                        }
                        long newDishesPrice = 0;
                        if (currentDishesPrice == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO TABLE_DETAIL (WeddingNo, ItemNo, " +
                                "AmountOfItems, TotalItemsPrice, Note) VALUES (@WeddingNo, @ItemNo, @AmountOfItems, " +
                                "@TotalItemsPrice, @Note)", sql))
                            {
                                cmd.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                cmd.Parameters.AddWithValue("@ItemNo", dishes.ItemNo);
                                cmd.Parameters.AddWithValue("@AmountOfItems", Convert.ToInt32(cbt_amount_item.Text));
                                cmd.Parameters.AddWithValue("@TotalItemsPrice", dishes.ItemPrice *
                                    Convert.ToInt32(cbt_amount_item.Text));
                                cmd.Parameters.AddWithValue("@Note", "");
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    newDishesPrice = dishes.ItemPrice * Convert.ToInt32(cbt_amount_item.Text);
                                    using (SqlCommand cmd2 = new SqlCommand("UPDATE BILL SET TablePriceTotal = " +
                                        "TablePriceTotal + @tableChanged, Total = Total + @tableChanged WHERE " +
                                        "WeddingNo = @WeddingNo", sql))
                                    {
                                        cmd2.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                        cmd2.Parameters.AddWithValue("@tableChanged", newDishesPrice);
                                        if (cmd2.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Add successfully!", "SUCCESS", MessageBoxButtons.OK);
                                            cbt_amount_item.Text = "";
                                            Load_Menu_Detail(currentWeddingNo);
                                            load_after_change_menu();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE TABLE_DETAIL " +
                                "SET AmountOfItems = @AmountOfItems, TotalItemsPrice = @TotalItemsPrice " +
                                "WHERE WeddingNo = @WeddingNo AND ItemNo = @ItemNo", sql))
                            {
                                cmd.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                cmd.Parameters.AddWithValue("@ItemNo", dishes.ItemNo);
                                cmd.Parameters.AddWithValue("@AmountOfItems", Convert.ToInt32(cbt_amount_item.Text));
                                cmd.Parameters.AddWithValue("@TotalItemsPrice", dishes.ItemPrice *
                                    Convert.ToInt32(cbt_amount_item.Text));
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    newDishesPrice = dishes.ItemPrice * Convert.ToInt32(cbt_amount_item.Text);
                                    long changes = newDishesPrice - currentDishesPrice;
                                    using (SqlCommand cmd2 = new SqlCommand("UPDATE BILL " +
                                        "SET TablePriceTotal = TablePriceTotal + @tableChanged, " +
                                        "Total = Total + @tableChanged, MoneyLeft = MoneyLeft + @tableChanged " +
                                        "WHERE WeddingNo = @WeddingNo", sql))
                                    {
                                        cmd2.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                        cmd2.Parameters.AddWithValue("@tableChanged", changes);
                                        if (cmd2.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Add successfully!", "SUCCESS", MessageBoxButtons.OK);
                                            cbt_amount_item.Text = "";
                                            load_after_change_menu();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                }
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please type amount of dish!", "LACK", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please add a wedding to choose dishes!", "LACK", MessageBoxButtons.OK);
            }
        }

        private void btn_add_service_Click(object sender, EventArgs e)
        {
            if (currentWeddingNo != null && currentWeddingNo.Length == 21)
            {
                int index = cbb_service.SelectedIndex;
                Service service = WeddingClient.listServices[index];
                if (cbt_amount_service.Text.Length > 0 && long.TryParse(cbt_amount_service.Text, out long count))
                {
                    using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                    {
                        sql.Open();
                        long currentServicePrice = 0;
                        using (SqlCommand check = new SqlCommand("SELECT AmountOfServices " +
                            "FROM SERVICE_DETAIL WHERE WeddingNo = @WeddingNo AND ServiceNo = @ServiceNo", sql))
                        {
                            check.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                            check.Parameters.AddWithValue("@ServiceNo", service.ServiceNo);
                            using (SqlDataReader reader = check.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    currentServicePrice = Convert.ToInt32(reader["AmountOfServices"]) * service.ServicePrice;
                                }
                                else
                                {
                                    currentServicePrice = 0;
                                }
                            }
                        }
                        long newServicePrice = 0;
                        if (currentServicePrice == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO SERVICE_DETAIL (WeddingNo, ServiceNo, " +
                                "AmountOfServices, TotalServicesPrice, Note) VALUES (@WeddingNo, @ServiceNo, @AmountOfServices, " +
                                "@TotalServicesPrice, @Note)", sql))
                            {
                                cmd.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                cmd.Parameters.AddWithValue("@ServiceNo", service.ServiceNo);
                                cmd.Parameters.AddWithValue("@AmountOfServices", Convert.ToInt32(cbt_amount_service.Text));
                                cmd.Parameters.AddWithValue("@TotalServicesPrice", service.ServicePrice * 
                                    Convert.ToInt32(cbt_amount_service.Text));
                                cmd.Parameters.AddWithValue("@Note", "");
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    newServicePrice = service.ServicePrice * Convert.ToInt32(cbt_amount_service.Text);
                                    using (SqlCommand cmd2 = new SqlCommand("UPDATE BILL " +
                                        "SET ServicePriceTotal = ServicePriceTotal + @serviceChanged, " +
                                        "Total = Total + @serviceChanged, MoneyLeft = MoneyLeft + @serviceChanged " +
                                        "WHERE WeddingNo = @WeddingNo", sql))
                                    {
                                        cmd2.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                        cmd2.Parameters.AddWithValue("@serviceChanged", newServicePrice);
                                        if (cmd2.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Add successfully!", "SUCCESS", MessageBoxButtons.OK);
                                            cbt_amount_service.Text = "";
                                            Load_Service_Detail(currentWeddingNo);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE SERVICE_DETAIL " +
                                "SET AmountOfServices = @AmountOfServices, TotalServicesPrice = @TotalServicesPrice " +
                                "WHERE WeddingNo = @WeddingNo AND ServiceNo = @ServiceNo", sql))
                            {
                                cmd.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                cmd.Parameters.AddWithValue("@ServiceNo", service.ServiceNo);
                                cmd.Parameters.AddWithValue("@AmountOfServices", Convert.ToInt32(cbt_amount_service.Text));
                                cmd.Parameters.AddWithValue("@TotalServicesPrice", service.ServicePrice * Convert.ToInt32(cbt_amount_service.Text));
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    newServicePrice = service.ServicePrice * Convert.ToInt32(cbt_amount_service.Text);
                                    long changes = newServicePrice - currentServicePrice;
                                    using (SqlCommand cmd2 = new SqlCommand("UPDATE BILL " +
                                        "SET ServicePriceTotal = ServicePriceTotal + @serviceChanged, " +
                                        "Total = Total + @serviceChanged, MoneyLeft = MoneyLeft + @serviceChanged " +
                                        "WHERE WeddingNo = @WeddingNo", sql))
                                    {
                                        cmd2.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                                        cmd2.Parameters.AddWithValue("@serviceChanged", changes);
                                        if (cmd2.ExecuteNonQuery() > 0)
                                        {
                                            MessageBox.Show("Add successfully!", "SUCCESS", MessageBoxButtons.OK);
                                            cbt_amount_service.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please type amount of dish!", "LACK", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please add a wedding to choose services!", "LACK", MessageBoxButtons.OK);
            }
        }

        private void btn_add_wedding_Click(object sender, EventArgs e)
        {
            int index = cbb_shift.SelectedIndex;
            if (index < 0 || index > WeddingClient.listShifts.Count)
            {
                MessageBox.Show("Please choose a shift!", "LACK", MessageBoxButtons.OK);
                return;
            }

            Shift shift = WeddingClient.listShifts[index];
            int indexLobby = cbb_lobby.SelectedIndex;
            if (indexLobby < 0 || indexLobby > WeddingClient.listLobbies.Count)
            {
                MessageBox.Show("Please choose a lobby!", "LACK", MessageBoxButtons.OK);
                return;
            }
            Lobby lobby = WeddingClient.listLobbies[indexLobby];

            if (!IsLobbyAvailable(lobby.LobbyNo, shift.ShiftNo))
            {
                MessageBox.Show("This lobby is not available at this shift!", "LACK", MessageBoxButtons.OK);
                return;
            }

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                long typePrice = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT MinTablePrice FROM LOBBY_TYPE " +
                    "WHERE LobbyTypeNo = @LobbyTypeNo", sql))
                {
                    cmd.Parameters.AddWithValue("@LobbyTypeNo", lobby.LobbyTypeNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            typePrice = Convert.ToInt64(reader["MinTablePrice"]);
                        }
                    }
                }
                long basePrice = typePrice * (Convert.ToInt32(cbt_table.Text) + Convert.ToInt32(cbt_contigency.Text));
                string newId = "WD" + WeddingClient.GetNewIdFromTable("WD").ToString().PadLeft(19, '0');
                using (SqlCommand cmd = new SqlCommand("INSERT INTO WEDDING (WeddingNo, LobbyNo, ShiftNo, BookingDate, " +
                    "WeddingDate, PhoneNumber, BroomName, BrideName, AmountOfTable, AmountOfContingencyTable, TablePrice, " +
                    "Deposit, Available, Representative) VALUES (@WeddingNo, @LobbyNo, @ShiftNo, @BookingDate, @WeddingDate, " +
                    "@PhoneNumber, @BroomName, @BrideName, @AmountOfTable, @AmountOfContingencyTable, @TablePrice, @Deposit, 1, " +
                    "@representative )", sql))
                {
                    cmd.Parameters.AddWithValue("@WeddingNo", newId);
                    cmd.Parameters.AddWithValue("@LobbyNo", lobby.LobbyNo);
                    cmd.Parameters.AddWithValue("@ShiftNo", shift.ShiftNo);
                    cmd.Parameters.AddWithValue("@BookingDate", date_booking.Value);
                    cmd.Parameters.AddWithValue("@WeddingDate", date_wedding.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", cbt_phone.Text);
                    cmd.Parameters.AddWithValue("@BroomName", cbt_broom.Text);
                    cmd.Parameters.AddWithValue("@BrideName", cbt_bride.Text);
                    cmd.Parameters.AddWithValue("@AmountOfTable", Convert.ToInt32(cbt_table.Text));
                    cmd.Parameters.AddWithValue("@AmountOfContingencyTable", Convert.ToInt32(cbt_contigency.Text));
                    cmd.Parameters.AddWithValue("@TablePrice", basePrice);
                    cmd.Parameters.AddWithValue("@Deposit", Convert.ToInt64(cbt_deposit.Text));
                    cmd.Parameters.AddWithValue("@representative", cbt_representative.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO BILL (BillNo, " +
                            "WeddingNo, InvoiceDate, TablePriceTotal, ServicePriceTotal, Total, " +
                            "PaymentDate, MoneyLeft) VALUES (@BillNo, @WeddingNo, @InvoiceDate, " +
                            "@TablePricetotal, @ServicePriceTotal, @Total, @PaymentDate, " +
                            "@MoneyLeft)", sql))
                        {
                            string newBillId = "BI" + WeddingClient.GetNewIdFromTable("BI").ToString().PadLeft(19, '0');
                            cmd2.Parameters.AddWithValue("@BillNo", newBillId);
                            cmd2.Parameters.AddWithValue("@WeddingNo", newId);
                            cmd2.Parameters.AddWithValue("@InvoiceDate", date_wedding.Value);
                            cmd2.Parameters.AddWithValue("@TablePricetotal", 0);
                            cmd2.Parameters.AddWithValue("@ServicePriceTotal", 0);
                            cmd2.Parameters.AddWithValue("@Total", basePrice);
                            cmd2.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                            cmd2.Parameters.AddWithValue("@MoneyLeft", basePrice - Convert.ToInt64(cbt_deposit.Text));
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                DataRow row = table1.NewRow();
                                row.ItemArray = new object[] { 
                                    lobby.LobbyName, 
                                    shift.ShiftName, 
                                    cbt_representative.Text, 
                                    cbt_phone.Text, 
                                    date_booking.Value.ToString(), 
                                    date_wedding.Value.ToString(), 
                                    cbt_broom.Text, 
                                    cbt_bride.Text, 
                                    cbt_table.Text, 
                                    cbt_contigency.Text, 
                                    basePrice, 
                                    cbt_deposit.Text, 
                                    newId 
                                };
                                table1.Rows.Add(row);
                                MessageBox.Show("Add wedding successfully!", "SUCCESS", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Fail to add wedding!", "FAIL", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
        }

        private bool IsLobbyAvailable(string LobbyNo, string ShiftNo)
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM WEDDING " +
                    "WHERE LobbyNo = @LobbyNo AND ShiftNo = @ShiftNo AND Available is NULL", sql))
                {
                    cmd.Parameters.AddWithValue("@LobbyNo", LobbyNo);
                    cmd.Parameters.AddWithValue("@ShiftNo", ShiftNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void btn_delete_wedding_Click(object sender, EventArgs e)
        {
            if (currentWeddingNo != null && currentWeddingNo.Length == 21)
            {
                using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE WEDDING set Available = 0 " +
                        "WHERE WeddingNo = @WeddingNo", sql))
                    {
                        cmd.Parameters.AddWithValue("@WeddingNo", currentWeddingNo);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            table1.Rows.RemoveAt(dataWedding.CurrentRow.Index);
                            MessageBox.Show("Wedding deleted!", "SUCCESS", MessageBoxButtons.OK);
                            currentWeddingNo = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a wedding to delete!", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_Menu_Detail(string WeddingNo)
        {
            dgv_menu_detail.Rows.Clear();

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "SELECT m.ItemName, td.AmountOfItems, td.TotalItemsPrice " +
                                "FROM TABLE_DETAIL td " +
                                "INNER JOIN MENU m ON td.ItemNo = m.ItemNo " +
                                "WHERE td.WeddingNo = @WeddingNo";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@WeddingNo", WeddingNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            int amountOfItems = Convert.ToInt32(reader["AmountOfItems"]);
                            long totalItemsPrice = Convert.ToInt64(reader["TotalItemsPrice"]);

                            dgv_menu_detail.Rows.Add(itemName, amountOfItems, totalItemsPrice);
                        }
                    }
                }
            }
        }

        private void Load_Service_Detail(string WeddingNo)
        {
            dgv_service_detail.Rows.Clear();

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "SELECT s.ServiceName, sd.AmountOfServices, sd.TotalServicesPrice " +
                                "FROM SERVICE_DETAIL sd " +
                                "INNER JOIN SERVICE s ON sd.ServiceNo = s.ServiceNo " +
                                "WHERE sd.WeddingNo = @WeddingNo";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@WeddingNo", WeddingNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string serviceName = reader["ServiceName"].ToString();
                            int AmountOfServices = Convert.ToInt32(reader["AmountOfServices"]);
                            long totalServicesPrice = Convert.ToInt64(reader["TotalServicesPrice"]);

                            dgv_service_detail.Rows.Add(serviceName, AmountOfServices, totalServicesPrice);
                        }
                    }
                }
            }
        }

        private void dataWedding_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataWedding.Rows.Count - 1)
            {
                return;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataRow selectedRow = table1.Rows[
                    table1.Rows.IndexOf(
                        ((DataRowView)dataWedding.Rows[e.RowIndex].DataBoundItem).Row)
                    ];
                currentWeddingNo = selectedRow["WeddingNo"].ToString();

                cbt_representative.Text = selectedRow["representative"].ToString();
                cbt_phone.Text = selectedRow["phoneNumber"].ToString();
                date_booking.Value = (DateTime)selectedRow["bookingDate"];
                date_wedding.Value = (DateTime)selectedRow["weddingDate"];
                cbt_broom.Text = selectedRow["GroomName"].ToString();
                cbt_bride.Text = selectedRow["brideName"].ToString();
                cbt_table.Text = selectedRow["amountOfTable"].ToString();
                cbt_contigency.Text = selectedRow["amountOfContingencyTable"].ToString();
                cbt_deposit.Text = selectedRow["deposit"].ToString();
                cbb_shift.Text = selectedRow["shiftName"].ToString();
                cbb_lobby.Text = selectedRow["lobbyName"].ToString();

                Load_Menu_Detail(currentWeddingNo);
                Load_Service_Detail(currentWeddingNo);
            }
        }

        private void Update_Wedding()
        {
            int index = cbb_shift.SelectedIndex;
            if (index < 0 || index > WeddingClient.listShifts.Count)
            {
                MessageBox.Show("Please choose a shift!", "LACK", MessageBoxButtons.OK);
                return;
            }
            Shift shift = WeddingClient.listShifts[index];

            int indexLobby = cbb_lobby.SelectedIndex;
            if (indexLobby < 0 || indexLobby > WeddingClient.listLobbies.Count)
            {
                MessageBox.Show("Please choose a lobby!", "LACK", MessageBoxButtons.OK);
                return;
            }
            Lobby lobby = WeddingClient.listLobbies[indexLobby];

            if (!IsLobbyAvailable(lobby.LobbyNo, shift.ShiftNo))
            {
                MessageBox.Show("This lobby is not available at this shift!", "LACK", MessageBoxButtons.OK);
                return;
            }

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                long typePrice = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT MinTablePrice FROM LOBBY_TYPE " +
                    "WHERE LobbyTypeNo = @LobbyTypeNo", sql))
                {
                    cmd.Parameters.AddWithValue("@LobbyTypeNo", lobby.LobbyTypeNo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            typePrice = Convert.ToInt64(reader["MinTablePrice"]);
                        }
                    }
                }
                long basePrice = typePrice * (Convert.ToInt32(cbt_table.Text) + Convert.ToInt32(cbt_contigency.Text));

                string query = "UPDATE WEDDING SET ShiftNo = @shiftno, LobbyNo = @lobbyno, " +
                                "Representative = @representative, " +
                                "PhoneNumber = @phonenumber, AmountOfTable = @amountoftable," +
                                "AmountOfContingencyTable = @amountofcontingencytable," +
                                "BroomName = @broomname, BrideName = @bridename, TablePrice = @tableprice," +
                                "BookingDate = @bookingdate, WeddingDate = @weddingdate, " +
                                "Deposit = @deposit WHERE WeddingNo = @weddingno";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@shiftno", shift.ShiftNo);
                    cmd.Parameters.AddWithValue("@lobbyno", lobby.LobbyNo);
                    cmd.Parameters.AddWithValue("@representative", cbt_representative.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", cbt_phone.Text);
                    cmd.Parameters.AddWithValue("@amountoftable", cbt_table.Text);
                    cmd.Parameters.AddWithValue("@amountofcontingencytable", cbt_contigency.Text);
                    cmd.Parameters.AddWithValue("@broomname", cbt_broom.Text);
                    cmd.Parameters.AddWithValue("@bridename", cbt_bride.Text);
                    cmd.Parameters.AddWithValue("@bookingdate", date_booking.Value);
                    cmd.Parameters.AddWithValue("@weddingdate", date_wedding.Value);
                    cmd.Parameters.AddWithValue("@tableprice", basePrice);
                    cmd.Parameters.AddWithValue("@deposit", cbt_deposit.Text);
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Changes have been updated!", "SUCCESS", MessageBoxButtons.OK);
                        table1.Rows.Clear();
                        load_gridView_wedding();
                    }
                    else
                    {
                        MessageBox.Show("Fail to update!", "FAIL", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btn_update_wedding_Click(object sender, EventArgs e)
        {
            Update_Wedding();
        }

        private void dgv_menu_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_menu_detail.Rows[e.RowIndex];

                string value1 = selectedRow.Cells["itemName"].Value.ToString();
                string value2 = selectedRow.Cells["itemAmount"].Value.ToString();
                double column2Value = Convert.ToDouble(selectedRow.Cells["itemAmount"].Value);
                double column3Value = Convert.ToDouble(selectedRow.Cells["itemPrice"].Value);
                double value3 = column3Value / column2Value;

                cbb_item.Text = value1;
                cbt_amount_item.Text = value2;
                cbt_price_item.Text = value3.ToString();
            }
        }

        private void dgv_service_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_service_detail.Rows[e.RowIndex];

                string value1 = selectedRow.Cells["serviceName"].Value.ToString();
                string value2 = selectedRow.Cells["serviceAmount"].Value.ToString();
                double column2Value = Convert.ToDouble(selectedRow.Cells["serviceAmount"].Value);
                double column3Value = Convert.ToDouble(selectedRow.Cells["servicePrice"].Value);
                double value3 = column3Value / column2Value;

                cbb_service.Text = value1;
                cbt_amount_service.Text = value2;
                cbt_price_service.Text = value3.ToString();
            }
        }

        private void btn_update_item_Click(object sender, EventArgs e)
        {
            int index = cbb_item.SelectedIndex;
            Item item = WeddingClient.listItems[index];

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "UPDATE TABLE_DETAIL " +
                                "SET AmountOfItems = @amountofitems, " +
                                "TotalItemsPrice = @totalitemsprice " +
                                "WHERE WeddingNo = @weddingno AND ItemNo = @itemno";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@amountofitems", 
                        Convert.ToInt32(cbt_amount_item.Text));
                    cmd.Parameters.AddWithValue("@totalitemsprice", 
                        Convert.ToInt32(cbt_amount_item.Text) * Convert.ToInt32(cbt_price_item.Text));
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);
                    cmd.Parameters.AddWithValue("@itemno", item.ItemNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Changes have been updated!", "SUCCESS", MessageBoxButtons.OK);
                        load_after_change_menu();
                        Load_Menu_Detail(currentWeddingNo);
                    }
                    else
                    {
                        MessageBox.Show("Fail to update!", "FAIL", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btn_update_service_Click(object sender, EventArgs e)
        {
            int index = cbb_service.SelectedIndex;
            Service service = WeddingClient.listServices[index];

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "UPDATE SERVICE_DETAIL " +
                                "SET AmountOfServices = @amountofservices, " +
                                "TotalServicesPrice = @totalservicesprice " +
                                "WHERE WeddingNo = @weddingno AND ServiceNo = @serviceno";
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@amountofservices",
                        Convert.ToInt32(cbt_amount_service.Text));
                    cmd.Parameters.AddWithValue("@totalservicesprice",
                        Convert.ToInt32(cbt_amount_service.Text) * 
                        Convert.ToInt32(cbt_price_service.Text)
                        );
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);
                    cmd.Parameters.AddWithValue("@serviceno", service.ServiceNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Changes have been updated!", "SUCCESS", MessageBoxButtons.OK);
                        Load_Service_Detail(currentWeddingNo);
                    }
                    else
                    {
                        MessageBox.Show("Fail to update!", "FAIL", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btn_delete_item_Click(object sender, EventArgs e)
        {
            int index = cbb_item.SelectedIndex;
            Item item = WeddingClient.listItems[index];

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "DELETE FROM TABLE_DETAIL " +
                                "WHERE WeddingNo = @weddingno AND ItemNo = @itemno";

                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);
                    cmd.Parameters.AddWithValue("@itemno", item.ItemNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successful delete!", "SUCCESS", MessageBoxButtons.OK);
                        load_after_change_menu();
                        Load_Menu_Detail(currentWeddingNo);
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete!", "FAIL", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btn_delete_service_Click(object sender, EventArgs e)
        {
            int index = cbb_service.SelectedIndex;
            Service service = WeddingClient.listServices[index];

            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "DELETE FROM SERVICE_DETAIL " +
                                "WHERE WeddingNo = @weddingno AND ServiceNo = @serviceno";

                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@weddingno", currentWeddingNo);
                    cmd.Parameters.AddWithValue("@serviceno", service.ServiceNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successful delete!", "SUCCESS", MessageBoxButtons.OK);
                        Load_Service_Detail(currentWeddingNo);
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete!", "FAIL", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
