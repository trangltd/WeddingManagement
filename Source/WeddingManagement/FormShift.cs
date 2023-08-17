using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace WeddingManagement
{
    public partial class FormShift : Form
    {
        public delegate void HandleClick(UCShift s);
        public static HandleClick onclick;
        Point lastPoint = new Point();

        public FormShift()
        {
            InitializeComponent();
            onclick = ShiftClick;
            cb_shift.SelectedIndex = 0;
            tbStart.Text = "00:00:00";
            tbEnd.Text = "00:00:00";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (WeddingClient.client_priority > 2)
            {
                MessageBox.Show("You don't have permission to do this!", "NOT PERMIT", MessageBoxButtons.OK);
                return;
            }
            else
            {

                if (this.tbEnd.Text == "" || cb_shift.SelectedItem.ToString() == "" || this.tbStart.Text == "")
                {
                    MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    if (DateTime.TryParseExact(tbStart.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, 
                        out DateTime result) && 
                        DateTime.TryParseExact(tbEnd.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime result2))
                    {
                        DateTime dateTime1 = DateTime.ParseExact(tbStart.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dateTime2 = DateTime.ParseExact(tbEnd.Text, "HH:mm:ss", CultureInfo.InvariantCulture);

                        if (dateTime1 < dateTime2)
                        {
                            UCShift s = new UCShift();
                            s._lbName = cb_shift.SelectedItem.ToString();
                            s._lbStart = this.tbStart.Text;
                            s._lbEnd = this.tbEnd.Text;
                            using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                            {
                                sql.Open();
                                using (SqlCommand command = new SqlCommand("insert into Shift values (@ShiftNo, @Available, @Name, " +
                                    "@Start, @End)", sql))
                                {
                                    string id = "SH" + WeddingClient.GetNewIdFromTable("SH").ToString().PadLeft(19, '0');
                                    s._id = id;
                                    command.Parameters.AddWithValue("@ShiftNo", id);
                                    command.Parameters.AddWithValue("@Available", 1);
                                    command.Parameters.AddWithValue("@Name", s._lbName);
                                    command.Parameters.AddWithValue("@Start", s._lbStart);
                                    command.Parameters.AddWithValue("@End", s._lbEnd);

                                    if (command.ExecuteNonQuery() > 0)
                                    {
                                        flowLayoutPanel1.Controls.Add(s);
                                        tbEnd.Text = "";
                                        cb_shift.Text = "";
                                        tbStart.Text = "";
                                    }
                                    MessageBox.Show("Add new shift successfully!", "SUCCESS", MessageBoxButtons.OK);
                                    cb_shift.SelectedIndex = 0;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Start time must earlier than end time!!!", "FAIL", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start time or End time must have format 00:00:00!!!");
                        return;
                    }
                }
            }
        }

        private void FormShift_Load(object sender, EventArgs e)
        {

            using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand("select * from Shift where Available > 0", sql))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UCShift shift = new UCShift();
                            shift._lbName = reader["ShiftName"].ToString();
                            shift._lbStart = reader["Starting"].ToString();
                            shift._lbEnd = reader["Ending"].ToString();
                            shift._lbStatus = reader["Available"].ToString() == "1" ? "Empty" : "Available";
                            shift._id = reader["ShiftNo"].ToString();
                            this.flowLayoutPanel1.Controls.Add(shift);
                        }
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                if (this.tbEnd.Text == "" || cb_shift.SelectedItem.ToString() == "" || this.tbStart.Text == "")
                {
                    MessageBox.Show("Please fill all the fields!", "LACK", MessageBoxButtons.OK);
                }
                else
                {
                    if (DateTime.TryParseExact(tbStart.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime result) &&
                        DateTime.TryParseExact(tbEnd.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime result2))
                    {
                        DateTime dateTime1 = DateTime.ParseExact(tbStart.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dateTime2 = DateTime.ParseExact(tbEnd.Text, "HH:mm:ss", CultureInfo.InvariantCulture);

                        if (dateTime1 < dateTime2)
                        {
                            int count = 0;
                            UCShift selectedShift = new UCShift();
                            UCShift pre = new UCShift();
                            foreach (var s in this.flowLayoutPanel1.Controls)
                            {
                                selectedShift = s as UCShift;
                                if (selectedShift != null)
                                {

                                    if (selectedShift._btnCheck == true)
                                    {
                                        pre = selectedShift;
                                        count++;
                                    }
                                }
                                if (count > 1)
                                {
                                    MessageBox.Show("Just choose 1 object", "ERROR", MessageBoxButtons.OK);
                                    break;
                                }
                            }
                            if (count == 1)
                            {
                                using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
                                {
                                    sql.Open();
                                    using (SqlCommand command = new SqlCommand("update Shift Set Available = @avl, " +
                                        "ShiftName = @name, Starting = @start, Ending = @end where ShiftNo = @id", sql))
                                    {
                                        command.Parameters.AddWithValue("@id", pre._id);
                                        command.Parameters.AddWithValue("@start", tbStart.Text);
                                        command.Parameters.AddWithValue("@end", tbEnd.Text);
                                        command.Parameters.AddWithValue("@avl", 1);
                                        command.Parameters.AddWithValue("@name", cb_shift.Text);
                                        if (command.ExecuteNonQuery() > 0)
                                        {
                                            this.flowLayoutPanel1.Controls.Clear();
                                            using (SqlCommand command1 = new SqlCommand("select * from Shift where Available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command1.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        UCShift shift = new UCShift();
                                                        shift._lbName = reader["ShiftName"].ToString();
                                                        shift._lbStart = reader["Starting"].ToString();
                                                        shift._lbEnd = reader["Ending"].ToString();
                                                        shift._lbStatus = reader["available"].ToString() == "1" ? "Trống" : "Đã được đặt";
                                                        shift._id = reader["ShiftNo"].ToString();
                                                        this.flowLayoutPanel1.Controls.Add(shift);
                                                    }
                                                }
                                            }
                                            tbEnd.Text = "";
                                            cb_shift.Text = "";
                                            tbStart.Text = "";
                                            MessageBox.Show("Update shift successfully", "SUCCESS", MessageBoxButtons.OK);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Start time must earlier than end time!!!", "FAIL", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start time or End time must have format 00:00:00!!!");
                        return;
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

        private void ShiftClick(UCShift s)
        {
            tbEnd.Text = s._lbEnd;
            cb_shift.Text = s._lbName;
            tbStart.Text = s._lbStart;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var sql = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                sql.Open();
                string query = "select * from wedding where ShiftNo = @shiftno";
                int count = 0;
                UCShift selectedShift = new UCShift();
                UCShift pre = new UCShift();

                foreach (var s in this.flowLayoutPanel1.Controls)
                {
                    selectedShift = s as UCShift;
                    if (selectedShift != null)
                    {

                        if (selectedShift._btnCheck == true)
                        {
                            pre = selectedShift;
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Just choose 1 object", "ERROR", MessageBoxButtons.OK);
                        break;
                    }
                }

                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@shiftno", pre._id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("There exists at least one wedding party using this shift!!!", 
                                "ERROR", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            reader.Close();
                            string delete = "DELETE FROM SHIFT WHERE ShiftNo = @shiftno;";
                            using (SqlCommand cmd2  = new SqlCommand(delete, sql))
                            {
                                cmd2.Parameters.AddWithValue("@shiftno", pre._id);
                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    flowLayoutPanel1.Controls.Clear();
                                    FormShift_Load(sender, e);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}