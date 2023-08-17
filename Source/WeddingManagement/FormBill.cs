using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WeddingManagement
{
    public partial class FormBill : Form
    {
        public FormBill()
        {
            InitializeComponent();
            tb_lobby_price.ReadOnly = true;
            tb_moneyLeft.ReadOnly = true;
            tb_penalty.ReadOnly = false;
            tb_phone.ReadOnly = true;
            tb_representative.ReadOnly = true;
            tb_serviceTotal.ReadOnly = true;
            tb_tableTotal.ReadOnly = true;
            tb_total.ReadOnly = true;

            invoiceDTP.Enabled = false;
            invoiceDTP.Value = DateTime.Now;
        }

        private void pay_yes_Click(object sender, EventArgs e)
        {
            this.tb_moneyLeft.Text = "0";
        }

        private void pay_no_Click(object sender, EventArgs e)
        {
            if (rBtn_yes.Checked)
            {
                tb_moneyLeft.Text = penaltyTotal.ToString();
            }
            else
            {
                if (currentMoneyLeft > 0)
                    tb_moneyLeft.Text = baseTotal.ToString();
                else
                    tb_moneyLeft.Text = "0";
            }
        }

        public string id;
        public long currentMoneyLeft = 0;

        public FormBill(string id) : this()
        {
            invoiceDTP.Value = DateTime.Now;

            this.id = id;
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Value FROM PARAMETER WHERE ParamaterNo = 'PenaltyRate'", sql))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_penalty.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (SqlCommand sqlcomm = new SqlCommand("SELECT W.Representative, W.PhoneNumber, W.TablePrice, B.TablePriceTotal, " +
                    "B.ServicePriceTotal, B.Total, B.InvoiceDate, B.PaymentDate, B.MoneyLeft FROM BILL B, WEDDING W " +
                    "WHERE B.WeddingNo = W.WeddingNo AND BillNo = @id", sql))
                {
                    sqlcomm.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = sqlcomm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_representative.Text = reader.GetString(0);
                            tb_phone.Text = reader.GetString(1);
                            tb_lobby_price.Text = reader.GetInt64(2).ToString();
                            tb_tableTotal.Text = reader.GetInt64(3).ToString();
                            tb_serviceTotal.Text = reader.GetInt64(4).ToString();
                            tb_total.Text = reader.GetInt64(5).ToString();
                            baseTotal = reader.GetInt64(5);
                            invoiceDTP.Value = reader.GetDateTime(6);
                            paymentDTP.Value = reader[7] != DBNull.Value ? reader.GetDateTime(7) : DateTime.Now;
                            tb_moneyLeft.Text = reader.GetInt64(8).ToString();
                            this.currentMoneyLeft = reader.GetInt64(8);
                            if (currentMoneyLeft <= 0)
                            {
                                rBtn_yes.Enabled = false;
                                rBtn_no.Enabled = false;
                                pay_yes.Enabled = false;
                                pay_no.Enabled = false;
                                rBtn_yes.Checked = false;
                                rBtn_no.Checked = false;
                                pay_yes.Checked = false;
                                pay_no.Checked = false;
                                tb_penalty.ReadOnly = true;
                                paymentDTP.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not found invoice");
                            this.Close();
                        }
                    }
                }
                //Load Menu and Service
                string query_menu = "SELECT M.ItemNo, M.ItemName, TD.AmountOfItems, M.ItemPrice, " +
                                    "(M.ItemPrice * TD.AmountOfItems) AS 'Total' " +
                                    "FROM WEDDING W JOIN TABLE_DETAIL TD ON W.WeddingNo = TD.WeddingNo " +
                                    "JOIN MENU M ON M.ItemNo = TD.ItemNo " +
                                    "JOIN BILL B ON W.WeddingNo = B.WeddingNo " +
                                    "WHERE B.BillNo = @billno;";
                using (SqlCommand cmd_menu = new SqlCommand(query_menu, sql))
                {
                    cmd_menu.Parameters.AddWithValue("@billno", id);
                    using (SqlDataReader reader = cmd_menu.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv_menu.Rows.Add(reader["ItemNo"].ToString(),
                                                 reader["ItemName"].ToString(),
                                                 Convert.ToInt32(reader["AmountOfItems"]),
                                                 Convert.ToInt64(reader["ItemPrice"]),
                                                 Convert.ToInt64(reader["Total"])
                                                  );
                        }
                    }
                }

                string query_service = "SELECT S.ServiceNo, S.ServiceName, SD.AmountOfServices, S.ServicePrice, " +
                                        "(S.ServicePrice * SD.AmountOfServices) AS 'Total' " +
                                        "FROM WEDDING W JOIN SERVICE_DETAIL SD ON W.WeddingNo = SD.WeddingNo " +
                                        "JOIN SERVICE S ON S.ServiceNo = SD.ServiceNo " +
                                        "JOIN BILL B ON W.WeddingNo = B.WeddingNo " +
                                        "WHERE B.BillNo = @billno;";
                using (SqlCommand cmd_service = new SqlCommand(query_service, sql))
                {
                    cmd_service.Parameters.AddWithValue("@billno", id);
                    using (SqlDataReader reader = cmd_service.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgv_service.Rows.Add(reader["ServiceNo"].ToString(),
                                                 reader["ServiceName"].ToString(),
                                                 Convert.ToInt32(reader["AmountOfServices"]),
                                                 Convert.ToInt64(reader["ServicePrice"]),
                                                 Convert.ToInt64(reader["Total"])
                                                  );
                        }
                    }
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private long trueBaseTotal;

        public long baseTotal
        {
            get
            {
                return trueBaseTotal;
            }
            set
            {
                trueBaseTotal = value;
            }
        }

        public long penaltyTotal
        {
            get
            {
                TimeSpan timeSpan = paymentDTP.Value - invoiceDTP.Value;
                if (int.TryParse(tb_penalty.Text, out int penalty))
                {
                    return (long)(timeSpan.Days * (penalty * 1.0 / 100) * baseTotal + baseTotal);
                }
                else
                {
                    return baseTotal;
                }
            }
        }

        private void RBtn_yes_Click(object sender, EventArgs e)
        {
            tb_moneyLeft.Text = penaltyTotal.ToString();
        }

        private void RBtn_no_Click(object sender, EventArgs e)
        {
            if (currentMoneyLeft > 0)
                tb_moneyLeft.Text = baseTotal.ToString();
            else
                tb_moneyLeft.Text = "0";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                if (pay_yes.Checked)
                {
                    if (rBtn_yes.Checked && int.TryParse(tb_penalty.Text, out int penalty))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE BILL SET Total = @Total + 500000, PaymentDate = @PaymentDate, " +
                            "MoneyLeft = 0 WHERE BillNo = @BillNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@Total", tb_total.Text);
                            cmd.Parameters.AddWithValue("@PaymentDate", paymentDTP.Value);
                            cmd.Parameters.AddWithValue("@BillNo", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved!");
                        }
                    }
                    else if (rBtn_no.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE BILL SET PaymentDate = @PaymentDate, MoneyLeft = 0 " +
                            "WHERE BillNo = @BillNo", sql))
                        {
                            cmd.Parameters.AddWithValue("@PaymentDate", paymentDTP.Value);
                            cmd.Parameters.AddWithValue("@BillNo", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter penalty");
                    }
                }
                else
                {
                    MessageBox.Show("Saved!");
                    this.Close();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}