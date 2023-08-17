using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeddingManagement
{
    public partial class FormLogin : Form
    {
        Point lastPoint;
        public FormLogin()
        {
            InitializeComponent();
        }
        private void TextBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }
        private void TextBoxPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private bool EmptyTextBoxes()
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) 
                || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                return true;
            }
            return false;
        }
        private bool CheckInvalidUsernameCharacter()
        {
            foreach (char i in usernameTextBox.Text)
            {
                if (!(i >= 48 && i <= 57 || i >= 65 && i <= 90 
                    || i >= 97 && i <= 122 || i == 95))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckInvalidPasswordCharacter()
        {
            foreach (char i in passwordTextBox.Text)
            {
                if (!(i == 33 || i > 34 && i < 38 || i >= 42 && i <= 43 
                    || i == 45 || i >= 48 && i <= 57 || i >= 64 && i <= 90 
                    || i == 94 || i == 95 || i >= 97 && i <= 122))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CorrectPassword()
        {
            bool res = WeddingClient.Logged_in(usernameTextBox.Text, 
                passwordTextBox.Text);
            return res;
        }
        private void ResetTexts()
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
        private void Login(object sender, EventArgs e)
        {
            if (this.EmptyTextBoxes())
            {
                if (EmptyTextBoxes())
                {
                    MessageBox.Show("Something is missing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (CheckInvalidUsernameCharacter())
                {
                    MessageBox.Show("Invalid username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (CheckInvalidPasswordCharacter())
                    {
                        MessageBox.Show("Invalid characters in password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!CorrectPassword())
                        {
                            MessageBox.Show("Incorrect password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            var frm = new FormHome();
            frm.Location = new System.Drawing.Point(Screen.FromControl(this).WorkingArea.Width / 4, Screen.FromControl(this).WorkingArea.Height / 4);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.ResetTexts();
            frm.Show();
            this.Hide();
            Program.mainform = frm;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                connection.Open();

                // Kiểm tra nếu bảng login chưa tồn tại thì tạo bảng mới
                using (var command = new SqlCommand("IF NOT EXISTS (SELECT * FROM sys.tables " +
                    "WHERE name='login') CREATE TABLE login (username VARCHAR(50), password " +
                    "VARCHAR(50), remember_me BIT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Kiểm tra xem có thông tin đăng nhập trong cơ sở dữ liệu hay không
                using (var command = new SqlCommand("SELECT * FROM login WHERE remember_me = 1", 
                    connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString(0);
                            string password = reader.GetString(1);

                            // Hiển thị thông tin đăng nhập trên giao diện người dùng
                            usernameTextBox.Text = username;
                            passwordTextBox.Text = password;
                            rememberMeCheckBox.Checked = true;
                        }
                    }
                }
            }

            usernameTextBox.Select();
            usernameTextBox.SelectionStart = usernameTextBox.Text.Length;
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Kết nối đến cơ sở dữ liệu SQL Server
            using (SqlConnection connection = new SqlConnection(WeddingClient.sqlConnectionString))
            {
                connection.Open();

                // Tạo bảng để lưu trữ thông tin đăng nhập
                using (var command = new SqlCommand("IF OBJECT_ID('login') IS NULL CREATE TABLE " +
                    "login(username VARCHAR(50), password VARCHAR(50), remember_me BIT)", 
                    connection))
                {
                    command.ExecuteNonQuery();
                }

                // Lưu thông tin đăng nhập vào cơ sở dữ liệu nếu người dùng chọn tùy chọn "Remember me"
                if (rememberMeCheckBox.Checked)
                {
                    string username = usernameTextBox.Text;
                    string password = passwordTextBox.Text;

                    using (var command = new SqlCommand("INSERT INTO login (username, password, " +
                        "remember_me) VALUES (@username, @password, 1)", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.ExecuteNonQuery();
                    }
                }

                // Xóa thông tin đăng nhập trong cơ sở dữ liệu nếu người dùng không chọn tùy chọn "Remember me"
                if (!rememberMeCheckBox.Checked)
                {
                    using (var command = new SqlCommand("DELETE FROM login WHERE remember_me = 1",
                        connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
